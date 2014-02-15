/*
Using a single directional imput from an IMU, convert the string data into a usable int, then use the 
value of the angle and PID control to drive motors to stabilize the system.
Future Steps:
Experiment with PID library and AUTOTUNEPID function
Tuning of the PID Constants is necessary
Scale the Output 
*/
#include <Servo.h>

//Motors
#define Motor_A_Dir_Pin  4
#define Motor_A_Drive_Pin  5
#define Motor_B_Dir_Pin  4
#define Motor_B_Drive_Pin  5

//Serial Comm
#define DATABUFFERSIZE      10
char dataBuffer[DATABUFFERSIZE + 1]; //Add 1 for NULL terminator
byte dataBufferIndex = 0;
char startChar = '#'; 
char endChar = '\r';
boolean storeString = false; //This will be our flag to put the data in our buffer

int angle;

int scale = 5;

//PID values, parameters, and Constants
int settime = 20; //loop time in milliseconds
float Kp = 1;
float Ki = 0;
float Kd = 0;
float Pout;
float Iout;
float Dout;
int Output;
float now;
float lasttime = 0;
float timechange;
float Input;
float lastinput;
float Setpoint = 8500;
float error;
float errorsum = 0;
float Derror;

void setup() 
  {
  Serial.begin(57600); 
  
  R_Servo.attach(R_ServoPin);
  L_Servo.attach(L_ServoPin);
  
  R_Servo.write(SERVOCENTER);
  L_Servo.write(SERVOCENTER);
  }

boolean getSerialString()
  {
  static byte dataBufferIndex = 0;
  
   while(Serial.available() > 0)
     {
     char incomingbyte = Serial.read();
     
     if(incomingbyte == startChar)
       {
       dataBufferIndex = 0;  //Initialize our dataBufferIndex variable
       storeString = true;
       continue; //return to loop
       }
     
       if(storeString)
         {
         //Let's check our index here, and abort if we're outside our buffer size
         //We use our define here so our buffer size can be easily modified
         if(dataBufferIndex == DATABUFFERSIZE)
           {
           //Oops, our index is pointing to an array element outside our buffer.
           dataBufferIndex = 0;
           storeString = false;
           break;
           }
            
         if(incomingbyte == endChar)
           {
           dataBuffer[dataBufferIndex] = 0; //null terminate the C string
           //Our data string is complete.  return true
           storeString = false;
           return true;
            }
            
          else
            {
            dataBuffer[dataBufferIndex++] = incomingbyte;
            dataBuffer[dataBufferIndex] = 0; //null terminate the C string
            }
          }
          
       }  

return false;  
  }  

void getAngleMeasure()
  {
    char delimiters[] = ","; 
    char* valPosition;  
 
    valPosition = strtok(dataBuffer, delimiters);
     
    if (valPosition)
          {
          angle = atoi(valPosition);
          valPosition = strtok(NULL, delimiters);
          angle = -angle; //make angle positive. depends on orientation of IMU
          }
        else
          angle = 0; //in case of garbage data
  }
  
void driveWithPID()
  {
  now = millis();
  timechange = (now - lasttime);
  
  if (timechange >= settime)
    {
    Input = (angle / scale); 
    error = (Setpoint / scale) - Input;
    errorsum = errorsum + error;
    Derror = Input - lastinput;
    Pout = Kp * error;
    Iout = Ki * errorsum;
    Dout = Kd * Derror;
    
      if (Iout > 25)
        Iout = 25;
      if (Iout < -25)
        Iout = -25;
        
    Output = (int)(Pout + Iout + Dout);
    
      if (Output > 200)
        Output = 200;
      if (Output < -200)
        Output = -200;
        
    lastinput = Input;
    lasttime = now;
    
    if (error == 0)
      {
      errorsum = 0;
      L_Servo.write (SERVOCENTER);
      R_Servo.write (SERVOCENTER);
      }
      
    else
      {
      L_Servo.writeMicroseconds (1500 - Output);
      R_Servo.writeMicroseconds (1500 + Output);
      }
    
    /*
    // Print values
    // Keep this format to use in processing (i.e. comment lines 4,5,8,11,14,15,16,17,20,23)  
    Serial.print ("angle"); //line 1
    Serial.print (":");
    Serial.print (Input);
  //Serial.print (",");
  //Serial.print ("error : ");
    Serial.print (error);  
    Serial.print (", ");
  //Serial.print ("errorsum : ");
    Serial.print (errorsum);
    Serial.print (",");
  //Serial.print ("Pout : ");  
    Serial.print (Pout);
    Serial.print (", ");
  //Serial.print ("Derror : "); 
  //Serial.print (Derror);
  //Serial.print (", ");
  //Serial.print ("Iout : ");
    Serial.print (Iout);
    Serial.print (", ");
  //Serial.print ("Dout : ");  
    Serial.print (Dout);
    Serial.print (", "); 
  //Serial.print ("Output : ");  
    Serial.println (Output);
    */
    
    Serial.print (error);  
    Serial.print (", ");
    Serial.print (errorsum);
    Serial.print (",");
    Serial.print (Pout);
    Serial.print (", ");
    Serial.print (Iout);
    Serial.print (", ");
    Serial.print (Dout);
    Serial.print (", "); 
    Serial.print (Output);
    Serial.print (", ");
    Serial.println (Input); 
    }
  }
  
void loop() 
  {
   //Parse string to get angle as int
  if(getSerialString())
    {
    getAngleMeasure();
    
    }
    driveWithPID();
   //Use angle measure and PID to move 
  
  }
 



