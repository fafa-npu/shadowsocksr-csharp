namespace Shadowsocks.View
{
    partial class ConfigForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.panel2 = new System.Windows.Forms.Panel();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.AddButton = new System.Windows.Forms.Button();
            this.PictureQRcode = new System.Windows.Forms.PictureBox();
            this.ServersListBox = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.ServerGroupBox = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ObfsCombo = new System.Windows.Forms.ComboBox();
            this.labelObfs = new System.Windows.Forms.Label();
            this.ServerPortLabel = new System.Windows.Forms.Label();
            this.IPTextBox = new System.Windows.Forms.TextBox();
            this.NumServerPort = new System.Windows.Forms.NumericUpDown();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.EncryptionLabel = new System.Windows.Forms.Label();
            this.EncryptionSelect = new System.Windows.Forms.ComboBox();
            this.TextLink = new System.Windows.Forms.TextBox();
            this.RemarksTextBox = new System.Windows.Forms.TextBox();
            this.ObfsUDPLabel = new System.Windows.Forms.Label();
            this.CheckObfsUDP = new System.Windows.Forms.CheckBox();
            this.TCPProtocolLabel = new System.Windows.Forms.Label();
            this.UDPoverTCPLabel = new System.Windows.Forms.Label();
            this.CheckUDPoverUDP = new System.Windows.Forms.CheckBox();
            this.LabelNote = new System.Windows.Forms.Label();
            this.PasswordLabel = new System.Windows.Forms.CheckBox();
            this.TCPoverUDPLabel = new System.Windows.Forms.Label();
            this.CheckTCPoverUDP = new System.Windows.Forms.CheckBox();
            this.TCPProtocolComboBox = new System.Windows.Forms.ComboBox();
            this.labelObfsParam = new System.Windows.Forms.Label();
            this.TextObfsParam = new System.Windows.Forms.TextBox();
            this.labelGroup = new System.Windows.Forms.Label();
            this.TextGroup = new System.Windows.Forms.TextBox();
            this.checkAdvSetting = new System.Windows.Forms.CheckBox();
            this.labelUDPPort = new System.Windows.Forms.Label();
            this.NumUDPPort = new System.Windows.Forms.NumericUpDown();
            this.checkSSRLink = new System.Windows.Forms.CheckBox();
            this.labelRemarks = new System.Windows.Forms.Label();
            this.labelProtocolParam = new System.Windows.Forms.Label();
            this.TextProtocolParam = new System.Windows.Forms.TextBox();
            this.IPLabel = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.DownButton = new System.Windows.Forms.Button();
            this.UpButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.MyCancelButton = new System.Windows.Forms.Button();
            this.OKButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PictureQRcode)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.ServerGroupBox.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumServerPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumUDPPort)).BeginInit();
            this.tableLayoutPanel7.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel2.AutoSize = true;
            this.panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel2.Location = new System.Drawing.Point(237, 200);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(0, 0);
            this.panel2.TabIndex = 1;
            // 
            // DeleteButton
            // 
            this.DeleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DeleteButton.Location = new System.Drawing.Point(93, 0);
            this.DeleteButton.Margin = new System.Windows.Forms.Padding(0);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(86, 34);
            this.DeleteButton.TabIndex = 2;
            this.DeleteButton.Text = "&Delete";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(0, 0);
            this.AddButton.Margin = new System.Windows.Forms.Padding(0);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(86, 34);
            this.AddButton.TabIndex = 1;
            this.AddButton.Text = "&Add";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // PictureQRcode
            // 
            this.PictureQRcode.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PictureQRcode.BackColor = System.Drawing.SystemColors.Control;
            this.PictureQRcode.Location = new System.Drawing.Point(4, 154);
            this.PictureQRcode.Margin = new System.Windows.Forms.Padding(4);
            this.PictureQRcode.Name = "PictureQRcode";
            this.PictureQRcode.Size = new System.Drawing.Size(260, 200);
            this.PictureQRcode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PictureQRcode.TabIndex = 13;
            this.PictureQRcode.TabStop = false;
            // 
            // ServersListBox
            // 
            this.ServersListBox.ItemHeight = 16;
            this.ServersListBox.Location = new System.Drawing.Point(0, 0);
            this.ServersListBox.Margin = new System.Windows.Forms.Padding(0);
            this.ServersListBox.Name = "ServersListBox";
            this.ServersListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.ServersListBox.Size = new System.Drawing.Size(179, 292);
            this.ServersListBox.TabIndex = 0;
            this.ServersListBox.SelectedIndexChanged += new System.EventHandler(this.ServersListBox_SelectedIndexChanged);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.ServerGroupBox, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel7, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel5, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 1, 1);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(12, 13);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(848, 557);
            this.tableLayoutPanel2.TabIndex = 7;
            // 
            // ServerGroupBox
            // 
            this.ServerGroupBox.AutoSize = true;
            this.ServerGroupBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ServerGroupBox.Controls.Add(this.tableLayoutPanel1);
            this.ServerGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ServerGroupBox.Location = new System.Drawing.Point(197, 0);
            this.ServerGroupBox.Margin = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.ServerGroupBox.Name = "ServerGroupBox";
            this.ServerGroupBox.Size = new System.Drawing.Size(368, 514);
            this.ServerGroupBox.TabIndex = 20;
            this.ServerGroupBox.TabStop = false;
            this.ServerGroupBox.Text = "Server";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.ObfsCombo, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.labelObfs, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.ServerPortLabel, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.IPTextBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.NumServerPort, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.PasswordTextBox, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.EncryptionLabel, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.EncryptionSelect, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.TextLink, 1, 11);
            this.tableLayoutPanel1.Controls.Add(this.RemarksTextBox, 1, 9);
            this.tableLayoutPanel1.Controls.Add(this.ObfsUDPLabel, 0, 16);
            this.tableLayoutPanel1.Controls.Add(this.CheckObfsUDP, 1, 16);
            this.tableLayoutPanel1.Controls.Add(this.TCPProtocolLabel, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.UDPoverTCPLabel, 0, 15);
            this.tableLayoutPanel1.Controls.Add(this.CheckUDPoverUDP, 1, 15);
            this.tableLayoutPanel1.Controls.Add(this.LabelNote, 1, 12);
            this.tableLayoutPanel1.Controls.Add(this.PasswordLabel, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.TCPoverUDPLabel, 0, 14);
            this.tableLayoutPanel1.Controls.Add(this.CheckTCPoverUDP, 1, 14);
            this.tableLayoutPanel1.Controls.Add(this.TCPProtocolComboBox, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.labelObfsParam, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.TextObfsParam, 1, 8);
            this.tableLayoutPanel1.Controls.Add(this.labelGroup, 0, 10);
            this.tableLayoutPanel1.Controls.Add(this.TextGroup, 1, 10);
            this.tableLayoutPanel1.Controls.Add(this.checkAdvSetting, 0, 12);
            this.tableLayoutPanel1.Controls.Add(this.labelUDPPort, 0, 13);
            this.tableLayoutPanel1.Controls.Add(this.NumUDPPort, 1, 13);
            this.tableLayoutPanel1.Controls.Add(this.checkSSRLink, 0, 11);
            this.tableLayoutPanel1.Controls.Add(this.labelRemarks, 0, 9);
            this.tableLayoutPanel1.Controls.Add(this.labelProtocolParam, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.TextProtocolParam, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.IPLabel, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(8, 30);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(3, 1, 3, 3);
            this.tableLayoutPanel1.RowCount = 18;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(357, 466);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // ObfsCombo
            // 
            this.ObfsCombo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ObfsCombo.FormattingEnabled = true;
            this.ObfsCombo.Items.AddRange(new object[] {
            "plain",
            "http_simple",
            "http_post",
            "random_head",
            "tls1.2_ticket_auth",
            "tls1.2_ticket_fastauth"});
            this.ObfsCombo.Location = new System.Drawing.Point(118, 184);
            this.ObfsCombo.Margin = new System.Windows.Forms.Padding(3, 3, 3, 7);
            this.ObfsCombo.Name = "ObfsCombo";
            this.ObfsCombo.Size = new System.Drawing.Size(233, 24);
            this.ObfsCombo.TabIndex = 19;
            this.ObfsCombo.TextChanged += new System.EventHandler(this.ObfsCombo_TextChanged);
            // 
            // labelObfs
            // 
            this.labelObfs.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelObfs.AutoSize = true;
            this.labelObfs.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.labelObfs.Location = new System.Drawing.Point(74, 189);
            this.labelObfs.Name = "labelObfs";
            this.labelObfs.Size = new System.Drawing.Size(38, 17);
            this.labelObfs.TabIndex = 18;
            this.labelObfs.Text = "Obfs";
            // 
            // ServerPortLabel
            // 
            this.ServerPortLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.ServerPortLabel.AutoSize = true;
            this.ServerPortLabel.Location = new System.Drawing.Point(32, 34);
            this.ServerPortLabel.Name = "ServerPortLabel";
            this.ServerPortLabel.Size = new System.Drawing.Size(80, 17);
            this.ServerPortLabel.TabIndex = 8;
            this.ServerPortLabel.Text = "Server Port";
            // 
            // IPTextBox
            // 
            this.IPTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.IPTextBox.Location = new System.Drawing.Point(118, 4);
            this.IPTextBox.MaxLength = 512;
            this.IPTextBox.Name = "IPTextBox";
            this.IPTextBox.Size = new System.Drawing.Size(233, 22);
            this.IPTextBox.TabIndex = 7;
            this.IPTextBox.UseSystemPasswordChar = true;
            this.IPTextBox.WordWrap = false;
            // 
            // NumServerPort
            // 
            this.NumServerPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.NumServerPort.Location = new System.Drawing.Point(118, 32);
            this.NumServerPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.NumServerPort.Name = "NumServerPort";
            this.NumServerPort.Size = new System.Drawing.Size(233, 22);
            this.NumServerPort.TabIndex = 9;
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.PasswordTextBox.Location = new System.Drawing.Point(118, 60);
            this.PasswordTextBox.MaxLength = 256;
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.Size = new System.Drawing.Size(233, 22);
            this.PasswordTextBox.TabIndex = 11;
            this.PasswordTextBox.UseSystemPasswordChar = true;
            this.PasswordTextBox.WordWrap = false;
            // 
            // EncryptionLabel
            // 
            this.EncryptionLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.EncryptionLabel.AutoSize = true;
            this.EncryptionLabel.Location = new System.Drawing.Point(37, 93);
            this.EncryptionLabel.Name = "EncryptionLabel";
            this.EncryptionLabel.Size = new System.Drawing.Size(75, 17);
            this.EncryptionLabel.TabIndex = 12;
            this.EncryptionLabel.Text = "Encryption";
            // 
            // EncryptionSelect
            // 
            this.EncryptionSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.EncryptionSelect.FormattingEnabled = true;
            this.EncryptionSelect.Location = new System.Drawing.Point(118, 88);
            this.EncryptionSelect.Margin = new System.Windows.Forms.Padding(3, 3, 3, 7);
            this.EncryptionSelect.Name = "EncryptionSelect";
            this.EncryptionSelect.Size = new System.Drawing.Size(233, 24);
            this.EncryptionSelect.TabIndex = 13;
            // 
            // TextLink
            // 
            this.TextLink.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TextLink.Location = new System.Drawing.Point(118, 302);
            this.TextLink.Name = "TextLink";
            this.TextLink.ReadOnly = true;
            this.TextLink.Size = new System.Drawing.Size(233, 22);
            this.TextLink.TabIndex = 27;
            this.TextLink.Visible = false;
            this.TextLink.WordWrap = false;
            this.TextLink.Enter += new System.EventHandler(this.TextBox_Enter);
            this.TextLink.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TextBox_MouseUp);
            // 
            // RemarksTextBox
            // 
            this.RemarksTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.RemarksTextBox.Location = new System.Drawing.Point(118, 246);
            this.RemarksTextBox.MaxLength = 256;
            this.RemarksTextBox.Name = "RemarksTextBox";
            this.RemarksTextBox.Size = new System.Drawing.Size(233, 22);
            this.RemarksTextBox.TabIndex = 23;
            this.RemarksTextBox.WordWrap = false;
            // 
            // ObfsUDPLabel
            // 
            this.ObfsUDPLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.ObfsUDPLabel.AutoSize = true;
            this.ObfsUDPLabel.Location = new System.Drawing.Point(41, 441);
            this.ObfsUDPLabel.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.ObfsUDPLabel.Name = "ObfsUDPLabel";
            this.ObfsUDPLabel.Size = new System.Drawing.Size(71, 17);
            this.ObfsUDPLabel.TabIndex = 36;
            this.ObfsUDPLabel.Text = "Obfs UDP";
            this.ObfsUDPLabel.Visible = false;
            // 
            // CheckObfsUDP
            // 
            this.CheckObfsUDP.AutoSize = true;
            this.CheckObfsUDP.Location = new System.Drawing.Point(118, 439);
            this.CheckObfsUDP.Name = "CheckObfsUDP";
            this.CheckObfsUDP.Size = new System.Drawing.Size(166, 21);
            this.CheckObfsUDP.TabIndex = 37;
            this.CheckObfsUDP.Text = "Recommend checked";
            this.CheckObfsUDP.UseVisualStyleBackColor = true;
            this.CheckObfsUDP.Visible = false;
            // 
            // TCPProtocolLabel
            // 
            this.TCPProtocolLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.TCPProtocolLabel.AutoSize = true;
            this.TCPProtocolLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.TCPProtocolLabel.Location = new System.Drawing.Point(52, 127);
            this.TCPProtocolLabel.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.TCPProtocolLabel.Name = "TCPProtocolLabel";
            this.TCPProtocolLabel.Size = new System.Drawing.Size(60, 17);
            this.TCPProtocolLabel.TabIndex = 14;
            this.TCPProtocolLabel.Text = "Protocol";
            // 
            // UDPoverTCPLabel
            // 
            this.UDPoverTCPLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.UDPoverTCPLabel.AutoSize = true;
            this.UDPoverTCPLabel.Location = new System.Drawing.Point(12, 414);
            this.UDPoverTCPLabel.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.UDPoverTCPLabel.Name = "UDPoverTCPLabel";
            this.UDPoverTCPLabel.Size = new System.Drawing.Size(100, 17);
            this.UDPoverTCPLabel.TabIndex = 34;
            this.UDPoverTCPLabel.Text = "UDP over TCP";
            this.UDPoverTCPLabel.Visible = false;
            // 
            // CheckUDPoverUDP
            // 
            this.CheckUDPoverUDP.AutoSize = true;
            this.CheckUDPoverUDP.Location = new System.Drawing.Point(118, 412);
            this.CheckUDPoverUDP.Name = "CheckUDPoverUDP";
            this.CheckUDPoverUDP.Size = new System.Drawing.Size(216, 21);
            this.CheckUDPoverUDP.TabIndex = 35;
            this.CheckUDPoverUDP.Text = "UDP over UDP if not checked";
            this.CheckUDPoverUDP.UseVisualStyleBackColor = true;
            this.CheckUDPoverUDP.Visible = false;
            // 
            // LabelNote
            // 
            this.LabelNote.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.LabelNote.AutoSize = true;
            this.LabelNote.Location = new System.Drawing.Point(120, 332);
            this.LabelNote.Margin = new System.Windows.Forms.Padding(5);
            this.LabelNote.Name = "LabelNote";
            this.LabelNote.Size = new System.Drawing.Size(199, 17);
            this.LabelNote.TabIndex = 29;
            this.LabelNote.Text = "NOT all server support belows";
            this.LabelNote.Visible = false;
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.Location = new System.Drawing.Point(21, 60);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(91, 21);
            this.PasswordLabel.TabIndex = 10;
            this.PasswordLabel.Text = "Password";
            this.PasswordLabel.UseVisualStyleBackColor = true;
            this.PasswordLabel.CheckedChanged += new System.EventHandler(this.PasswordLabel_CheckedChanged);
            // 
            // TCPoverUDPLabel
            // 
            this.TCPoverUDPLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.TCPoverUDPLabel.AutoSize = true;
            this.TCPoverUDPLabel.Location = new System.Drawing.Point(12, 387);
            this.TCPoverUDPLabel.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.TCPoverUDPLabel.Name = "TCPoverUDPLabel";
            this.TCPoverUDPLabel.Size = new System.Drawing.Size(100, 17);
            this.TCPoverUDPLabel.TabIndex = 32;
            this.TCPoverUDPLabel.Text = "TCP over UDP";
            this.TCPoverUDPLabel.Visible = false;
            // 
            // CheckTCPoverUDP
            // 
            this.CheckTCPoverUDP.AutoSize = true;
            this.CheckTCPoverUDP.Location = new System.Drawing.Point(118, 385);
            this.CheckTCPoverUDP.Name = "CheckTCPoverUDP";
            this.CheckTCPoverUDP.Size = new System.Drawing.Size(212, 21);
            this.CheckTCPoverUDP.TabIndex = 33;
            this.CheckTCPoverUDP.Text = "TCP over TCP if not checked";
            this.CheckTCPoverUDP.UseVisualStyleBackColor = true;
            this.CheckTCPoverUDP.Visible = false;
            // 
            // TCPProtocolComboBox
            // 
            this.TCPProtocolComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TCPProtocolComboBox.FormattingEnabled = true;
            this.TCPProtocolComboBox.Items.AddRange(new object[] {
            "origin",
            "verify_deflate",
            "auth_sha1",
            "auth_sha1_v2",
            "auth_sha1_v4",
            "auth_aes128_md5",
            "auth_aes128_sha1",
            "auth_chain_a"});
            this.TCPProtocolComboBox.Location = new System.Drawing.Point(118, 122);
            this.TCPProtocolComboBox.Margin = new System.Windows.Forms.Padding(3, 3, 3, 7);
            this.TCPProtocolComboBox.Name = "TCPProtocolComboBox";
            this.TCPProtocolComboBox.Size = new System.Drawing.Size(233, 24);
            this.TCPProtocolComboBox.TabIndex = 15;
            // 
            // labelObfsParam
            // 
            this.labelObfsParam.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelObfsParam.AutoSize = true;
            this.labelObfsParam.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.labelObfsParam.Location = new System.Drawing.Point(30, 220);
            this.labelObfsParam.Name = "labelObfsParam";
            this.labelObfsParam.Size = new System.Drawing.Size(82, 17);
            this.labelObfsParam.TabIndex = 20;
            this.labelObfsParam.Text = "Obfs param";
            // 
            // TextObfsParam
            // 
            this.TextObfsParam.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TextObfsParam.Location = new System.Drawing.Point(118, 218);
            this.TextObfsParam.Name = "TextObfsParam";
            this.TextObfsParam.Size = new System.Drawing.Size(233, 22);
            this.TextObfsParam.TabIndex = 21;
            // 
            // labelGroup
            // 
            this.labelGroup.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelGroup.AutoSize = true;
            this.labelGroup.Location = new System.Drawing.Point(64, 276);
            this.labelGroup.Name = "labelGroup";
            this.labelGroup.Size = new System.Drawing.Size(48, 17);
            this.labelGroup.TabIndex = 24;
            this.labelGroup.Text = "Group";
            // 
            // TextGroup
            // 
            this.TextGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TextGroup.Location = new System.Drawing.Point(118, 274);
            this.TextGroup.MaxLength = 64;
            this.TextGroup.Name = "TextGroup";
            this.TextGroup.Size = new System.Drawing.Size(233, 22);
            this.TextGroup.TabIndex = 25;
            this.TextGroup.WordWrap = false;
            // 
            // checkAdvSetting
            // 
            this.checkAdvSetting.AutoSize = true;
            this.checkAdvSetting.Location = new System.Drawing.Point(6, 330);
            this.checkAdvSetting.Name = "checkAdvSetting";
            this.checkAdvSetting.Size = new System.Drawing.Size(106, 21);
            this.checkAdvSetting.TabIndex = 28;
            this.checkAdvSetting.Text = "Adv. Setting";
            this.checkAdvSetting.UseVisualStyleBackColor = true;
            this.checkAdvSetting.Visible = false;
            this.checkAdvSetting.CheckedChanged += new System.EventHandler(this.checkAdvSetting_CheckedChanged);
            // 
            // labelUDPPort
            // 
            this.labelUDPPort.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelUDPPort.AutoSize = true;
            this.labelUDPPort.Location = new System.Drawing.Point(45, 359);
            this.labelUDPPort.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.labelUDPPort.Name = "labelUDPPort";
            this.labelUDPPort.Size = new System.Drawing.Size(67, 17);
            this.labelUDPPort.TabIndex = 30;
            this.labelUDPPort.Text = "UDP Port";
            this.labelUDPPort.Visible = false;
            // 
            // NumUDPPort
            // 
            this.NumUDPPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.NumUDPPort.Location = new System.Drawing.Point(118, 357);
            this.NumUDPPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.NumUDPPort.Name = "NumUDPPort";
            this.NumUDPPort.Size = new System.Drawing.Size(233, 22);
            this.NumUDPPort.TabIndex = 31;
            this.NumUDPPort.Visible = false;
            // 
            // checkSSRLink
            // 
            this.checkSSRLink.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.checkSSRLink.AutoSize = true;
            this.checkSSRLink.Checked = true;
            this.checkSSRLink.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkSSRLink.Location = new System.Drawing.Point(24, 302);
            this.checkSSRLink.Name = "checkSSRLink";
            this.checkSSRLink.Size = new System.Drawing.Size(88, 21);
            this.checkSSRLink.TabIndex = 26;
            this.checkSSRLink.Text = "SSR Link";
            this.checkSSRLink.UseVisualStyleBackColor = true;
            this.checkSSRLink.Visible = false;
            this.checkSSRLink.CheckedChanged += new System.EventHandler(this.checkSSRLink_CheckedChanged);
            // 
            // labelRemarks
            // 
            this.labelRemarks.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelRemarks.AutoSize = true;
            this.labelRemarks.Location = new System.Drawing.Point(48, 248);
            this.labelRemarks.Name = "labelRemarks";
            this.labelRemarks.Size = new System.Drawing.Size(64, 17);
            this.labelRemarks.TabIndex = 22;
            this.labelRemarks.Text = "Remarks";
            // 
            // labelProtocolParam
            // 
            this.labelProtocolParam.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelProtocolParam.AutoSize = true;
            this.labelProtocolParam.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.labelProtocolParam.Location = new System.Drawing.Point(8, 158);
            this.labelProtocolParam.Name = "labelProtocolParam";
            this.labelProtocolParam.Size = new System.Drawing.Size(104, 17);
            this.labelProtocolParam.TabIndex = 16;
            this.labelProtocolParam.Text = "Protocol param";
            // 
            // TextProtocolParam
            // 
            this.TextProtocolParam.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TextProtocolParam.Location = new System.Drawing.Point(118, 156);
            this.TextProtocolParam.Name = "TextProtocolParam";
            this.TextProtocolParam.Size = new System.Drawing.Size(233, 22);
            this.TextProtocolParam.TabIndex = 17;
            // 
            // IPLabel
            // 
            this.IPLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.IPLabel.AutoSize = true;
            this.IPLabel.Location = new System.Drawing.Point(24, 4);
            this.IPLabel.Name = "IPLabel";
            this.IPLabel.Size = new System.Drawing.Size(88, 21);
            this.IPLabel.TabIndex = 38;
            this.IPLabel.Text = "Server IP";
            this.IPLabel.UseVisualStyleBackColor = true;
            this.IPLabel.CheckedChanged += new System.EventHandler(this.IPLabel_CheckedChanged);
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.AutoSize = true;
            this.tableLayoutPanel7.ColumnCount = 1;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel7.Controls.Add(this.ServersListBox, 0, 0);
            this.tableLayoutPanel7.Controls.Add(this.tableLayoutPanel4, 0, 1);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 3;
            this.tableLayoutPanel2.SetRowSpan(this.tableLayoutPanel7, 2);
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel7.Size = new System.Drawing.Size(179, 551);
            this.tableLayoutPanel7.TabIndex = 16;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.AutoSize = true;
            this.tableLayoutPanel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.Controls.Add(this.DownButton, 1, 1);
            this.tableLayoutPanel4.Controls.Add(this.UpButton, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.DeleteButton, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.AddButton, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 297);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.Size = new System.Drawing.Size(179, 68);
            this.tableLayoutPanel4.TabIndex = 8;
            // 
            // DownButton
            // 
            this.DownButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DownButton.Location = new System.Drawing.Point(93, 34);
            this.DownButton.Margin = new System.Windows.Forms.Padding(0);
            this.DownButton.Name = "DownButton";
            this.DownButton.Size = new System.Drawing.Size(86, 34);
            this.DownButton.TabIndex = 4;
            this.DownButton.Text = "Down";
            this.DownButton.UseVisualStyleBackColor = true;
            this.DownButton.Click += new System.EventHandler(this.DownButton_Click);
            // 
            // UpButton
            // 
            this.UpButton.Location = new System.Drawing.Point(0, 34);
            this.UpButton.Margin = new System.Windows.Forms.Padding(0);
            this.UpButton.Name = "UpButton";
            this.UpButton.Size = new System.Drawing.Size(86, 34);
            this.UpButton.TabIndex = 3;
            this.UpButton.Text = "Up";
            this.UpButton.UseVisualStyleBackColor = true;
            this.UpButton.Click += new System.EventHandler(this.UpButton_Click);
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.AutoSize = true;
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel5.Controls.Add(this.PictureQRcode, 0, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(577, 3);
            this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(12, 3, 3, 3);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.Size = new System.Drawing.Size(268, 508);
            this.tableLayoutPanel5.TabIndex = 17;
            this.tableLayoutPanel5.Visible = false;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.AutoSize = true;
            this.tableLayoutPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.MyCancelButton, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.OKButton, 0, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(188, 517);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.Size = new System.Drawing.Size(377, 37);
            this.tableLayoutPanel3.TabIndex = 14;
            // 
            // MyCancelButton
            // 
            this.MyCancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MyCancelButton.AutoSize = true;
            this.MyCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.MyCancelButton.Location = new System.Drawing.Point(199, 3);
            this.MyCancelButton.Margin = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.MyCancelButton.Name = "MyCancelButton";
            this.MyCancelButton.Size = new System.Drawing.Size(178, 34);
            this.MyCancelButton.TabIndex = 39;
            this.MyCancelButton.Text = "Cancel";
            this.MyCancelButton.UseVisualStyleBackColor = true;
            this.MyCancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // OKButton
            // 
            this.OKButton.AutoSize = true;
            this.OKButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OKButton.Location = new System.Drawing.Point(10, 3);
            this.OKButton.Margin = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(178, 34);
            this.OKButton.TabIndex = 38;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // ConfigForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(586, 591);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConfigForm";
            this.Padding = new System.Windows.Forms.Padding(12, 13, 12, 13);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Servers";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ConfigForm_FormClosed);
            this.Shown += new System.EventHandler(this.ConfigForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.PictureQRcode)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ServerGroupBox.ResumeLayout(false);
            this.ServerGroupBox.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumServerPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumUDPPort)).EndInit();
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel7.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.ListBox ServersListBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Button DownButton;
        private System.Windows.Forms.Button UpButton;
        private System.Windows.Forms.PictureBox PictureQRcode;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.GroupBox ServerGroupBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ComboBox ObfsCombo;
        private System.Windows.Forms.Label labelObfs;
        private System.Windows.Forms.Label ServerPortLabel;
        private System.Windows.Forms.TextBox IPTextBox;
        private System.Windows.Forms.NumericUpDown NumServerPort;
        private System.Windows.Forms.TextBox PasswordTextBox;
        private System.Windows.Forms.Label EncryptionLabel;
        private System.Windows.Forms.ComboBox EncryptionSelect;
        private System.Windows.Forms.TextBox TextLink;
        private System.Windows.Forms.TextBox RemarksTextBox;
        private System.Windows.Forms.Label ObfsUDPLabel;
        private System.Windows.Forms.CheckBox CheckObfsUDP;
        private System.Windows.Forms.Label TCPProtocolLabel;
        private System.Windows.Forms.Label UDPoverTCPLabel;
        private System.Windows.Forms.CheckBox CheckUDPoverUDP;
        private System.Windows.Forms.Label LabelNote;
        private System.Windows.Forms.CheckBox PasswordLabel;
        private System.Windows.Forms.Label TCPoverUDPLabel;
        private System.Windows.Forms.CheckBox CheckTCPoverUDP;
        private System.Windows.Forms.ComboBox TCPProtocolComboBox;
        private System.Windows.Forms.Label labelObfsParam;
        private System.Windows.Forms.TextBox TextObfsParam;
        private System.Windows.Forms.Label labelGroup;
        private System.Windows.Forms.TextBox TextGroup;
        private System.Windows.Forms.CheckBox checkAdvSetting;
        private System.Windows.Forms.Label labelUDPPort;
        private System.Windows.Forms.NumericUpDown NumUDPPort;
        private System.Windows.Forms.CheckBox checkSSRLink;
        private System.Windows.Forms.Label labelRemarks;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button MyCancelButton;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Label labelProtocolParam;
        private System.Windows.Forms.TextBox TextProtocolParam;
        private System.Windows.Forms.CheckBox IPLabel;
    }
}

