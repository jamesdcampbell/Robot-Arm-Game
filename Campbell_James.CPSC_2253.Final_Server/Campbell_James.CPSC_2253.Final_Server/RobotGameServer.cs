/*
 * OWNER: James Campbell
 *
 * DATE: 4/9/17
 *
 * TITLE: Final_Server / RobotGameServer.cs
 *
 * PURPOSE: To facilitate and organize the robot arm game. This server will connect the clients, assign servos, and forward their commands to the Arduino board.   
 *
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;

using NetComm;

namespace RGServer
{
    public partial class RobotGameServer : Form
    {
        bool devMode = true; //PURPOSE: Dev mode allows rounds to start with less than full teams.
        SerialPort arduino = new SerialPort(); //PURPOSE: Connection to Arduino
        private NetComm.Host server = new Host(3330); //PURPOSE: Listens on port 3330.
        private int activeConnections = 0;
        private delegate void DisplayInformationDelegate(string s);
        private ArrayList clientList = new ArrayList(); //PURPOSE: Share amongst all instances of the Clients
        private ArrayList teamOptions = new ArrayList(); //PURPOSE: Team names set at server start
        private ArrayList team1 = new ArrayList(); //PURPOSE: List of clients in team1
        private ArrayList team2 = new ArrayList(); //PURPOSE: List of clients in team2

        private int team1Points = 0; //PURPOSE: List of points for team 1 (updated, but not being used)
        private int team2Points = 0; //PURPOSE: List of points for team 2 (updated, but not being used)

        ///////////////////////////FUNCTIONS

        //FUNCTION:
        //PURPOSE: Constructor
        public RobotGameServer()
        {
            InitializeComponent();
            SerialConnections.DataSource = SerialPort.GetPortNames(); //Get COM port names for list
        }

        //FUNCTION:
        //PURPOSE: Conduct handshake for when client connects to server.
        void ServerOnConnection(string id)
        {
            activeConnections++;
            DisplayInformation(String.Format("Client {0} Connected", id));
            clientList.Add(id);
            SendClientList(id);
            SendClientConnect(id);
            SendTeamOptions(id);
        }

        //FUNCTION:
        //PURPOSE: Send a single client a list of the other clients connected.
        private void SendClientList(string id)
        {
            DisplayInformation("Sending Client List To: " + id);
            string listOfClients = "CLIST::";
            foreach (string cid in clientList)
            {
                listOfClients += "::" + cid;
            }
            byte[] d = ConvertStringToBytes(listOfClients);
            server.SendData(id, d);
        }

        //FUNCTION:
        //PURPOSE: Send a single client a list of the team options.
        private void SendTeamOptions(string id)
        {
            DisplayInformation("Sending Team Options To: " + id);
            string listOfOptions = "TEAMOPT::";
            foreach (string team in teamOptions)
            {
                listOfOptions += "::" + team;
            }
            byte[] d = ConvertStringToBytes(listOfOptions);
            server.SendData(id, d);
            SendMessage("Connection successful, please select a team.",id);
        }

        //FUNCTION:
        //PURPOSE: Send a message and client name to all other clients indicating a disconnect.
        private void SendClientDisconnect(string id)
        {
            DisplayInformation("Sending Disconnect Message To: All");
            string disconnectMessage = "DISCONNECT::";
            foreach (string cid in clientList)
            {
                if (id != cid)
                {
                    byte[] d = ConvertStringToBytes(disconnectMessage + id);
                    server.SendData(cid, d);
                }
            }
        }

        //FUNCTION:
        //PURPOSE: Send a single clent a prompt message.
        private void SendMessage(string message, string id)
        {
            DisplayInformation("Sending Message To: All");
            string header = "MSG::";
            message = header + message;
            byte[] d = ConvertStringToBytes(message);
            server.SendData(id, d);
        }

        //FUNCTION:
        //PURPOSE: Send all clients a prompt message.
        private void SendMessageAll(string message)
        {
            DisplayInformation("Sending Message To: All");
            string header = "MSG::";
            message = header + message;
            foreach (string cid in clientList)
            {
                byte[] d = ConvertStringToBytes(message);
                server.SendData(cid, d);
            }
        }

        //FUNCTION:
        //PURPOSE: Send all clients a message that another client has connected.
        private void SendClientConnect(string id)
        {
            DisplayInformation("Sending Connect Message To: All");
            string connectMessage = "CONNECT::";
            foreach (string cid in clientList)
            {
                if (id != cid)
                {
                    byte[] d = ConvertStringToBytes(connectMessage + id);
                    server.SendData(cid, d);
                }
            }
        }

        //FUNCTION:
        //PURPOSE: Send all clients a message that a team has been joined, cross referencing to find out if it is home or away
        private void SendTeamJoin(string id)
        {
            DisplayInformation("Sending Join Team Message To All");
            foreach (string cid in team1)
            {
                if (cid != id)
                {
                    if (team1.Contains(id))
                    {
                        string connectMessage = "TEAMADD::";
                        byte[] d = ConvertStringToBytes(connectMessage + id);
                        server.SendData(cid, d);
                    }
                    else
                    {
                        string connectMessage = "OPPADD::";
                        byte[] d = ConvertStringToBytes(connectMessage + id);
                        server.SendData(cid, d);
                    }
                }
            }
            foreach (string cid in team2)
            {
                if (cid != id)
                {
                    if (team2.Contains(id))
                    {
                        string connectMessage = "TEAMADD::";
                        byte[] d = ConvertStringToBytes(connectMessage + id);
                        server.SendData(cid, d);
                    }
                    else
                    {
                        string connectMessage = "OPPADD::";
                        byte[] d = ConvertStringToBytes(connectMessage + id);
                        server.SendData(cid, d);
                    }
                }
            }
        }

        //FUNCTION:
        //PURPOSE: Send all clients a message that a point has been scored, cross referencing to find out if it is home or away
        private void SendPoint(string team, char value)
        {
            string message = "";
            if (team == teamOptions[0].ToString())
            {
                team1Points++;
                foreach (string cid in team1)
                {
                    DisplayInformation("Sending Winning Points Value To: Team 1");
                    string header = "POINTUS::";
                    message = header + value;
                    byte[] d = ConvertStringToBytes(message);
                    server.SendData(cid, d);
                }
                foreach (string cid in team2)
                {
                    DisplayInformation("Sending Losing Points Value To: Team 2");
                    string header = "POINTTHEM::";
                    message = header + value;
                    byte[] d = ConvertStringToBytes(message);
                    server.SendData(cid, d);
                }
            }
            if (team == teamOptions[1].ToString())
            {
                team2Points++;
                foreach (string cid in team2)
                {
                    DisplayInformation("Sending Winning Points Value To: Team 2");
                    string header = "POINTUS::";
                    message = header + value;
                    byte[] d = ConvertStringToBytes(message);
                    server.SendData(cid, d);
                }
                foreach (string cid in team1)
                {
                    DisplayInformation("Sending Losing Points Value To: Team 1");
                    string header = "POINTTHEM::";
                    message = header + value;
                    byte[] d = ConvertStringToBytes(message);
                    server.SendData(cid, d);
                }
            }
        }

        //FUNCTION:
        //PURPOSE: Send all clients a message that the round has started. Also assign servos to clients
        private void RoundStart()
        {
            DisplayInformation("-----Round Start!-----");
            Random random = new Random();
            List<int> servos = new List<int> { 1, 2, 3, 4 };
            DisplayInformation("--------Team 1--------");
            foreach (string cid in team1)
            {
                int selectedServo = servos[random.Next(servos.Count)];
                DisplayInformation("--- " + cid + " is servo: " + selectedServo);
                servos.Remove(selectedServo);
                string connectMessage = "ROUNDSTART::" + selectedServo;
                byte[] d = ConvertStringToBytes(connectMessage);
                
                server.SendData(cid, d);
            }
            servos = new List<int> { 1, 2, 3, 4 };
            DisplayInformation("--------Team 2--------");
            foreach (string cid in team2)
            {
                int selectedServo = servos[random.Next(servos.Count)];
                DisplayInformation("--- " + cid + " is servo: " + selectedServo);
                servos.Remove(selectedServo);
                string connectMessage = "ROUNDSTART::" + selectedServo;
                byte[] d = ConvertStringToBytes(connectMessage);
                server.SendData(cid, d);
            }
            DisplayInformation("-----Begin Round!-----");
            SendMessageAll("The round has started! Press '+' or '-' to move your servo!");
        }

        //FUNCTION:
        //PURPOSE: Send all clients a message that the round has stopped.
        private void RoundStop()
        {
            DisplayInformation("-----Round Stop!-----");
            foreach (string cid in clientList)
            {
                string connectMessage = "ROUNDSTOP::";
                byte[] d = ConvertStringToBytes(connectMessage);

                server.SendData(cid, d);
            }
            ResetArms();
            SendMessageAll("The round has stopped!");
        }

        //FUNCTION:
        //PURPOSE: Send a single client the list of his/her team mates.
        private void SendTeamList(string id)
        {
            DisplayInformation("Sending Home Team List To: " + id);
            string listOfClients = "TEAMLIST::";

            ArrayList selectedList = new ArrayList();
            if (team1.Contains(id)) { selectedList = team1; }
            if (team2.Contains(id)) { selectedList = team2; }

            foreach (string cid in selectedList)
            {
                listOfClients += "::" + cid;
            }
            byte[] d = ConvertStringToBytes(listOfClients);
            server.SendData(id, d);
        }

        //FUNCTION:
        //PURPOSE: Send a full team error if team is full
        private void SendFullTeam(string id)
        {
            DisplayInformation("Sending Full Team To: " + id);
            byte[] d = ConvertStringToBytes("TEAMFULL::");
            server.SendData(id, d);
        }

        //FUNCTION:
        //PURPOSE: Send list of opponent team members
        private void SendOpponentList(string id)
        {
            DisplayInformation("Sending Away Team List To: " + id);
            string listOfClients = "OPPLIST::";

            ArrayList selectedList = new ArrayList();
            if (!team1.Contains(id)) { selectedList = team1; }
            if (!team2.Contains(id)) { selectedList = team2; }

            foreach (string cid in selectedList)
            {
                listOfClients += "::" + cid;
            }
            byte[] d = ConvertStringToBytes(listOfClients);
            if (selectedList.Count > 0) { server.SendData(id, d); }
        }

        //FUNCTION:
        //PURPOSE: Display internal server error (Very Rare)
        private void ServerErrEncounter(Exception ex)
        {
            DisplayInformation("Server Error " + ex.Message);
        }

        //FUNCTION:
        //PURPOSE: Send a single client a ping message (not being used)
        private void SendPing(string id)
        {
            DisplayInformation("Sending Ping To: " + id);
            byte[] d = ConvertStringToBytes("PING::");
            server.SendData(id, d);
        }

        //FUNCTION:
        //PURPOSE: Get and parse data from clients
        private void Server_DataTransferred(string sender, string recipient, byte[] data)
        {
            string senderId = (string)sender;
            if (recipient == "0")
            {
                switch (ConvertBytesToString(data))
                {
                    case "CLOSING::":
                        activeConnections--;
                        DisplayInformation("Client " + senderId + " is Closing");
                        clientList.Remove(senderId);
                        if (team1.Contains(senderId)) { team1.Remove(senderId); }
                        if (team2.Contains(senderId)) { team2.Remove(senderId); }
                        SendClientDisconnect(senderId);
                        break;

                    case "PING::":
                        SendPing(senderId);
                        break;

                    default:
                        ////COMMANDS WITH DATA
                        if (ConvertBytesToString(data).StartsWith("TEAMCHOICE::")) { AssignTeam(ConvertBytesToString(data), senderId); } ;
                        if (ConvertBytesToString(data).StartsWith("MOVE::")) { ForwardMove(ConvertBytesToString(data), senderId); };
                        break;
                }
            }
        }

        //FUNCTION:
        //PURPOSE: Assign client to team list
        private void AssignTeam(string msgs, string senderId)
        {
            {
                msgs = msgs.Replace("TEAMCHOICE::", "");
                if (msgs == teamOptions[0].ToString())
                {
                    if (team1.Count < 4)
                    {
                        DisplayInformation("Assigning " + senderId + " To Team 1: " + teamOptions[0].ToString());
                        team1.Add(senderId);
                        if (team2.Count == 4 && team1.Count == 4 || devMode)
                        {
                            Action AbleToStart = () => buttonStartRound.Enabled = true;
                            this.Invoke(AbleToStart);
                        }
                        SendMessage("Joined Team: " + teamOptions[0].ToString() + " Please wait for the round to start.", senderId);

                    }
                    else
                    {
                        SendFullTeam(senderId);
                        return;
                    }
                }
                if (msgs == teamOptions[1].ToString())
                {
                    if (team2.Count < 4)
                    {
                        DisplayInformation("Assigning " + senderId + " To Team 2: " + teamOptions[1].ToString());
                        team2.Add(senderId);
                        if (team2.Count == 4 && team1.Count == 4 || devMode)
                        {
                            Action AbleToStart = () => buttonStartRound.Enabled = true;
                            this.Invoke(AbleToStart);
                        }
                        SendMessage("Joined Team: " + teamOptions[1].ToString() + " Please wait for the round to start.", senderId);
                    }
                    else
                    {
                        SendFullTeam(senderId);
                        return;
                    }
                }
                SendTeamJoin(senderId);
                SendTeamList(senderId);
                SendOpponentList(senderId);
                return;
            }
        }

        //FUNCTION:
        //PURPOSE: Forward servo and position from client to Arduino
        private void ForwardMove(string msgs, string senderId)
        {
            string toBoard= "";
            msgs = msgs.Replace("MOVE::", "");
            List<string> moveparams = msgs.Split(new string[] { "::" }, StringSplitOptions.RemoveEmptyEntries).ToList();
            if (moveparams[0].ToString() == teamOptions[0].ToString()) { toBoard = "<" + moveparams[1].ToString() + "," + moveparams[2].ToString() + ">"; }
            if (moveparams[0].ToString() == teamOptions[1].ToString()) { toBoard = "<" + (Convert.ToInt32(moveparams[1])+4).ToString() + "," + moveparams[2].ToString() + ">"; }

            if (arduino.IsOpen == true)
            {
                arduino.Write(toBoard);
                DisplayInformation("Move Forwarded: " + toBoard);
            }

            }

        //FUNCTION:
        //PURPOSE: Send arduino position 90 for all servos
        private void ResetArms()
        {
            string toArm1 = "";
            string toArm2 = "";
            for (int temp = 1;temp <= 4;temp++ )
            {
                toArm1 = "<" + temp + ",90>";
                toArm2 = "<" + (temp+4) + ",90>";
                if (arduino.IsOpen == true)
                {
                arduino.Write(toArm1);
                arduino.Write(toArm2);
                }
            }
            DisplayInformation("Arms Reset");
    }

        //FUNCTION:
        //PURPOSE: Get closing message from client
        private void Server_DataReceived(string iD, byte[] data)
        {
            if (ConvertBytesToString(data) == "CLOSING")
            {
                DisplayInformation("Client " + iD + " has closed");
            }
        }

        //FUNCTION:
        //PURPOSE: Display connection closed
        private void Server_ConnectionClosed()
        {
            DisplayInformation("Connection Was Closed");
        }

        //FUNCTION:
        //PURPOSE: Convert Bytes from client to string
        private string ConvertBytesToString(byte[] bytes)
        {
            return ASCIIEncoding.ASCII.GetString(bytes);
        }

        //FUNCTION:
        //PURPOSE: Convert string in order to send to client as bytes
        private byte[] ConvertStringToBytes(string str)
        {
            return ASCIIEncoding.ASCII.GetBytes(str);
        }

        //FUNCTION:
        //PURPOSE: Display message on server console
        private void DisplayInformation(string s)
        {
            if (this.rtbConOut.InvokeRequired)
            {
                DisplayInformationDelegate d = new DisplayInformationDelegate(DisplayInformation);
                this.rtbConOut.Invoke(d, new object[] { s });
            }
            else
            {
                this.rtbConOut.AppendText(s + Environment.NewLine);
            }
        }

        ///////////////////////////EVENTS

        private void buttonStartRound_Click(object sender, EventArgs e)
        {
            RoundStart();
            buttonStartRound.Enabled = false;
            buttonStopRound.Enabled = true;
        }

        private void rtbConOut_TextChanged(object sender, EventArgs e)
        {
            // set the current caret position to the end
            rtbConOut.SelectionStart = rtbConOut.Text.Length;
            // scroll it automatically
            rtbConOut.ScrollToCaret();
        }

        private void buttonStopRound_Click(object sender, EventArgs e)
        {
            RoundStop();
            Team1PointPlus.Enabled = true;
            Team2PointPlus.Enabled = true;
            buttonStartRound.Enabled = true;
        }

        private void buttonStartServer_Click(object sender, EventArgs e)
        {
            if (team1Box.Text != "" && team2Box.Text != "")
            {
                buttonStartServer.Enabled = false;
                team1Box.Enabled = false;
                team2Box.Enabled = false;
                server.ConnectionClosed += Server_ConnectionClosed;
                server.DataReceived += Server_DataReceived;
                server.DataTransferred += Server_DataTransferred;
                server.errEncounter += ServerErrEncounter;
                server.onConnection += ServerOnConnection;
                server.StartConnection();
                rtbConOut.AppendText(Environment.NewLine);

                teamOptions.Add(team1Box.Text);
                teamOptions.Add(team2Box.Text);
                DisplayInformation("Started Server with Team1 as " + teamOptions[0].ToString() + " and team2 as " + teamOptions[1].ToString());

                arduino.PortName = SerialConnections.Text;
                arduino.Open();
            }
            else
            {
                DisplayInformation("ERROR TEAM NAMES CAN NOT BE NULL");
            }
        }

        private void buttonSetPort_Click(object sender, EventArgs e)
        {
            buttonStartServer.Enabled = true;
            SerialConnections.Enabled = false;
            buttonSetPort.Enabled = false;
            team1Box.Enabled = true;
            team2Box.Enabled = true;
        }

        private void Team1PointPlus_Click(object sender, EventArgs e)
        {
            team1Points++;
            Team1PointDisplay.Text = (Convert.ToInt32(Team1PointDisplay.Text) + 1).ToString();
            SendPoint(teamOptions[0].ToString(), '+');
        }

        private void Team2PointPlus_Click(object sender, EventArgs e)
        {
            team2Points++;
            Team2PointDisplay.Text = (Convert.ToInt32(Team2PointDisplay.Text) + 1).ToString();
            SendPoint(teamOptions[1].ToString(), '+');
        }
    }
}
