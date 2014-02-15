
import processing.serial.*;
import controlP5.*;

int sensorCount = 7; // max number of values to expect

int plotHeight = 600;       // the plot height in pixels
int plotWidth = 1000;       // plot width in pixels
int ExpectUpdateSpeed = 50; // milliseconds.  This just allows the axis labels in the X direction accurate

// These are all in real number space
// all X values measured in ExpectedUpdateSpeed Intervals
int gridSpaceX = 100;  
int gridSpaceY = 10; 
int startX     = 0;
int endX       = 200;
int startY     = -20;
int endY       = 20;

// *********  unlikely that you want to change these  ********* 
int BAUDRATE     = 57600; 

char DELIM_CHAR   = ',';   // Delimeter for parsing incoming data
char COMMAND_MARKER = '!'; // Command starts with this

//  *********  SETINGS  *********
int yBorder = 40;  // Size of the background area around the plot in screen pixels
int xBorder = 120;

byte[] inBuffer = new byte [200];
int inIndex = 0;

// leave these to be calculated
float pixPerRealY = float(plotHeight)/(endY - float(startY));
float pixPerRealX = float(plotWidth)/(endX - float(startX));

// These are calculated here, but could be changed if you wanted
int windowWidth = plotWidth + 2*xBorder;
int windowHeight = plotHeight +  2*yBorder;

// ******* Legend  ********
// Define the location and size of the Legend area
int legendWidth = 125;
int legendHeight = 200;
int legendX = windowWidth - 140;
int legendY =  15;

// ******* Help Window  ********
// Define the size of the help area.  It always sits in the middle
int helpWidth  = plotWidth - 100;
int helpHeight = plotHeight - 100;

String title = "PID Controller Tuning";  
String names = "Error ErrSum P I D Output Angle"; // The names of the values that get sent over serial
boolean[] plotThisName = { true, false, true, true, true, true, false};                // For each of the values, you can choose if you want it plotted or not here

//String yLabel = "P\nI\nD\n";  // this is kind of a hack to make the vertical label
String xLabel = "Seconds";        
String fontType = "Courier";      

//  ****************   end of Settings area  ****************
String helpBase = "-Plotter Help-\n(all characters are case sensitive)\nh : toggle this help screen\nl : toggle the Legend\nS : save screen\nE : export shown data as text\n\n-Device Help-  \n";
String helpString = "";
Serial myPort;                // The serial port

boolean displayLegend = true;
boolean displayHelp = false;

float[][] sensorValues = new float[endX-startX][sensorCount];  // array to hold the incoming values
int currentValue = -1;
int hPosition = startX;                     // horizontal position on the plot
int displayChannel = 0;                     // which of the five readings is being displayed
int threshold = 50;                         // threshold for whether or not to write

// data to a file
boolean updatePlot = false;
//int [] lastSet  = new int[sensorCount];

int[][] colors = new int[sensorCount][3];

PFont titleFont;
PFont labelFont;

ControlP5 controlP5;
controlP5.Textfield SPField;
controlP5.Textfield PField;
controlP5.Textfield IField;
controlP5.Textfield DField;

void setupColors() 
  {
  // Thanks to colorbrewer for this pallete
  colors[0][0] = 102;  
  colors[0][1] = 194; 
  colors[0][2] = 165;
  colors[1][0] = 252;  
  colors[1][1] = 141; 
  colors[1][2] =  98;
  colors[2][0] = 141;  
  colors[2][1] = 216; 
  colors[2][2] = 203;
  colors[3][0] = 231;  
  colors[3][1] = 138; 
  colors[3][2] = 195;
  colors[4][0] = 166;  
  colors[4][1] = 160; 
  colors[4][2] =  84;
  colors[5][0] = 255;  
  colors[5][1] = 217; 
  colors[5][2] =  47;
  }

void setup ()
  {
  size(windowWidth, windowHeight);        // window size
  setupColors();
  smooth();

  titleFont = createFont (fontType, 18);
  labelFont = createFont (fontType, 14 );

  clearPlot();
  // List all the available serial ports
  println(Serial.list());

  // Open whatever port is the one you're using.
  //myPort = new Serial(this, "/dev/ttyUSB0", BAUDRATE);
  //myPort.clear();
  
  controlP5 = new ControlP5(this);                                  
  SPField = controlP5.addTextfield("Setpoint", 10, 100, 60, 20);       
  PField  = controlP5.addTextfield("Kp",       10, 160, 60, 20);          
  IField  = controlP5.addTextfield("Ki",       10, 200, 60, 20);          
  DField  = controlP5.addTextfield("Kd",       10, 240, 60, 20);          
  controlP5.addButton("Send_To_Arduino", 0.0, 10, 300, 80, 20);        

  SPField.setText ("90");
  PField.setText ("1");
  IField.setText ("0");
  DField.setText ("0");
}

void draw () 
  {
  // if the value for the given channel is valid, plot it:
  if (updatePlot) 
    {
    // draw the plot:
    plot();
    updatePlot = false;
    }
  }

void clearPlot() 
  {
  background(5);
  strokeWeight(1.5);
  stroke(10);
  fill(40);
  // draw boundary
  rect(xBorder,yBorder,plotWidth, plotHeight);

  textAlign(CENTER);
  fill(70);
  textFont(titleFont);
  text(title, windowWidth / 2, yBorder / 2);

  textFont(labelFont);
  stroke(10);
  //draw grid  
  fill(70);
  textAlign(RIGHT);
  
  for (int i = startY; i <= endY; i+= gridSpaceY) 
    {
    line(xBorder - 3, realToScreenY(i), xBorder + plotWidth - 1,  realToScreenY(i));
    text(str(i), xBorder - 10, realToScreenY(i));
    }

  textAlign(LEFT);
  for (int i = startX; i <= endX ; i+= gridSpaceX) 
    {
    line(realToScreenX(i), yBorder+1, realToScreenX(i), yBorder + plotHeight + 3);
    text(str((i)/ (1000 / ExpectUpdateSpeed)), realToScreenX(i), yBorder + plotHeight + 20);
    }

  // Draw Axis Labels
  fill(70);
  //text(yLabel, xBorder - 70,  yBorder + 100 );

  textAlign(CENTER);
  text(xLabel,  windowWidth/2, yBorder + plotHeight + 50);
}

float realToScreenX (float x) 
  {
  float shift = x - startX;
  return (xBorder + shift * pixPerRealX);
  }

float realToScreenY(float y) 
  {
  float shift = y - startY;
  return yBorder + plotHeight - 1 - (shift) * pixPerRealY;
  }

void plot () 
  {
  clearPlot();
  // draw the line:
  for (int i = 0; i < sensorCount; i++) 
    {
    // assign color to each plot
    stroke(colors[i][0], colors[i][1],colors[i][2]);

    for (int x = 1; x < currentValue; x++) 
      {
      if(plotThisName[i]) 
        {
        //Draw line only if we have valid points
        
        if (sensorValues[x-1][i] != -9999 && sensorValues[x][i] != -9999)
          line (realToScreenX(x-1), realToScreenY(sensorValues[x-1][i]), realToScreenX(x), realToScreenY(sensorValues[x][i]));
        }
      }
  }

  if (hPosition >= endX) 
    {
    hPosition = startX;
    // wipe the screen clean:
    clearPlot();
    } 
  else 
    {
    hPosition += 1;  
    }

  noStroke();
  
  // DRAW LEGEND
  if (displayLegend) 
    {
    fill(128,128,128,80);
    rect(legendX, legendY, legendWidth, legendHeight);

    if (currentValue != -1)
      {
      // print the name of the channel being graphed:
      String line;
      for (int i = 0; i < sensorCount; i++) 
        {
        fill(colors[i][0], colors[i][1],colors[i][2]);
        textAlign(LEFT);
        text(split(names,' ')[i] , legendX+5, legendY + (i+1) * 20);
        textAlign(RIGHT);
        text(nf(sensorValues[currentValue][i], 0,3), legendX+legendWidth - 5, legendY + (i+1) * 20);
        }
      }  
  }

  if (displayHelp) 
    {
    textAlign(LEFT);  
    fill(128,128,128,80);
    noStroke();
    rect(windowWidth/2 - helpWidth/2, windowHeight/2 - helpHeight / 2, helpWidth, helpHeight);
    fill(255,255,255);
    helpWidth -= 20;
    helpHeight -=20;
    text(helpString,windowWidth/2 - helpWidth/2, windowHeight/2 - helpHeight / 2, helpWidth, helpHeight);
    helpWidth += 20;
    helpHeight +=20;
    }
}

void keyPressed() 
  {
  // if the key pressed is "0" through "4"
  if (key == 'l') 
    {
    // set the display channel accordingly
    displayLegend = ! displayLegend;  
    updatePlot = true;
    }
  
  if (key == 'h') 
    {
    // set the display channel accordingly
    displayHelp = ! displayHelp;  
    updatePlot = true;
    }
  
  if (key == 'S') 
    {
    // set the display channel accordingly
    save(str(hour()) + "h" + str(minute()) + "m" + str(second()) +  "s"  + str(month()) + "." + str(day()) + "." + str(year())+".jpg") ;
    }
  
  if (key == 'E') 
    {
    exportText();
    }
  
  //myPort.write (key);
  }

void exportText()
  {
  // string for the new data you'll write to the file:
  String[] outStrings = new String[currentValue+1];
  
  outStrings[0] = names;
  
  for (int i =0; i < currentValue; i++) 
    {
    outStrings[i+1] = "";
    
    for (int j=0; j < sensorCount; j++) 
      {
      outStrings[i+1]   += str(sensorValues[i][j]);
      
      if (j < sensorCount - 1) 
        {
        outStrings[i+1] += ", ";
        }
      }
    }
  
    saveStrings(str(hour()) + "h" + str(minute()) + "m" + str(second()) +  "s"  + str(month()) + "." + str(day()) + "." + str(year())+".txt", outStrings);
  }

// make up a timeStamp string for writing data to the file:
String timeStamp() 
  {
  String now = hour()+ ":" +  minute()+ ":" + second()+ " " + month() + "/"  + day() + "/" + year();
  return now;
  }

void Send_To_Arduino()
  {
  String command = new String ();
  command += COMMAND_MARKER;
  command += SPField.getText ();
  command += ",";
  command += PField.getText ();
  command += ",";
  command += IField.getText ();
  command += ",";
  command += DField.getText ();
  command += '\n';
  
  //myPort.write (command);
  print ("Sending command to Arduino: ");
  println (command);  
}
  
void serialEvent(Serial myPort) 
  {
  int count;
  count = 0;
  
  while (myPort.available () > 0)
    {
    char inChar = myPort.readChar ();
        
    if (inChar == '\n') //ignore
      continue; 
    
    if (inChar == '\r')
      {
      count = 1;
      inBuffer[inIndex] = '\0';
      inIndex = 0;
      break;
      }  
    else
      {
      inBuffer[inIndex++] = (byte)inChar;
      }
  }

  if (count > 0) 
    {
    String serialString = new String (inBuffer);    

    // split it into substrings on the DELIM character:
    String[] numbers = split(serialString, DELIM_CHAR);
   
    // convert each subastring into an int
   if (numbers.length > 0) 
     {
     currentValue += 1;
     
     if (currentValue >= (endX - startX))
       currentValue = 0;
        
     for (int i = 0; i < sensorCount; i++) 
       {
       // make sure you're only reading as many numbers as you can fit in the array:
       if (i < numbers.length) 
         sensorValues[currentValue][i] = float(trim (numbers[i]));
       else
         sensorValues[currentValue][i] = -9999; //Missing value
       }
       
      updatePlot = true;
     } 
   else 
     {
     // Things we don't handle in particular can get output to the text window
     print ("count=");
     print (numbers.length);
     print (". ");
     println (serialString);
     }
  }
}

