namespace RGServer
{
    partial class RobotGameServer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.rtbConOut = new System.Windows.Forms.RichTextBox();
            this.buttonStartRound = new System.Windows.Forms.Button();
            this.buttonStopRound = new System.Windows.Forms.Button();
            this.team1Box = new System.Windows.Forms.TextBox();
            this.team2Box = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Team1PointPlus = new System.Windows.Forms.Button();
            this.Team2PointPlus = new System.Windows.Forms.Button();
            this.Team1PointDisplay = new System.Windows.Forms.TextBox();
            this.Team2PointDisplay = new System.Windows.Forms.TextBox();
            this.groupBoxNames = new System.Windows.Forms.GroupBox();
            this.groupBoxScore = new System.Windows.Forms.GroupBox();
            this.SerialConnections = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonSetPort = new System.Windows.Forms.Button();
            this.buttonStartServer = new System.Windows.Forms.Button();
            this.groupBoxNames.SuspendLayout();
            this.SuspendLayout();
            // 
            // rtbConOut
            // 
            this.rtbConOut.BackColor = System.Drawing.Color.Black;
            this.rtbConOut.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbConOut.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.rtbConOut.ForeColor = System.Drawing.Color.White;
            this.rtbConOut.Location = new System.Drawing.Point(0, 183);
            this.rtbConOut.Name = "rtbConOut";
            this.rtbConOut.ReadOnly = true;
            this.rtbConOut.ShowSelectionMargin = true;
            this.rtbConOut.Size = new System.Drawing.Size(284, 411);
            this.rtbConOut.TabIndex = 2;
            this.rtbConOut.Text = "";
            this.rtbConOut.TextChanged += new System.EventHandler(this.rtbConOut_TextChanged);
            // 
            // buttonStartRound
            // 
            this.buttonStartRound.Enabled = false;
            this.buttonStartRound.Location = new System.Drawing.Point(12, 0);
            this.buttonStartRound.Name = "buttonStartRound";
            this.buttonStartRound.Size = new System.Drawing.Size(75, 33);
            this.buttonStartRound.TabIndex = 3;
            this.buttonStartRound.Text = "Start Round";
            this.buttonStartRound.UseVisualStyleBackColor = true;
            this.buttonStartRound.Click += new System.EventHandler(this.buttonStartRound_Click);
            // 
            // buttonStopRound
            // 
            this.buttonStopRound.Enabled = false;
            this.buttonStopRound.Location = new System.Drawing.Point(197, 0);
            this.buttonStopRound.Name = "buttonStopRound";
            this.buttonStopRound.Size = new System.Drawing.Size(75, 33);
            this.buttonStopRound.TabIndex = 4;
            this.buttonStopRound.Text = "Stop Round";
            this.buttonStopRound.UseVisualStyleBackColor = true;
            this.buttonStopRound.Click += new System.EventHandler(this.buttonStopRound_Click);
            // 
            // team1Box
            // 
            this.team1Box.Enabled = false;
            this.team1Box.Location = new System.Drawing.Point(55, 113);
            this.team1Box.Name = "team1Box";
            this.team1Box.Size = new System.Drawing.Size(90, 20);
            this.team1Box.TabIndex = 5;
            // 
            // team2Box
            // 
            this.team2Box.Enabled = false;
            this.team2Box.Location = new System.Drawing.Point(55, 139);
            this.team2Box.Name = "team2Box";
            this.team2Box.Size = new System.Drawing.Size(90, 20);
            this.team2Box.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Team 1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Team 2";
            // 
            // Team1PointPlus
            // 
            this.Team1PointPlus.Enabled = false;
            this.Team1PointPlus.Location = new System.Drawing.Point(157, 111);
            this.Team1PointPlus.Name = "Team1PointPlus";
            this.Team1PointPlus.Size = new System.Drawing.Size(27, 23);
            this.Team1PointPlus.TabIndex = 9;
            this.Team1PointPlus.Text = "+";
            this.Team1PointPlus.UseVisualStyleBackColor = true;
            this.Team1PointPlus.Click += new System.EventHandler(this.Team1PointPlus_Click);
            // 
            // Team2PointPlus
            // 
            this.Team2PointPlus.Enabled = false;
            this.Team2PointPlus.Location = new System.Drawing.Point(157, 137);
            this.Team2PointPlus.Name = "Team2PointPlus";
            this.Team2PointPlus.Size = new System.Drawing.Size(27, 23);
            this.Team2PointPlus.TabIndex = 10;
            this.Team2PointPlus.Text = "+";
            this.Team2PointPlus.UseVisualStyleBackColor = true;
            this.Team2PointPlus.Click += new System.EventHandler(this.Team2PointPlus_Click);
            // 
            // Team1PointDisplay
            // 
            this.Team1PointDisplay.Location = new System.Drawing.Point(190, 113);
            this.Team1PointDisplay.Name = "Team1PointDisplay";
            this.Team1PointDisplay.ReadOnly = true;
            this.Team1PointDisplay.Size = new System.Drawing.Size(70, 20);
            this.Team1PointDisplay.TabIndex = 13;
            this.Team1PointDisplay.Text = "0";
            // 
            // Team2PointDisplay
            // 
            this.Team2PointDisplay.Location = new System.Drawing.Point(190, 139);
            this.Team2PointDisplay.Name = "Team2PointDisplay";
            this.Team2PointDisplay.ReadOnly = true;
            this.Team2PointDisplay.Size = new System.Drawing.Size(70, 20);
            this.Team2PointDisplay.TabIndex = 14;
            this.Team2PointDisplay.Text = "0";
            // 
            // groupBoxNames
            // 
            this.groupBoxNames.Controls.Add(this.label1);
            this.groupBoxNames.Controls.Add(this.label2);
            this.groupBoxNames.Location = new System.Drawing.Point(9, 86);
            this.groupBoxNames.Name = "groupBoxNames";
            this.groupBoxNames.Size = new System.Drawing.Size(142, 91);
            this.groupBoxNames.TabIndex = 15;
            this.groupBoxNames.TabStop = false;
            this.groupBoxNames.Text = "Team Names";
            // 
            // groupBoxScore
            // 
            this.groupBoxScore.Location = new System.Drawing.Point(151, 86);
            this.groupBoxScore.Name = "groupBoxScore";
            this.groupBoxScore.Size = new System.Drawing.Size(121, 91);
            this.groupBoxScore.TabIndex = 16;
            this.groupBoxScore.TabStop = false;
            this.groupBoxScore.Text = "Score";
            // 
            // SerialConnections
            // 
            this.SerialConnections.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SerialConnections.FormattingEnabled = true;
            this.SerialConnections.Location = new System.Drawing.Point(80, 48);
            this.SerialConnections.Name = "SerialConnections";
            this.SerialConnections.Size = new System.Drawing.Size(121, 21);
            this.SerialConnections.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Serial Ports";
            // 
            // buttonSetPort
            // 
            this.buttonSetPort.Location = new System.Drawing.Point(207, 46);
            this.buttonSetPort.Name = "buttonSetPort";
            this.buttonSetPort.Size = new System.Drawing.Size(63, 23);
            this.buttonSetPort.TabIndex = 20;
            this.buttonSetPort.Text = "Set";
            this.buttonSetPort.UseVisualStyleBackColor = true;
            this.buttonSetPort.Click += new System.EventHandler(this.buttonSetPort_Click);
            // 
            // buttonStartServer
            // 
            this.buttonStartServer.Enabled = false;
            this.buttonStartServer.Location = new System.Drawing.Point(93, 0);
            this.buttonStartServer.Name = "buttonStartServer";
            this.buttonStartServer.Size = new System.Drawing.Size(98, 33);
            this.buttonStartServer.TabIndex = 21;
            this.buttonStartServer.Text = "Start Server";
            this.buttonStartServer.UseVisualStyleBackColor = true;
            this.buttonStartServer.Click += new System.EventHandler(this.buttonStartServer_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 594);
            this.Controls.Add(this.buttonStartServer);
            this.Controls.Add(this.buttonSetPort);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.SerialConnections);
            this.Controls.Add(this.Team2PointDisplay);
            this.Controls.Add(this.Team1PointDisplay);
            this.Controls.Add(this.Team2PointPlus);
            this.Controls.Add(this.Team1PointPlus);
            this.Controls.Add(this.team2Box);
            this.Controls.Add(this.team1Box);
            this.Controls.Add(this.buttonStopRound);
            this.Controls.Add(this.buttonStartRound);
            this.Controls.Add(this.rtbConOut);
            this.Controls.Add(this.groupBoxNames);
            this.Controls.Add(this.groupBoxScore);
            this.Name = "Form1";
            this.Text = "Server";
            this.groupBoxNames.ResumeLayout(false);
            this.groupBoxNames.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbConOut;
        private System.Windows.Forms.Button buttonStartRound;
        private System.Windows.Forms.Button buttonStopRound;
        private System.Windows.Forms.TextBox team1Box;
        private System.Windows.Forms.TextBox team2Box;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Team1PointPlus;
        private System.Windows.Forms.Button Team2PointPlus;
        private System.Windows.Forms.TextBox Team1PointDisplay;
        private System.Windows.Forms.TextBox Team2PointDisplay;
        private System.Windows.Forms.GroupBox groupBoxNames;
        private System.Windows.Forms.GroupBox groupBoxScore;
        private System.Windows.Forms.ComboBox SerialConnections;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonSetPort;
        private System.Windows.Forms.Button buttonStartServer;
    }
}

