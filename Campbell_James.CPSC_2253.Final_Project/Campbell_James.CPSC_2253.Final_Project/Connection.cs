/*
 * OWNER: James Campbell
 *
 * DATE: 4/9/17
 *
 * TITLE: Connection.cs 
 *
 * PURPOSE: To connect and communicate with the server program, reading strings sent by the server and parsing them into valid commands 
 *              that can be communicated to the frontend via flags and values.  
 *
 */
using System;
using System.Windows.Forms;
using System.Collections;
using NetComm;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace Campbell_James.CPSC_2253.Final_Project
{

    class Connection
    {
        private NetComm.Client client = new Client(); //New Netcomm Client

        //////////BOOLS
        private bool isConnected_; //PURPOSE: Flag to indicate that client is connected
        private bool teamFull_; //PURPOSE: Flag to indicate that the selected team is full
        private bool roundStart_; //PURPOSE: Flag to indicate that a round has started and is currently going
        private bool nameTaken_; //PURPOSE: Flag to signal that the chosen name has been taken (not in use, NetComm will add incremental numbers to username)

        //////////INTS
        private int servoNum_; //PURPOSE: Assigned servo number
        private int ourPoints_; //PURPOSE: Team points
        private int theirPoints_; //PURPOSE: Opponent team points

        //////////LISTS
        private List<string> teamOptions_ = new List<string>(); //PURPOSE: Client side list of the available teams
        private List<string> teamHomeList_ = new List<string>(); //PURPOSE: Client side list of the team members
        private List<string> teamAwayList_ = new List<string>(); //PURPOSE: Client side list of the team members of the opposing team
        private List<string> connList_ = new List<string>(); //PURPOSE: Client side list of all other clients connected to the server

        //////////STRINGS
        private string teamChoice_; //PURPOSE: The team that is chosen by the user
        private string userName_; //PURPOSE: The team that is chosen by the user
        private string ipAddr_; //PURPOSE: Server IP address
        private string serverMsg_; //PURPOSE: Most current message from server

        //////////////////////////////////////////////////GET-SET
        public bool IsConnected { get { return isConnected_; } set { isConnected_ = value; } }
        public bool TeamFull { get { return teamFull_; } set { teamFull_ = value; } }
        public bool NameTaken { get { return nameTaken_; } set { nameTaken_ = value; } }
        public bool roundStart { get { return roundStart_; } set { roundStart_ = value; } }

        public int ServoNum { get { return servoNum_; } set { servoNum_ = value; } }
        public int OurPoints { get { return ourPoints_; } set { ourPoints_ = value; } }
        public int TheirPoints { get { return theirPoints_; } set { theirPoints_ = value; } }

        public List<string> ConnList { get { return connList_; } set { connList_ = value; } }
        public List<string> HomeList { get { return teamHomeList_; } set { teamHomeList_ = value; } }
        public List<string> AwayList { get { return teamAwayList_; } set { teamAwayList_ = value; } }
        public List<string> TeamOptions { get { return teamOptions_; } set { teamOptions_ = value; } }

        public string IpAddr { get { return ipAddr_; } set { ipAddr_ = value; } }
        public string TeamChoice { get { return teamChoice_; } set { teamChoice_ = value; } }
        public string UserName { get { return userName_; } set { userName_ = value; } }
        public string ServerMsg { get { return serverMsg_; } set { serverMsg_ = value; } }
        //////////////////////////////////////////////////METHODS
        
        //FUNCTION: 
        //Purpose: To send the server a position to set the servo to
        public void SendMove(int pos)
        {
            if (TeamChoice != "" && ServoNum != 0 && pos <= 180 && pos >= 0)
            {
                client.SendData(ASCIIEncoding.ASCII.GetBytes("MOVE::" + TeamChoice + "::" + ServoNum + "::" + pos), "0");
            }
        }

        //FUNCTION: 
        //Purpose: To send the server the team selected by the user
        public void SendTeamChoice()
        {
            client.SendData(ASCIIEncoding.ASCII.GetBytes("TEAMCHOICE::" + TeamChoice), "0");
        }

        //FUNCTION: 
        //Purpose: To get the data sent by the server and to translate it into a command
        public void GetData(byte[] data, string iD) {
            string msg = ASCIIEncoding.ASCII.GetString(data);
            if (msg.StartsWith("POINTUS::")) //Our team scores a point
            {
                string msgs = msg.Replace("POINTUS::", "");
                if (msgs.StartsWith("+"))
                {
                    OurPoints++;
                }
                if (msgs.StartsWith("-"))
                {
                    OurPoints--;
                }
            }
            if (msg.StartsWith("POINTTHEM::")) //Other team scores a point
            {
                string msgs = msg.Replace("POINTTHEM::", "");
                if (msgs.StartsWith("+"))
                {
                    TheirPoints++;
                }
                if (msgs.StartsWith("-"))
                {
                    TheirPoints--;
                }
            }
            if (msg.StartsWith("MSG::")) //Text message from server
            {
                string msgs = msg.Replace("MSG::", "");
                ServerMsg = msgs;
            }
            if (msg.StartsWith("NT::")) //Name taken (not currently in use)
            {
                string msgs = msg.Replace("NT::", "");
                NameTaken = true;
            }
            if (msg.StartsWith("TEAMADD::")) //Team member joined
            {
                string msgs = msg.Replace("TEAMADD::", "");
                HomeList.Add(msgs);
            }
            if (msg.StartsWith("OPPADD::")) //Opponent team member joined
            {
                string msgs = msg.Replace("OPPADD::", "");
                AwayList.Add(msgs);
            }
            if (msg.StartsWith("ROUNDSTART::")) //Round has started
            {
                string msgs = msg.Replace("ROUNDSTART::", "");
                StartRound(msgs);
            }
            if (msg.StartsWith("ROUNDSTOP::")) //Round has stopped
            {
                string msgs = msg.Replace("ROUNDEND::", "");
                StopRound();
            }
            if (msg.StartsWith("TEAMFULL::")) //Team selected is full
            {
                string msgs = msg.Replace("TF::", "");
                TeamFull = true;
            }
            if (msg.StartsWith("TEAMOPT::")) //List of team options
            {
                string msgs = msg.Replace("TEAMOPT::", "");
                TeamOptions = msgs.Split(new string[] { "::" }, StringSplitOptions.RemoveEmptyEntries).ToList();
            }
            if (msg.StartsWith("TEAMLIST::")) //List of team members at join
            {
                string msgs = msg.Replace("TEAMLIST::", "");
                HomeList = msgs.Split(new string[] { "::" }, StringSplitOptions.RemoveEmptyEntries).ToList();
            }
            if (msg.StartsWith("OPPLIST::")) //List of opponent team members at join
            {
                string msgs = msg.Replace("OPPLIST::", "");
                AwayList = msgs.Split(new string[] { "::" }, StringSplitOptions.RemoveEmptyEntries).ToList();
            }
            if (msg.StartsWith("CLIST::")) //Hidden client list
            {
                string msgs = msg.Replace("CLIST::", "");
                ConnList = msgs.Split(new string[] { "::" }, StringSplitOptions.RemoveEmptyEntries).ToList();
            }
            if (msg.StartsWith("DISCONNECT::")) //Client has disconnected
            {
                string msgs = msg.Replace("DISCONNECT::", "");
                if (HomeList.Contains(msgs)) { HomeList.Remove(msgs); }
                if (AwayList.Contains(msgs)) { AwayList.Remove(msgs); }
                ConnList.Remove(msgs);
            }
            if (msg.StartsWith("CONNECT::")) //Client has connected
            {
                string msgs = msg.Replace("CONNECT::", "");
                ConnList.Add(msgs);
            }
            if (msg.StartsWith("PING::")) //Ping (not in use)
            {
                string msgs = msg.Replace("PING::", "");
                IsConnected = true;
            }
        }

        //FUNCTION: 
        //Purpose: To send the closing message to the server, often called by the form closing
        public void Disconnect()
        {
            IsConnected = false;
            client.SendData(ASCIIEncoding.ASCII.GetBytes("CLOSING::"), "0");
            client.Disconnect();
        }

        //FUNCTION: 
        //Purpose: Grab error messages produced by the NetComm package (very rare)
        public void ClientErrEncounter(Exception ex)
        {
            MessageBox.Show("Error: " + ex.Message);
        }
       
        //FUNCTION: 
        //Purpose: Connect to the server
        public void ConnectToServer()
        {
            client.DataReceived += GetData;
            client.errEncounter += ClientErrEncounter;
            client.Disconnected += ClientDisconnected;
            client.Connect(IpAddr, 3330, UserName);
            client.Connected += ClientConnected;
        }

        //FUNCTION: 
        //Purpose: Validate the IPV4 input and return a bool. If the IP is valid, the function will also set the value.
        public bool ValidateSetIPv4(string ipString)
        {
            if (String.IsNullOrWhiteSpace(ipString))
            {
                return false;
            }

            string[] splitValues = ipString.Split('.');
            if (splitValues.Length != 4)
            {
                return false;
            }

            byte tempForParsing;

             if(splitValues.All(r => byte.TryParse(r, out tempForParsing)))
            {
                IpAddr = ipString;
                return true;
            }
            return false;
        }

        //FUNCTION: 
        //Purpose: Validate the username input and return a bool. If the username is valid, the function will also set the value.
        public bool ValidateSetUsername(string username)
        {
            if (username.Length < 20 && !username.Contains(':') && username.Length > 0)
            {
                UserName = username;
                return true;
            }
            return false;
        }

        //FUNCTION: 
        //Purpose: Get the assigned servo number and set the roundStart bool
        public void StartRound(string servo)
        {
            ServoNum = Convert.ToInt32(servo);
            roundStart = true;
        }

        //FUNCTION: 
        //Purpose: Clear the servonumber and change the roundStart flag
        public void StopRound()
        {
            ServoNum = 0;
            roundStart = false;
        }

        public void ClientConnected() {IsConnected = true;}

        public void ClientDisconnected(){IsConnected = false;}

    }
}
