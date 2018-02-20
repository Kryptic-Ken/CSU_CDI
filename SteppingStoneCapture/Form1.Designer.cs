namespace SteppingStoneCapture
{
    partial class CaptureForm
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showFilterFieldToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmbInterfaces = new System.Windows.Forms.ComboBox();
            this.chkTCP = new System.Windows.Forms.CheckBox();
            this.chkUDP = new System.Windows.Forms.CheckBox();
            this.chkICMP = new System.Windows.Forms.CheckBox();
            this.chkARP = new System.Windows.Forms.CheckBox();
            this.chkDNS = new System.Windows.Forms.CheckBox();
            this.txtFilterField = new System.Windows.Forms.TextBox();
            this.lblSrcIP = new System.Windows.Forms.Label();
            this.lblDestIP = new System.Windows.Forms.Label();
            this.lblSrcPort = new System.Windows.Forms.Label();
            this.lblDestPort = new System.Windows.Forms.Label();
            this.txtSrcIP = new System.Windows.Forms.TextBox();
            this.txtDestIP = new System.Windows.Forms.TextBox();
            this.txtSrcPort = new System.Windows.Forms.TextBox();
            this.txtDestPort = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblFilterField = new System.Windows.Forms.Label();
            this.lblInterfaceList = new System.Windows.Forms.Label();
            this.lblCaptureInfo = new System.Windows.Forms.Label();
            this.chkAutoScroll = new System.Windows.Forms.CheckBox();
            this.packetView = new System.Windows.Forms.ListView();
            this.packNum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TimeStamp = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SourceIP = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DestIP = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Length = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(554, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showFilterFieldToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.menuToolStripMenuItem.Text = "&Menu";
            // 
            // showFilterFieldToolStripMenuItem
            // 
            this.showFilterFieldToolStripMenuItem.Name = "showFilterFieldToolStripMenuItem";
            this.showFilterFieldToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.showFilterFieldToolStripMenuItem.Text = "Show/Hide &Filter Field";
            this.showFilterFieldToolStripMenuItem.Click += new System.EventHandler(this.showFilterFieldToolStripMenuItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // cmbInterfaces
            // 
            this.cmbInterfaces.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbInterfaces.FormattingEnabled = true;
            this.cmbInterfaces.Location = new System.Drawing.Point(9, 37);
            this.cmbInterfaces.Margin = new System.Windows.Forms.Padding(2);
            this.cmbInterfaces.Name = "cmbInterfaces";
            this.cmbInterfaces.Size = new System.Drawing.Size(230, 21);
            this.cmbInterfaces.TabIndex = 2;
            this.cmbInterfaces.SelectedIndexChanged += new System.EventHandler(this.cmbInterfaces_SelectedIndexChanged);
            // 
            // chkTCP
            // 
            this.chkTCP.AutoSize = true;
            this.chkTCP.Location = new System.Drawing.Point(9, 62);
            this.chkTCP.Margin = new System.Windows.Forms.Padding(2);
            this.chkTCP.Name = "chkTCP";
            this.chkTCP.Size = new System.Drawing.Size(47, 17);
            this.chkTCP.TabIndex = 3;
            this.chkTCP.Text = "TCP";
            this.chkTCP.UseVisualStyleBackColor = true;
            // 
            // chkUDP
            // 
            this.chkUDP.AutoSize = true;
            this.chkUDP.Location = new System.Drawing.Point(87, 62);
            this.chkUDP.Margin = new System.Windows.Forms.Padding(2);
            this.chkUDP.Name = "chkUDP";
            this.chkUDP.Size = new System.Drawing.Size(49, 17);
            this.chkUDP.TabIndex = 4;
            this.chkUDP.Text = "UDP";
            this.chkUDP.UseVisualStyleBackColor = true;
            // 
            // chkICMP
            // 
            this.chkICMP.AutoSize = true;
            this.chkICMP.Location = new System.Drawing.Point(164, 62);
            this.chkICMP.Margin = new System.Windows.Forms.Padding(2);
            this.chkICMP.Name = "chkICMP";
            this.chkICMP.Size = new System.Drawing.Size(52, 17);
            this.chkICMP.TabIndex = 5;
            this.chkICMP.Text = "ICMP";
            this.chkICMP.UseVisualStyleBackColor = true;
            // 
            // chkARP
            // 
            this.chkARP.AutoSize = true;
            this.chkARP.Location = new System.Drawing.Point(49, 84);
            this.chkARP.Margin = new System.Windows.Forms.Padding(2);
            this.chkARP.Name = "chkARP";
            this.chkARP.Size = new System.Drawing.Size(48, 17);
            this.chkARP.TabIndex = 6;
            this.chkARP.Text = "ARP";
            this.chkARP.UseVisualStyleBackColor = true;
            // 
            // chkDNS
            // 
            this.chkDNS.AutoSize = true;
            this.chkDNS.Location = new System.Drawing.Point(125, 82);
            this.chkDNS.Margin = new System.Windows.Forms.Padding(2);
            this.chkDNS.Name = "chkDNS";
            this.chkDNS.Size = new System.Drawing.Size(49, 17);
            this.chkDNS.TabIndex = 7;
            this.chkDNS.Text = "DNS";
            this.chkDNS.UseVisualStyleBackColor = true;
            // 
            // txtFilterField
            // 
            this.txtFilterField.Location = new System.Drawing.Point(9, 118);
            this.txtFilterField.Margin = new System.Windows.Forms.Padding(2);
            this.txtFilterField.Name = "txtFilterField";
            this.txtFilterField.Size = new System.Drawing.Size(230, 20);
            this.txtFilterField.TabIndex = 8;
            this.txtFilterField.Visible = false;
            // 
            // lblSrcIP
            // 
            this.lblSrcIP.AutoSize = true;
            this.lblSrcIP.Location = new System.Drawing.Point(262, 28);
            this.lblSrcIP.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSrcIP.Name = "lblSrcIP";
            this.lblSrcIP.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblSrcIP.Size = new System.Drawing.Size(57, 13);
            this.lblSrcIP.TabIndex = 9;
            this.lblSrcIP.Text = "Source IP:";
            // 
            // lblDestIP
            // 
            this.lblDestIP.AutoSize = true;
            this.lblDestIP.Location = new System.Drawing.Point(262, 48);
            this.lblDestIP.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDestIP.Name = "lblDestIP";
            this.lblDestIP.Size = new System.Drawing.Size(45, 13);
            this.lblDestIP.TabIndex = 10;
            this.lblDestIP.Text = "Dest IP:";
            // 
            // lblSrcPort
            // 
            this.lblSrcPort.AutoSize = true;
            this.lblSrcPort.Location = new System.Drawing.Point(262, 70);
            this.lblSrcPort.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSrcPort.Name = "lblSrcPort";
            this.lblSrcPort.Size = new System.Drawing.Size(66, 13);
            this.lblSrcPort.TabIndex = 11;
            this.lblSrcPort.Text = "Source Port:";
            // 
            // lblDestPort
            // 
            this.lblDestPort.AutoSize = true;
            this.lblDestPort.Location = new System.Drawing.Point(262, 91);
            this.lblDestPort.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDestPort.Name = "lblDestPort";
            this.lblDestPort.Size = new System.Drawing.Size(54, 13);
            this.lblDestPort.TabIndex = 12;
            this.lblDestPort.Text = "Dest Port:";
            // 
            // txtSrcIP
            // 
            this.txtSrcIP.Location = new System.Drawing.Point(332, 27);
            this.txtSrcIP.Margin = new System.Windows.Forms.Padding(2);
            this.txtSrcIP.Name = "txtSrcIP";
            this.txtSrcIP.Size = new System.Drawing.Size(76, 20);
            this.txtSrcIP.TabIndex = 13;
            // 
            // txtDestIP
            // 
            this.txtDestIP.Location = new System.Drawing.Point(332, 48);
            this.txtDestIP.Margin = new System.Windows.Forms.Padding(2);
            this.txtDestIP.Name = "txtDestIP";
            this.txtDestIP.Size = new System.Drawing.Size(76, 20);
            this.txtDestIP.TabIndex = 14;
            // 
            // txtSrcPort
            // 
            this.txtSrcPort.Location = new System.Drawing.Point(332, 70);
            this.txtSrcPort.Margin = new System.Windows.Forms.Padding(2);
            this.txtSrcPort.Name = "txtSrcPort";
            this.txtSrcPort.Size = new System.Drawing.Size(76, 20);
            this.txtSrcPort.TabIndex = 15;
            // 
            // txtDestPort
            // 
            this.txtDestPort.Location = new System.Drawing.Point(332, 91);
            this.txtDestPort.Margin = new System.Windows.Forms.Padding(2);
            this.txtDestPort.Name = "txtDestPort";
            this.txtDestPort.Size = new System.Drawing.Size(76, 20);
            this.txtDestPort.TabIndex = 16;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(452, 28);
            this.btnStart.Margin = new System.Windows.Forms.Padding(2);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(94, 29);
            this.btnStart.TabIndex = 17;
            this.btnStart.Text = "&Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(452, 62);
            this.btnReset.Margin = new System.Windows.Forms.Padding(2);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(94, 31);
            this.btnReset.TabIndex = 18;
            this.btnReset.Text = "&Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(452, 98);
            this.btnStop.Margin = new System.Windows.Forms.Padding(2);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(94, 31);
            this.btnStop.TabIndex = 19;
            this.btnStop.Text = "S&top";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(452, 419);
            this.btnExit.Margin = new System.Windows.Forms.Padding(2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(94, 31);
            this.btnExit.TabIndex = 21;
            this.btnExit.Text = "E&xit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(353, 419);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(94, 31);
            this.btnSave.TabIndex = 22;
            this.btnSave.Text = "Sav&e";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblFilterField
            // 
            this.lblFilterField.AutoSize = true;
            this.lblFilterField.Location = new System.Drawing.Point(97, 102);
            this.lblFilterField.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFilterField.Name = "lblFilterField";
            this.lblFilterField.Size = new System.Drawing.Size(57, 13);
            this.lblFilterField.TabIndex = 23;
            this.lblFilterField.Text = "Filter Field:";
            this.lblFilterField.Visible = false;
            // 
            // lblInterfaceList
            // 
            this.lblInterfaceList.AutoSize = true;
            this.lblInterfaceList.Location = new System.Drawing.Point(9, 23);
            this.lblInterfaceList.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblInterfaceList.Name = "lblInterfaceList";
            this.lblInterfaceList.Size = new System.Drawing.Size(71, 13);
            this.lblInterfaceList.TabIndex = 24;
            this.lblInterfaceList.Text = "Interface List:";
            // 
            // lblCaptureInfo
            // 
            this.lblCaptureInfo.AutoSize = true;
            this.lblCaptureInfo.Location = new System.Drawing.Point(9, 143);
            this.lblCaptureInfo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCaptureInfo.Name = "lblCaptureInfo";
            this.lblCaptureInfo.Size = new System.Drawing.Size(68, 13);
            this.lblCaptureInfo.TabIndex = 25;
            this.lblCaptureInfo.Text = "Capture Info:";
            // 
            // chkAutoScroll
            // 
            this.chkAutoScroll.AutoSize = true;
            this.chkAutoScroll.Location = new System.Drawing.Point(11, 414);
            this.chkAutoScroll.Margin = new System.Windows.Forms.Padding(2);
            this.chkAutoScroll.Name = "chkAutoScroll";
            this.chkAutoScroll.Size = new System.Drawing.Size(72, 17);
            this.chkAutoScroll.TabIndex = 27;
            this.chkAutoScroll.Text = "&Autoscroll";
            this.chkAutoScroll.UseVisualStyleBackColor = true;
            // 
            // packetView
            // 
            this.packetView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.packNum,
            this.TimeStamp,
            this.SourceIP,
            this.DestIP,
            this.Length});
            this.packetView.FullRowSelect = true;
            this.packetView.GridLines = true;
            this.packetView.Location = new System.Drawing.Point(9, 159);
            this.packetView.Name = "packetView";
            this.packetView.Size = new System.Drawing.Size(533, 250);
            this.packetView.TabIndex = 28;
            this.packetView.UseCompatibleStateImageBehavior = false;
            this.packetView.View = System.Windows.Forms.View.Details;
            // 
            // packNum
            // 
            this.packNum.Text = "Packet No.";
            this.packNum.Width = 70;
            // 
            // TimeStamp
            // 
            this.TimeStamp.Text = "Time Stamp";
            this.TimeStamp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TimeStamp.Width = 80;
            // 
            // SourceIP
            // 
            this.SourceIP.Text = "Source IP";
            this.SourceIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.SourceIP.Width = 100;
            // 
            // DestIP
            // 
            this.DestIP.Text = "Destination IP";
            this.DestIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.DestIP.Width = 100;
            // 
            // Length
            // 
            this.Length.Text = "Length";
            this.Length.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // CaptureForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 457);
            this.Controls.Add(this.packetView);
            this.Controls.Add(this.chkAutoScroll);
            this.Controls.Add(this.lblCaptureInfo);
            this.Controls.Add(this.lblInterfaceList);
            this.Controls.Add(this.lblFilterField);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.txtDestPort);
            this.Controls.Add(this.txtSrcPort);
            this.Controls.Add(this.txtDestIP);
            this.Controls.Add(this.txtSrcIP);
            this.Controls.Add(this.lblDestPort);
            this.Controls.Add(this.lblSrcPort);
            this.Controls.Add(this.lblDestIP);
            this.Controls.Add(this.lblSrcIP);
            this.Controls.Add(this.txtFilterField);
            this.Controls.Add(this.chkDNS);
            this.Controls.Add(this.chkARP);
            this.Controls.Add(this.chkICMP);
            this.Controls.Add(this.chkUDP);
            this.Controls.Add(this.chkTCP);
            this.Controls.Add(this.cmbInterfaces);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "CaptureForm";
            this.Text = "Capture Window";
            this.Load += new System.EventHandler(this.CaptureForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem showFilterFieldToolStripMenuItem;
        private System.Windows.Forms.ComboBox cmbInterfaces;
        private System.Windows.Forms.CheckBox chkTCP;
        private System.Windows.Forms.CheckBox chkUDP;
        private System.Windows.Forms.CheckBox chkICMP;
        private System.Windows.Forms.CheckBox chkARP;
        private System.Windows.Forms.CheckBox chkDNS;
        private System.Windows.Forms.TextBox txtFilterField;
        private System.Windows.Forms.Label lblSrcIP;
        private System.Windows.Forms.Label lblDestIP;
        private System.Windows.Forms.Label lblSrcPort;
        private System.Windows.Forms.Label lblDestPort;
        private System.Windows.Forms.TextBox txtSrcIP;
        private System.Windows.Forms.TextBox txtDestIP;
        private System.Windows.Forms.TextBox txtSrcPort;
        private System.Windows.Forms.TextBox txtDestPort;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblFilterField;
        private System.Windows.Forms.Label lblInterfaceList;
        private System.Windows.Forms.Label lblCaptureInfo;
        private System.Windows.Forms.CheckBox chkAutoScroll;
        private System.Windows.Forms.ListView packetView;
        private System.Windows.Forms.ColumnHeader packNum;
        private System.Windows.Forms.ColumnHeader TimeStamp;
        private System.Windows.Forms.ColumnHeader SourceIP;
        private System.Windows.Forms.ColumnHeader DestIP;
        private System.Windows.Forms.ColumnHeader Length;
    }
}

