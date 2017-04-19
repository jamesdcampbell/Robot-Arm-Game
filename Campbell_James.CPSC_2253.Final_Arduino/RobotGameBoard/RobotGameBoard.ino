/*
 * OWNER: James Campbell
 *
 * DATE: 4/9/17
 *
 * TITLE: RobotGameBoard.ino
 *
 * PURPOSE: To run the 8 servos involved in the robot arm game and to get commands from the server.   
 *
 */
#include <Servo.h> 

Servo arm1[4]; //PURPOSE: Array of the 4 servos in arm 1
Servo arm2[4]; //PURPOSE: Array of the 4 servos in arm 2

int arm1Pos[4]; //PURPOSE: Array of the arm1 servo positions
int arm2Pos[4]; //PURPOSE: Array of the arm2 servo positions

const byte numChars = 7; 
char receivedChars[numChars]; 
char tempChars[numChars];
int servoFromPC;
int positionFromPC = 0;

boolean newData = false;

void setup() 
{ 
Serial.begin(9600); //PURPOSE: Begin listening at 9600 baud rate
connectServos(); //PURPOSE: Connect all the servos
setAll90(); //PURPOSE: Set all servos to 90 degrees 
} 

void connectServos()
{
arm1[0].attach(53); // 53 
arm1[1].attach(52); // 52 CD
arm1[2].attach(47); // 47 CD
arm1[3].attach(49); // 49
delay(100);
arm2[0].attach(45); // 45
arm2[1].attach(51); // 51 CD
arm2[2].attach(43); // 43 CD
arm2[3].attach(46); // 46
}



void loop() 
{ 
   updateArmPos();
   getArmPos();
} 

//FUNCTION:
//PURPOSE: To write the position of each servo based on the set position array.
void updateArmPos() 
{
  for(int temp = 0;temp < 4;temp++)
  {
    arm1[temp].write(arm1Pos[temp]);
    arm2[temp].write(arm2Pos[temp]);
  }
}
//FUNCTION:
//PURPOSE: Top level function for getting commands from server
void getArmPos() 
{
    recvWithStartEndMarkers();
    if (newData == true) {
        strcpy(tempChars, receivedChars);
            // this temporary copy is necessary to protect the original data
            //   because strtok() used in parseData() replaces the commas with \0
        parseData();
        //showParsedData();
        newData = false;
    }
}
//FUNCTION:
//PURPOSE: Set all servo positions to 90.
void setAll90()
{
   for(int temp = 0;temp < 4;temp++)
   {
    arm1Pos[temp] = 90;
    arm2Pos[temp] = 90;
   }
}
//FUNCTION:
//PURPOSE: Get server command with start and end points.
void recvWithStartEndMarkers() 
{
    static boolean recvInProgress = false;
    static byte ndx = 0;
    char startMarker = '<';
    char endMarker = '>';
    char rc;

    while (Serial.available() > 0 && newData == false) 
    {
        rc = Serial.read();

        if (recvInProgress == true) 
        {
            if (rc != endMarker) 
            {
                receivedChars[ndx] = rc;
                ndx++;
                if (ndx >= numChars) 
                {
                    ndx = numChars - 1;
                }
            }
            else 
            {
                receivedChars[ndx] = '\0';
                recvInProgress = false;
                ndx = 0;
                newData = true;
            }
        }

        else if (rc == startMarker) 
        {
            recvInProgress = true;
        }
    }
}
//FUNCTION:
//PURPOSE: Parse command from server into servo and positions
void parseData() 
{ 
    char * strtokIndx; 
    strtokIndx = strtok(tempChars,","); 
    servoFromPC = atoi(strtokIndx);

     if (servoFromPC > 4)
     {
        servoFromPC = servoFromPC -4;
        servoFromPC = servoFromPC -1;
        strtokIndx = strtok(NULL, ","); 
        positionFromPC = atoi(strtokIndx);
        arm2Pos[servoFromPC] = positionFromPC;
        return;
     }
     if (servoFromPC <= 4)
     {
        servoFromPC = servoFromPC -1;
        strtokIndx = strtok(NULL, ","); 
        positionFromPC = atoi(strtokIndx);
        arm1Pos[servoFromPC] = positionFromPC;
        return;
     }
}
//FUNCTION:
//PURPOSE: Show servo and position (development).
void showParsedData() 
{
    Serial.print("Servo: ");
    Serial.print(servoFromPC+1);
    Serial.print(" Position: ");
    Serial.println(positionFromPC);
}

