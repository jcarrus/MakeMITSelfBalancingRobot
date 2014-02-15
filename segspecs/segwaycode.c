#include <pic.h>
// Machine Science library 
// includes functions for usart and adc
#include "mxapi.h"

/* Radio debugging defines */
#define TX_START 0xFF
#define TX_ESC 0xFE
#define ESC1 0b10000000
#define ESC2 0b01000000

#define TX_LT 0x01
#define TX_AX 0x02
#define TX_AS 0x03
#define TX_GZ 0x04
#define TX_AE 0x05
#define TX_ML 0x06
#define TX_MR 0x07

/* trims */
#define AX_OFFSET 512
#define AS_OFFSET 512
#define GZ_OFFSET 522

/* control parameters */
#define KP 0.4	// proportional
#define KD 0.5	// derivative
#define KS 4.0	// steering

/* Used for deadband hysteresis */
#define FORWARD 1
#define REVERSE 0


/* Fancy segway code.
 * Disclaimer: If you fall off, it's your fault.
 */


/* Handles motor pulses and main loop timer with onboard timers & interrupts. */
void interrupt segwayctl() {

	if (TMR1IF) { /* 10ms timer for motors -- turns them on for start of pulse. */
		TMR1H = 55535 >> 8;
		TMR1L = 55535 & 0xFF;
		RC1 = RC2 = 1;
		TMR1IF = 0;
	}

	if (CCP1IF) { /*end motor pulse*/
		RC1 = 0;
		CCP1IF = 0;
	}

	if (CCP2IF) { /*end motor pulse*/
		RC2 = 0;
		CCP2IF = 0;
	}
}


/* Sends information to radio for debugging. */
void tx(unsigned char addr, unsigned char byte1, unsigned char byte2) {

	usart_write(TX_START);

	if (byte1 == TX_START) {
		usart_write(TX_ESC);
		addr |= ESC1;
	} else {
		usart_write(byte1);
	}

	if (byte2 == TX_START) {
		usart_write(TX_ESC);
		addr |= ESC2;
	} else {
		usart_write(byte2);
	}

	usart_write(addr);
}

/* IT RUNS AT 100HZ!
 * MAGICALLY!
 */
void main() {

	signed int lmotor = 512, rmotor = 512;
	signed int speed_offset = 0;
	signed int turn = 0;
	unsigned char tx_i = 1;
	unsigned char dtmr; /* Loop time */
	unsigned char direction = FORWARD;
	
	unsigned char rider;

	signed int ax_adc, as_adc, gz_adc; /* Analog values */
	signed int ax_deg, as_deg, gz_vel; /* Unit values */
	float angle = 0, motor = 0; 

	/*setup interrupts*/
	/*sensors are on pins 1 and 2, values AN0 and AN1*/
	GIE = PEIE = CCP1IE = CCP2IE = TMR1IE = 1;
	T1CON = 1;
	PR2 = 0xFF;
	CCP1CON = CCP2CON = 0b1010;
	TRISC1 = TRISC2 = 0; /* TRISC1 and TRISC2 set pins as outputs. */
	TRISB1 = 1;
	RBPU = 0; // pull up resistors on PORTB

	/* Setting up Timer 0, this was a pain to figure out */
	T0CS = PSA = PS0 = 0;
	PS2 = PS1 = 1;
	
	usart_init(19200);
	adc_init(ALL_ANALOG);
    
 	CCPR1H = (56523 + 512) >> 8;
	CCPR1L = (56523 + 512) & 0xFF;
	CCPR2H = (56523 + 512) >> 8;
	CCPR2L = (56523 + 512) & 0xFF;

	delay_ms(3000);	

	if(RB1 == 1)
	{ 
		// Wait for signal from RFID key reader.
		while(usart_read() != TX_START);
		// Grab rider ID.
		rider = usart_read();
	}

	while (1) {

		dtmr = TMR0;
		TMR0 = 0x00;

		/* Here we transmit variables to a laptop so we can see them in real-time.
		 * Every time this loop goes through we transmit one -- indicated by the value
		 * of tx_i.
		 */
		switch(tx_i) {
			case(TX_LT): { tx(TX_LT, rider, dtmr); break;}
			case(TX_AX): { tx(TX_AX, ax_adc >> 8, ax_adc & 0xFF); break; }
			case(TX_AS): { tx(TX_AS, as_adc >> 8, as_adc & 0xFF); break; }
			case(TX_GZ): { tx(TX_GZ, gz_adc >> 8, gz_adc & 0xFF); break; }
			case(TX_AE): { tx(TX_AE, ((signed int)angle + 512) >> 8, ((signed int)angle + 512) & 0xFF); break; }
			case(TX_ML): { tx(TX_ML, lmotor >> 8, lmotor & 0xFF); break; }
			case(TX_MR): { tx(TX_MR, rmotor >> 8, rmotor & 0xFF); tx_i = 0; break; }
		}
		tx_i++;
		
		/* Read analog values, calculate unit values */
		ax_adc = adc_read(0);
		gz_adc = adc_read(1);
		as_adc = adc_read(2);
		ax_deg = (ax_adc - AX_OFFSET) * 14 >> 5;
		ax_deg += speed_offset;	/* speed limit by leaning back */
		as_deg = (as_adc - AS_OFFSET) * 14 >> 5;
		gz_vel = (gz_adc - GZ_OFFSET) * 11 >> 5;

		angle = 0.97 * (angle + (float)gz_vel * (float)dtmr * 0.000128);
		angle += 0.03 * ((float)ax_deg);
		
		/* 'motor' is the base value of the motors, independent from turning speeds. */
		motor += ((KP * angle) + (KD * (float)gz_vel));
		if (motor <= -511) { motor = -511; }
		else if (motor >= 511) { motor = 511; }
		speed_offset = (int)(motor * 0.025);

		lmotor = rmotor = 511 + (int)motor;

		/* Steering */
		turn = (int)((float)as_deg * KS);

		/* Factor in steering with motors*/
		lmotor += turn;
		rmotor -= turn;

		/* Kill deadzone*/
		if (lmotor < 547 && lmotor > 477 && direction == FORWARD) { lmotor = 547; }
		else if (rmotor < 547 && rmotor > 477 && direction == REVERSE) { rmotor = 477; }
		if (lmotor <= 547) { direction = FORWARD; }
		else if (motor >= 466) { direction = REVERSE; }

		/* Making sure the motor values don't overflow and mess up */
		if (lmotor > 1022) { lmotor = 1022; }
		else if (lmotor < 0) { lmotor = 0; }
		if (rmotor > 1022) { rmotor = 1022; }
		else if (rmotor < 0) { rmotor = 0; }

		/* Killswitch - not used at the moment */
		if (0 == 1) {
			rmotor = lmotor = 512;
			motor = 0;
		}

		/* Actually control motors */
		CCPR1H = (56523 + lmotor) >> 8;
		CCPR1L = (56523 + lmotor) & 0xFF;
		CCPR2H = (56523 + rmotor) >> 8;
		CCPR2L = (56523 + rmotor) & 0xFF;
	}
}