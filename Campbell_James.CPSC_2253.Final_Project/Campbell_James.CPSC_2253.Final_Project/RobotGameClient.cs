/*
 * OWNER: James Campbell
 *
 * DATE: 4/9/17
 *
 * TITLE:Final_Project / RobotGameClient.cs
 *
 * PURPOSE: To act as a frontend to the connection class and to act as a controller for the robot arm game. 
 *
 */
using System;
using System.Windows.Forms;
using System.Collections;
using NetComm;
using System.Text;



namespace Campbell_James.CPSC_2253.Final_Project
{

    public partial class RobotGameClient : Form
    {
        Connection connection;
        private System.Timers.Timer _timer;
        private DateTime _startTime;
        private volatile bool _requestStop = false;

        public RobotGameClient()
        {
            InitializeComponent();
            connection = new Connection();
        }

        ///////////////////////////EVENTS

        private void buttonServoUp_Click(object sender, EventArgs e)
        {
            //Keep the values between 0 and 180
            if (Convert.ToInt32(labelServoPos.Text) < 180) { labelServoPos.Text = (Convert.ToInt32(labelServoPos.Text) + 1).ToString(); }
            //Send value + 1
            connection.SendMove(Convert.ToInt32(labelServoPos.Text));
        }

        private void buttonServoDown_Click(object sender, EventArgs e)
        {
            //Keep the values between 0 and 180
            if (Convert.ToInt32(labelServoPos.Text) > 0) { labelServoPos.Text = (Convert.ToInt32(labelServoPos.Text) - 1).ToString(); }
            //Send Value - 1
            connection.SendMove(Convert.ToInt32(labelServoPos.Text));
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            if (connection.ValidateSetUsername(textBoxName.Text) && connection.ValidateSetIPv4(textBoxIP.Text))
            {
                connection.ConnectToServer();
                Start();
            }
            else if (!connection.ValidateSetUsername(textBoxName.Text)) { MessageBox.Show("Error: Keep name under 30 characters and avoid using symbols."); }
            else if (!connection.ValidateSetIPv4(textBoxIP.Text)) { MessageBox.Show("Error: Invalid IP."); }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Kill timer thread and send disconnect message
            if (!(_timer == null)) { Stop(); }
            Application.ExitThread();
            connection.Disconnect();
        }

        private void ServerMSG_Enter(object sender, EventArgs e)
        {
            //Keep cursor off of servermsg
            ServerMSG.Enabled = false;
            ServerMSG.Enabled = true;
        }

        private void comboTeams_SelectionChangeCommitted(object sender, EventArgs e)
        {
            connection.TeamChoice = comboTeams.SelectedItem.ToString();
            connection.SendTeamChoice();
            comboTeams.Enabled = false;
            labelTeam.Text = connection.TeamChoice;
            labelTeam.ForeColor = System.Drawing.Color.Green;
        }

        ///////////////////////////TIMER THREAD

        //Function:
        //PURPOSE: To start the refresh timer, allowing for the client to refresh variables from the connection class every 3 seconds. 
        public void Start()
        {
            _startTime = DateTime.Now;
            _timer = new System.Timers.Timer(300 * 10);
            _timer.Elapsed += timer_Elapsed;
            _timer.Enabled = true;
            Console.WriteLine("Timer has started");
        }

        //Function:
        //PURPOSE: Stop the timer.
        private void Stop()
        {
            _requestStop = true;
            _timer.Stop();
        }

        //Function:
        //PURPOSE: Reset the enabling and variables after a full team warning.
        private void FullTeam()
        {
            connection.TeamFull = false;
            connection.TeamChoice = "";
            comboTeams.Enabled = true;
            labelTeam.Text = "Disconnected";
            labelTeam.ForeColor = System.Drawing.Color.Red;
            MessageBox.Show("Error: This team is full.");
        }

        //Function:
        //PURPOSE: Reset the enabling and variables after a full team warning.
        void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (!_requestStop)
            {
                //////////////////CONNECTION CHECKERS AND ROUTINES
                if (connection.IsConnected)
                {
                    //////////CONNECTIONS
                    Action setConnection = () => labelConnection.Text = "Connected";
                    Action setConnectionColor = () => labelConnection.ForeColor = System.Drawing.Color.Green;
                    Action disableConnection = () => buttonConnect.Enabled = false;

                    //////////TEAMS
                    Action setTeamPrompt = () => comboTeams.Text = "Select Team";
                    Action getTeams = () => comboTeams.DataSource = connection.TeamOptions.ToArray();
                    Action getHomeTeam = () => homeTeamList.DataSource = connection.HomeList.ToArray();
                    Action getAwayTeam = () => awayTeamList.DataSource = connection.AwayList.ToArray();

                    Action ifTeamFull = () => FullTeam();

                    Action activateButtons = () => ActivateServoButtons();
                    Action deactivateButtons = () => DeactivateServoButtons();

                    Action updateMSG = () => ServerMSG.Text = connection.ServerMsg;

                    //////////POINTS
                    Action setYourPoints = () => labelYouScore.Text = connection.OurPoints.ToString();
                    Action setTheirPoints = () => labelOpScore.Text = connection.TheirPoints.ToString();
                    
                    //////////INVOKES
                    this.Invoke(setConnection);
                    this.Invoke(setConnectionColor);
                    this.Invoke(disableConnection);

                    this.Invoke(updateMSG);

                    if (connection.TeamFull) { this.Invoke(ifTeamFull); }

                    if (comboTeams.Items.Count == 0) { this.Invoke(setTeamPrompt);this.Invoke(getTeams);}
                    if (connection.roundStart) { this.Invoke(activateButtons); }else { this.Invoke(deactivateButtons); }

                    this.Invoke(getHomeTeam);
                    this.Invoke(getAwayTeam);

                    this.Invoke(setYourPoints);
                    this.Invoke(setTheirPoints);
                    

                }
                else
                {
                    connection.ConnectToServer();
                }

                //////////////////TIMER
                _timer.Start();//restart the timer
                TimeSpan timeSinceStart = DateTime.Now - _startTime;
            }

        }

        ///////////////////////////FUNCTIONS

        //Function:
        //PURPOSE: Disable controls for servo
        private void ActivateServoButtons()
        {
            buttonServoUp.Enabled = true;
            buttonServoDown.Enabled = true;
            labelServoPos.Enabled = true;
        }

        //Function:
        //PURPOSE: Enable controls for servo
        private void DeactivateServoButtons()
        {
            labelServoPos.Text = "90";
            buttonServoUp.Enabled = false;
            buttonServoDown.Enabled = false;
            labelServoPos.Enabled = false;
        }

    }
}
