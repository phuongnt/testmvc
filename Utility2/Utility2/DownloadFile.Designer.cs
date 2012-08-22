namespace Utility2
{
    partial class DownloadFile
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
            this.btDownload = new System.Windows.Forms.Button();
            this.txtDomain = new System.Windows.Forms.TextBox();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.txtCookie = new System.Windows.Forms.TextBox();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.checkOnlyGetLink = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.txtFolder = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.txtIDMLink = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.checkUseIDM = new System.Windows.Forms.CheckBox();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btDownload
            // 
            this.btDownload.Location = new System.Drawing.Point(469, 166);
            this.btDownload.Name = "btDownload";
            this.btDownload.Size = new System.Drawing.Size(151, 50);
            this.btDownload.TabIndex = 0;
            this.btDownload.Text = "Download";
            this.btDownload.UseVisualStyleBackColor = true;
            this.btDownload.Click += new System.EventHandler(this.btDownload_Click);
            // 
            // txtDomain
            // 
            this.txtDomain.Location = new System.Drawing.Point(12, 30);
            this.txtDomain.Name = "txtDomain";
            this.txtDomain.Size = new System.Drawing.Size(672, 20);
            this.txtDomain.TabIndex = 2;
            this.txtDomain.Text = "http://www.viavia.no";
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(73, 61);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(56, 20);
            this.txtUser.TabIndex = 3;
            this.txtUser.Text = "host";
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(207, 61);
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '*';
            this.txtPass.Size = new System.Drawing.Size(172, 20);
            this.txtPass.TabIndex = 4;
            // 
            // txtCookie
            // 
            this.txtCookie.Location = new System.Drawing.Point(12, 103);
            this.txtCookie.Multiline = true;
            this.txtCookie.Name = "txtCookie";
            this.txtCookie.Size = new System.Drawing.Size(672, 38);
            this.txtCookie.TabIndex = 5;
            // 
            // txtStatus
            // 
            this.txtStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStatus.Location = new System.Drawing.Point(12, 261);
            this.txtStatus.Multiline = true;
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtStatus.Size = new System.Drawing.Size(672, 239);
            this.txtStatus.TabIndex = 6;
            // 
            // checkOnlyGetLink
            // 
            this.checkOnlyGetLink.AutoSize = true;
            this.checkOnlyGetLink.Location = new System.Drawing.Point(10, 199);
            this.checkOnlyGetLink.Name = "checkOnlyGetLink";
            this.checkOnlyGetLink.Size = new System.Drawing.Size(84, 17);
            this.checkOnlyGetLink.TabIndex = 7;
            this.checkOnlyGetLink.Text = "Only get link";
            this.checkOnlyGetLink.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "cookie login destinet";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(149, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Username";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Host name (*)";
            // 
            // txtFolder
            // 
            this.txtFolder.Location = new System.Drawing.Point(12, 169);
            this.txtFolder.Name = "txtFolder";
            this.txtFolder.Size = new System.Drawing.Size(364, 20);
            this.txtFolder.TabIndex = 12;
            this.txtFolder.Text = "D:/DownloadResourse";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(379, 166);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(35, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(548, 506);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(136, 23);
            this.button2.TabIndex = 14;
            this.button2.Text = "Open Container Folder";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // txtIDMLink
            // 
            this.txtIDMLink.Location = new System.Drawing.Point(10, 235);
            this.txtIDMLink.Name = "txtIDMLink";
            this.txtIDMLink.Size = new System.Drawing.Size(364, 20);
            this.txtIDMLink.TabIndex = 15;
            this.txtIDMLink.Text = "C:\\\\Program Files (x86)\\\\Internet Download Manager\\\\IDMan.exe";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 219);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "IDM location";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 153);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Target folder";
            // 
            // checkUseIDM
            // 
            this.checkUseIDM.AutoSize = true;
            this.checkUseIDM.Checked = true;
            this.checkUseIDM.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkUseIDM.Location = new System.Drawing.Point(100, 199);
            this.checkUseIDM.Name = "checkUseIDM";
            this.checkUseIDM.Size = new System.Drawing.Size(117, 17);
            this.checkUseIDM.TabIndex = 18;
            this.checkUseIDM.Text = "Use IDM download";
            this.checkUseIDM.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.Location = new System.Drawing.Point(379, 506);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(136, 23);
            this.button3.TabIndex = 19;
            this.button3.Text = "Check";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // DownloadFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 538);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.checkUseIDM);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtIDMLink);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtFolder);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkOnlyGetLink);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.txtCookie);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.txtDomain);
            this.Controls.Add(this.btDownload);
            this.Name = "DownloadFile";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DownloadFile";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btDownload;
        private System.Windows.Forms.TextBox txtDomain;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.TextBox txtCookie;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.CheckBox checkOnlyGetLink;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TextBox txtFolder;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox txtIDMLink;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox checkUseIDM;
        private System.Windows.Forms.Button button3;
    }
}