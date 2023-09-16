namespace CaptureX.Uploader
{
    partial class MainForm
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            SourceDirectorylabel = new Label();
            SourceFileBrwoserButton = new Button();
            SettingGroupBox = new GroupBox();
            label8 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            dateTimePicker2 = new DateTimePicker();
            dateTimePicker1 = new DateTimePicker();
            LogDirectoryBrwoserButton = new Button();
            LogDirectoryLabel = new Label();
            label7 = new Label();
            DestinationDirectoryLabel = new Label();
            DestinationFileBrwoserButton = new Button();
            groupBox2 = new GroupBox();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            ClinicPasswordTextBox = new TextBox();
            ClinicUsernameTextBox = new TextBox();
            ClinicAETitleTextBox = new TextBox();
            TestConnectionButton = new Button();
            SendButton = new Button();
            StatusPanel = new Panel();
            progressBar = new ProgressBar();
            MessageLabel = new Label();
            StopButton = new Button();
            SentFilesLabel = new Label();
            SentFilesCountLabel = new Label();
            SendCounterLabel = new Label();
            notifyIcon1 = new NotifyIcon(components);
            contextMenuStrip1 = new ContextMenuStrip(components);
            showToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            progressBarForFileUpload = new ProgressBar();
            lblAll = new Label();
            lblAllValue = new Label();
            label10 = new Label();
            lblRemainValue = new Label();
            lblRemain = new Label();
            lblDone = new Label();
            lblDoneValue = new Label();
            SettingGroupBox.SuspendLayout();
            groupBox2.SuspendLayout();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // SourceDirectorylabel
            // 
            SourceDirectorylabel.AutoSize = true;
            SourceDirectorylabel.Location = new Point(9, 95);
            SourceDirectorylabel.Name = "SourceDirectorylabel";
            SourceDirectorylabel.Size = new Size(57, 20);
            SourceDirectorylabel.TabIndex = 0;
            SourceDirectorylabel.Text = "Source:";
            // 
            // SourceFileBrwoserButton
            // 
            SourceFileBrwoserButton.Location = new Point(591, 91);
            SourceFileBrwoserButton.Name = "SourceFileBrwoserButton";
            SourceFileBrwoserButton.Size = new Size(94, 29);
            SourceFileBrwoserButton.TabIndex = 1;
            SourceFileBrwoserButton.Text = "Change";
            SourceFileBrwoserButton.UseVisualStyleBackColor = true;
            SourceFileBrwoserButton.Click += SourceFileBrwoserButton_Click;
            // 
            // SettingGroupBox
            // 
            SettingGroupBox.Controls.Add(label8);
            SettingGroupBox.Controls.Add(label3);
            SettingGroupBox.Controls.Add(label2);
            SettingGroupBox.Controls.Add(label1);
            SettingGroupBox.Controls.Add(dateTimePicker2);
            SettingGroupBox.Controls.Add(dateTimePicker1);
            SettingGroupBox.Controls.Add(LogDirectoryBrwoserButton);
            SettingGroupBox.Controls.Add(LogDirectoryLabel);
            SettingGroupBox.Controls.Add(label7);
            SettingGroupBox.Controls.Add(DestinationDirectoryLabel);
            SettingGroupBox.Controls.Add(DestinationFileBrwoserButton);
            SettingGroupBox.Controls.Add(SourceDirectorylabel);
            SettingGroupBox.Controls.Add(SourceFileBrwoserButton);
            SettingGroupBox.Location = new Point(11, 211);
            SettingGroupBox.Name = "SettingGroupBox";
            SettingGroupBox.Size = new Size(691, 196);
            SettingGroupBox.TabIndex = 2;
            SettingGroupBox.TabStop = false;
            SettingGroupBox.Text = "Local Settings";
            SettingGroupBox.Enter += SettingGroupBox_Enter;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(419, 23);
            label8.Name = "label8";
            label8.Size = new Size(0, 20);
            label8.TabIndex = 18;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(413, 23);
            label3.Name = "label3";
            label3.Size = new Size(0, 20);
            label3.TabIndex = 16;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(264, 71);
            label2.Name = "label2";
            label2.Size = new Size(28, 20);
            label2.TabIndex = 17;
            label2.Text = "To:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 69);
            label1.Name = "label1";
            label1.Size = new Size(46, 20);
            label1.TabIndex = 16;
            label1.Text = "From:";
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.CustomFormat = "yyyy-MM-dd";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.Location = new Point(298, 64);
            dateTimePicker2.Margin = new Padding(3, 4, 3, 4);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(110, 27);
            dateTimePicker2.TabIndex = 8;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.CustomFormat = "yyyy-MM-dd";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.Location = new Point(64, 64);
            dateTimePicker1.Margin = new Padding(3, 4, 3, 4);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(111, 27);
            dateTimePicker1.TabIndex = 7;
            // 
            // LogDirectoryBrwoserButton
            // 
            LogDirectoryBrwoserButton.Location = new Point(591, 161);
            LogDirectoryBrwoserButton.Name = "LogDirectoryBrwoserButton";
            LogDirectoryBrwoserButton.Size = new Size(94, 29);
            LogDirectoryBrwoserButton.TabIndex = 6;
            LogDirectoryBrwoserButton.Text = "Change";
            LogDirectoryBrwoserButton.UseVisualStyleBackColor = true;
            LogDirectoryBrwoserButton.Click += LogDirectoryBrwoserButton_Click;
            // 
            // LogDirectoryLabel
            // 
            LogDirectoryLabel.AutoSize = true;
            LogDirectoryLabel.Location = new Point(9, 165);
            LogDirectoryLabel.Name = "LogDirectoryLabel";
            LogDirectoryLabel.Size = new Size(102, 20);
            LogDirectoryLabel.TabIndex = 5;
            LogDirectoryLabel.Text = "Log Directory:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(6, 23);
            label7.Name = "label7";
            label7.Size = new Size(411, 20);
            label7.TabIndex = 4;
            label7.Text = "Please choose your local Source and Destination folders first:";
            // 
            // DestinationDirectoryLabel
            // 
            DestinationDirectoryLabel.AutoSize = true;
            DestinationDirectoryLabel.Location = new Point(9, 131);
            DestinationDirectoryLabel.Name = "DestinationDirectoryLabel";
            DestinationDirectoryLabel.Size = new Size(88, 20);
            DestinationDirectoryLabel.TabIndex = 2;
            DestinationDirectoryLabel.Text = "Destination:";
            // 
            // DestinationFileBrwoserButton
            // 
            DestinationFileBrwoserButton.Location = new Point(591, 127);
            DestinationFileBrwoserButton.Name = "DestinationFileBrwoserButton";
            DestinationFileBrwoserButton.Size = new Size(94, 29);
            DestinationFileBrwoserButton.TabIndex = 3;
            DestinationFileBrwoserButton.Text = "Change";
            DestinationFileBrwoserButton.UseVisualStyleBackColor = true;
            DestinationFileBrwoserButton.Click += DestinationFileBrwoserButton_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(ClinicPasswordTextBox);
            groupBox2.Controls.Add(ClinicUsernameTextBox);
            groupBox2.Controls.Add(ClinicAETitleTextBox);
            groupBox2.Location = new Point(18, 27);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(350, 168);
            groupBox2.TabIndex = 6;
            groupBox2.TabStop = false;
            groupBox2.Text = "Clinic Settings";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(30, 99);
            label4.Name = "label4";
            label4.Size = new Size(75, 20);
            label4.TabIndex = 5;
            label4.Text = "Passwortd";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(30, 67);
            label5.Name = "label5";
            label5.Size = new Size(75, 20);
            label5.TabIndex = 4;
            label5.Text = "Username";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(30, 33);
            label6.Name = "label6";
            label6.Size = new Size(56, 20);
            label6.TabIndex = 3;
            label6.Text = "AETitle";
            // 
            // ClinicPasswordTextBox
            // 
            ClinicPasswordTextBox.Location = new Point(144, 92);
            ClinicPasswordTextBox.Name = "ClinicPasswordTextBox";
            ClinicPasswordTextBox.Size = new Size(139, 27);
            ClinicPasswordTextBox.TabIndex = 2;
            ClinicPasswordTextBox.UseSystemPasswordChar = true;
            // 
            // ClinicUsernameTextBox
            // 
            ClinicUsernameTextBox.Location = new Point(144, 59);
            ClinicUsernameTextBox.Name = "ClinicUsernameTextBox";
            ClinicUsernameTextBox.Size = new Size(139, 27);
            ClinicUsernameTextBox.TabIndex = 1;
            ClinicUsernameTextBox.UseSystemPasswordChar = true;
            // 
            // ClinicAETitleTextBox
            // 
            ClinicAETitleTextBox.Location = new Point(144, 27);
            ClinicAETitleTextBox.Name = "ClinicAETitleTextBox";
            ClinicAETitleTextBox.Size = new Size(139, 27);
            ClinicAETitleTextBox.TabIndex = 0;
            // 
            // TestConnectionButton
            // 
            TestConnectionButton.BackColor = Color.FromArgb(224, 224, 224);
            TestConnectionButton.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            TestConnectionButton.Location = new Point(11, 479);
            TestConnectionButton.Name = "TestConnectionButton";
            TestConnectionButton.Size = new Size(191, 79);
            TestConnectionButton.TabIndex = 7;
            TestConnectionButton.Text = "Connect";
            TestConnectionButton.UseVisualStyleBackColor = false;
            TestConnectionButton.Click += TestConnectionButton_Click;
            // 
            // SendButton
            // 
            SendButton.BackColor = SystemColors.Control;
            SendButton.Enabled = false;
            SendButton.Location = new Point(213, 479);
            SendButton.Name = "SendButton";
            SendButton.Size = new Size(206, 79);
            SendButton.TabIndex = 8;
            SendButton.Text = "Start Sending";
            SendButton.UseVisualStyleBackColor = false;
            SendButton.Click += SendButton_Click;
            // 
            // StatusPanel
            // 
            StatusPanel.BackColor = SystemColors.AppWorkspace;
            StatusPanel.Location = new Point(622, 479);
            StatusPanel.Name = "StatusPanel";
            StatusPanel.Size = new Size(81, 79);
            StatusPanel.TabIndex = 9;
            // 
            // progressBar
            // 
            progressBar.Location = new Point(11, 413);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(691, 29);
            progressBar.TabIndex = 10;
            progressBar.Visible = false;
            // 
            // MessageLabel
            // 
            MessageLabel.AutoSize = true;
            MessageLabel.ForeColor = Color.Red;
            MessageLabel.Location = new Point(11, 501);
            MessageLabel.Name = "MessageLabel";
            MessageLabel.Size = new Size(0, 20);
            MessageLabel.TabIndex = 11;
            // 
            // StopButton
            // 
            StopButton.Enabled = false;
            StopButton.Location = new Point(424, 479);
            StopButton.Name = "StopButton";
            StopButton.Size = new Size(191, 79);
            StopButton.TabIndex = 12;
            StopButton.Text = "Stop Sending";
            StopButton.UseVisualStyleBackColor = true;
            StopButton.Click += StopButton_Click;
            // 
            // SentFilesLabel
            // 
            SentFilesLabel.AutoSize = true;
            SentFilesLabel.Location = new Point(16, 450);
            SentFilesLabel.Name = "SentFilesLabel";
            SentFilesLabel.Size = new Size(72, 20);
            SentFilesLabel.TabIndex = 13;
            SentFilesLabel.Text = "Sent files:";
            // 
            // SentFilesCountLabel
            // 
            SentFilesCountLabel.AutoSize = true;
            SentFilesCountLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            SentFilesCountLabel.Location = new Point(94, 450);
            SentFilesCountLabel.Name = "SentFilesCountLabel";
            SentFilesCountLabel.Size = new Size(0, 20);
            SentFilesCountLabel.TabIndex = 14;
            // 
            // SendCounterLabel
            // 
            SendCounterLabel.AutoSize = true;
            SendCounterLabel.Font = new Font("Segoe UI", 30F, FontStyle.Regular, GraphicsUnit.Point);
            SendCounterLabel.ForeColor = Color.Green;
            SendCounterLabel.Location = new Point(559, 27);
            SendCounterLabel.Name = "SendCounterLabel";
            SendCounterLabel.Size = new Size(56, 67);
            SendCounterLabel.TabIndex = 15;
            SendCounterLabel.Text = "0";
            // 
            // notifyIcon1
            // 
            notifyIcon1.ContextMenuStrip = contextMenuStrip1;
            notifyIcon1.Icon = (Icon)resources.GetObject("notifyIcon1.Icon");
            notifyIcon1.Text = "CaptureX.Uploader";
            notifyIcon1.Visible = true;
            notifyIcon1.MouseDoubleClick += notifyIcon1_MouseDoubleClick;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { showToolStripMenuItem, exitToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(115, 52);
            // 
            // showToolStripMenuItem
            // 
            showToolStripMenuItem.Name = "showToolStripMenuItem";
            showToolStripMenuItem.Size = new Size(114, 24);
            showToolStripMenuItem.Text = "Show";
            showToolStripMenuItem.Click += showToolStripMenuItem_Click;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(114, 24);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // progressBarForFileUpload
            // 
            progressBarForFileUpload.Location = new Point(374, 164);
            progressBarForFileUpload.Margin = new Padding(3, 4, 3, 4);
            progressBarForFileUpload.Name = "progressBarForFileUpload";
            progressBarForFileUpload.Size = new Size(328, 31);
            progressBarForFileUpload.TabIndex = 16;
            // 
            // lblAll
            // 
            lblAll.AutoSize = true;
            lblAll.Location = new Point(374, 140);
            lblAll.Name = "lblAll";
            lblAll.Size = new Size(30, 20);
            lblAll.TabIndex = 17;
            lblAll.Text = "All:";
            // 
            // lblAllValue
            // 
            lblAllValue.AutoSize = true;
            lblAllValue.Location = new Point(410, 140);
            lblAllValue.Name = "lblAllValue";
            lblAllValue.Size = new Size(17, 20);
            lblAllValue.TabIndex = 18;
            lblAllValue.Text = "0";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(1361, 416);
            label10.Name = "label10";
            label10.Size = new Size(58, 20);
            label10.TabIndex = 19;
            label10.Text = "label10";
            // 
            // lblRemainValue
            // 
            lblRemainValue.AutoSize = true;
            lblRemainValue.Location = new Point(556, 140);
            lblRemainValue.Name = "lblRemainValue";
            lblRemainValue.Size = new Size(17, 20);
            lblRemainValue.TabIndex = 21;
            lblRemainValue.Text = "0";
            // 
            // lblRemain
            // 
            lblRemain.AutoSize = true;
            lblRemain.Location = new Point(488, 140);
            lblRemain.Name = "lblRemain";
            lblRemain.Size = new Size(62, 20);
            lblRemain.TabIndex = 20;
            lblRemain.Text = "Remain:";
            // 
            // lblDone
            // 
            lblDone.AutoSize = true;
            lblDone.Location = new Point(622, 140);
            lblDone.Name = "lblDone";
            lblDone.Size = new Size(48, 20);
            lblDone.TabIndex = 22;
            lblDone.Text = "Done:";
            // 
            // lblDoneValue
            // 
            lblDoneValue.AutoSize = true;
            lblDoneValue.Location = new Point(676, 140);
            lblDoneValue.Name = "lblDoneValue";
            lblDoneValue.Size = new Size(17, 20);
            lblDoneValue.TabIndex = 23;
            lblDoneValue.Text = "0";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.Zoom;
            ClientSize = new Size(725, 585);
            Controls.Add(lblDoneValue);
            Controls.Add(lblDone);
            Controls.Add(lblRemainValue);
            Controls.Add(lblRemain);
            Controls.Add(label10);
            Controls.Add(lblAllValue);
            Controls.Add(lblAll);
            Controls.Add(progressBarForFileUpload);
            Controls.Add(SendCounterLabel);
            Controls.Add(SentFilesCountLabel);
            Controls.Add(SentFilesLabel);
            Controls.Add(StopButton);
            Controls.Add(MessageLabel);
            Controls.Add(progressBar);
            Controls.Add(StatusPanel);
            Controls.Add(SendButton);
            Controls.Add(TestConnectionButton);
            Controls.Add(groupBox2);
            Controls.Add(SettingGroupBox);
            DoubleBuffered = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CaptuerX Uploader";
            FormClosing += MainForm_FormClosing;
            Load += MainForm_Load;
            SizeChanged += MainForm_SizeChanged;
            SettingGroupBox.ResumeLayout(false);
            SettingGroupBox.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label SourceDirectorylabel;
        private Button SourceFileBrwoserButton;
        private GroupBox SettingGroupBox;
        private Label DestinationDirectoryLabel;
        private Button DestinationFileBrwoserButton;
        private GroupBox groupBox2;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox ClinicPasswordTextBox;
        private TextBox ClinicUsernameTextBox;
        private TextBox ClinicAETitleTextBox;
        private Button TestConnectionButton;
        private Button SendButton;
        private Panel StatusPanel;
        private ProgressBar progressBar;
        private Label MessageLabel;
        private Button StopButton;
        private Label SentFilesLabel;
        private Label SentFilesCountLabel;
        private Label label7;
        private Label LogDirectoryLabel;
        private Button LogDirectoryBrwoserButton;
        private Label SendCounterLabel;
        private NotifyIcon notifyIcon1;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem showToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private DateTimePicker dateTimePicker2;
        private DateTimePicker dateTimePicker1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label8;
        private ProgressBar progressBarForFileUpload;
        private Label lblAll;
        private Label lblAllValue;
        private Label label10;
        private Label lblRemainValue;
        private Label lblRemain;
        private Label lblDone; 
        private Label lblDoneValue;
    }
}