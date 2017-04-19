namespace Campbell_James.CPSC_2253.Final_Project
{
    partial class RobotGameClient
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
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxIP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboTeams = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.labelOpScore = new System.Windows.Forms.Label();
            this.labelYouScore = new System.Windows.Forms.Label();
            this.labelTeam = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.labelConnection = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelServoPos = new System.Windows.Forms.Label();
            this.buttonServoDown = new System.Windows.Forms.Button();
            this.buttonServoUp = new System.Windows.Forms.Button();
            this.homeTeamList = new System.Windows.Forms.ListBox();
            this.awayTeamList = new System.Windows.Forms.ListBox();
            this.groupBoxYourTeam = new System.Windows.Forms.GroupBox();
            this.groupBoxOtherTeam = new System.Windows.Forms.GroupBox();
            this.ServerMSG = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(239, 13);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(100, 20);
            this.textBoxName.TabIndex = 1;
            // 
            // textBoxIP
            // 
            this.textBoxIP.Location = new System.Drawing.Point(61, 13);
            this.textBoxIP.Name = "textBoxIP";
            this.textBoxIP.Size = new System.Drawing.Size(100, 20);
            this.textBoxIP.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Server IP:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(165, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Player Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(343, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Team:";
            // 
            // comboTeams
            // 
            this.comboTeams.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboTeams.FormattingEnabled = true;
            this.comboTeams.Location = new System.Drawing.Point(384, 12);
            this.comboTeams.Name = "comboTeams";
            this.comboTeams.Size = new System.Drawing.Size(98, 21);
            this.comboTeams.TabIndex = 2;
            this.comboTeams.SelectionChangeCommitted += new System.EventHandler(this.comboTeams_SelectionChangeCommitted);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonConnect);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.labelOpScore);
            this.groupBox1.Controls.Add(this.labelYouScore);
            this.groupBox1.Controls.Add(this.comboTeams);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.labelTeam);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.labelConnection);
            this.groupBox1.Controls.Add(this.textBoxIP);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textBoxName);
            this.groupBox1.Location = new System.Drawing.Point(12, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(571, 64);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Info";
            // 
            // buttonConnect
            // 
            this.buttonConnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.buttonConnect.Location = new System.Drawing.Point(488, 13);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(77, 45);
            this.buttonConnect.TabIndex = 3;
            this.buttonConnect.Text = "Connect To Server";
            this.buttonConnect.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(407, 38);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Opponent:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(353, 38);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(29, 13);
            this.label12.TabIndex = 12;
            this.label12.Text = "You:";
            // 
            // labelOpScore
            // 
            this.labelOpScore.AutoSize = true;
            this.labelOpScore.Location = new System.Drawing.Point(464, 38);
            this.labelOpScore.Name = "labelOpScore";
            this.labelOpScore.Size = new System.Drawing.Size(13, 13);
            this.labelOpScore.TabIndex = 17;
            this.labelOpScore.Text = "0";
            // 
            // labelYouScore
            // 
            this.labelYouScore.AutoSize = true;
            this.labelYouScore.Location = new System.Drawing.Point(388, 38);
            this.labelYouScore.Name = "labelYouScore";
            this.labelYouScore.Size = new System.Drawing.Size(13, 13);
            this.labelYouScore.TabIndex = 10;
            this.labelYouScore.Text = "0";
            // 
            // labelTeam
            // 
            this.labelTeam.AutoSize = true;
            this.labelTeam.ForeColor = System.Drawing.Color.Red;
            this.labelTeam.Location = new System.Drawing.Point(251, 38);
            this.labelTeam.Name = "labelTeam";
            this.labelTeam.Size = new System.Drawing.Size(73, 13);
            this.labelTeam.TabIndex = 15;
            this.labelTeam.Text = "Disconnected";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(215, 38);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Team:";
            // 
            // labelConnection
            // 
            this.labelConnection.AutoSize = true;
            this.labelConnection.ForeColor = System.Drawing.Color.Red;
            this.labelConnection.Location = new System.Drawing.Point(69, 38);
            this.labelConnection.Name = "labelConnection";
            this.labelConnection.Size = new System.Drawing.Size(73, 13);
            this.labelConnection.TabIndex = 13;
            this.labelConnection.Text = "Disconnected";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Connection: ";
            // 
            // labelServoPos
            // 
            this.labelServoPos.Enabled = false;
            this.labelServoPos.Font = new System.Drawing.Font("Microsoft Sans Serif", 150F);
            this.labelServoPos.Location = new System.Drawing.Point(12, 86);
            this.labelServoPos.Name = "labelServoPos";
            this.labelServoPos.Size = new System.Drawing.Size(591, 272);
            this.labelServoPos.TabIndex = 0;
            this.labelServoPos.Text = "90";
            this.labelServoPos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonServoDown
            // 
            this.buttonServoDown.Enabled = false;
            this.buttonServoDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            this.buttonServoDown.Location = new System.Drawing.Point(12, 361);
            this.buttonServoDown.Name = "buttonServoDown";
            this.buttonServoDown.Size = new System.Drawing.Size(214, 68);
            this.buttonServoDown.TabIndex = 4;
            this.buttonServoDown.Text = "-";
            this.buttonServoDown.UseVisualStyleBackColor = true;
            this.buttonServoDown.Click += new System.EventHandler(this.buttonServoDown_Click);
            // 
            // buttonServoUp
            // 
            this.buttonServoUp.Enabled = false;
            this.buttonServoUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            this.buttonServoUp.Location = new System.Drawing.Point(369, 361);
            this.buttonServoUp.Name = "buttonServoUp";
            this.buttonServoUp.Size = new System.Drawing.Size(214, 68);
            this.buttonServoUp.TabIndex = 5;
            this.buttonServoUp.Text = "+";
            this.buttonServoUp.UseVisualStyleBackColor = true;
            this.buttonServoUp.Click += new System.EventHandler(this.buttonServoUp_Click);
            // 
            // homeTeamList
            // 
            this.homeTeamList.FormattingEnabled = true;
            this.homeTeamList.Location = new System.Drawing.Point(12, 448);
            this.homeTeamList.Name = "homeTeamList";
            this.homeTeamList.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.homeTeamList.Size = new System.Drawing.Size(266, 186);
            this.homeTeamList.TabIndex = 12;
            this.homeTeamList.TabStop = false;
            // 
            // awayTeamList
            // 
            this.awayTeamList.FormattingEnabled = true;
            this.awayTeamList.Location = new System.Drawing.Point(317, 448);
            this.awayTeamList.Name = "awayTeamList";
            this.awayTeamList.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.awayTeamList.Size = new System.Drawing.Size(266, 186);
            this.awayTeamList.TabIndex = 13;
            this.awayTeamList.TabStop = false;
            // 
            // groupBoxYourTeam
            // 
            this.groupBoxYourTeam.Location = new System.Drawing.Point(12, 430);
            this.groupBoxYourTeam.Name = "groupBoxYourTeam";
            this.groupBoxYourTeam.Size = new System.Drawing.Size(265, 203);
            this.groupBoxYourTeam.TabIndex = 14;
            this.groupBoxYourTeam.TabStop = false;
            this.groupBoxYourTeam.Text = "Your Team";
            // 
            // groupBoxOtherTeam
            // 
            this.groupBoxOtherTeam.Location = new System.Drawing.Point(317, 430);
            this.groupBoxOtherTeam.Name = "groupBoxOtherTeam";
            this.groupBoxOtherTeam.Size = new System.Drawing.Size(266, 203);
            this.groupBoxOtherTeam.TabIndex = 0;
            this.groupBoxOtherTeam.TabStop = false;
            this.groupBoxOtherTeam.Text = "Other Team";
            // 
            // ServerMSG
            // 
            this.ServerMSG.Location = new System.Drawing.Point(12, 63);
            this.ServerMSG.Name = "ServerMSG";
            this.ServerMSG.ReadOnly = true;
            this.ServerMSG.Size = new System.Drawing.Size(571, 20);
            this.ServerMSG.TabIndex = 15;
            this.ServerMSG.TabStop = false;
            this.ServerMSG.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ServerMSG.Enter += new System.EventHandler(this.ServerMSG_Enter);
            // 
            // RobotGameClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(595, 646);
            this.Controls.Add(this.ServerMSG);
            this.Controls.Add(this.awayTeamList);
            this.Controls.Add(this.homeTeamList);
            this.Controls.Add(this.buttonServoUp);
            this.Controls.Add(this.buttonServoDown);
            this.Controls.Add(this.labelServoPos);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBoxYourTeam);
            this.Controls.Add(this.groupBoxOtherTeam);
            this.Name = "RobotGameClient";
            this.Text = "Client";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxIP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboTeams;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelTeam;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labelConnection;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelOpScore;
        private System.Windows.Forms.Label labelYouScore;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label labelServoPos;
        private System.Windows.Forms.Button buttonServoDown;
        private System.Windows.Forms.Button buttonServoUp;
        private System.Windows.Forms.ListBox homeTeamList;
        private System.Windows.Forms.ListBox awayTeamList;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.GroupBox groupBoxYourTeam;
        private System.Windows.Forms.GroupBox groupBoxOtherTeam;
        private System.Windows.Forms.TextBox ServerMSG;
    }
}

