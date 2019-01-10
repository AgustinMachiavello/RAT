namespace ClientRAT2
{
    partial class ClientRAT
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientRAT));
            this.gbOutput = new System.Windows.Forms.GroupBox();
            this.lbOutput = new System.Windows.Forms.ListBox();
            this.tbEnter = new System.Windows.Forms.TextBox();
            this.gbInput = new System.Windows.Forms.GroupBox();
            this.lConnectionStatus = new System.Windows.Forms.Label();
            this.lPortNumber = new System.Windows.Forms.Label();
            this.lCstatus = new System.Windows.Forms.Label();
            this.lPortN = new System.Windows.Forms.Label();
            this.tConnectionCheck = new System.Windows.Forms.Timer(this.components);
            this.gbMyData = new System.Windows.Forms.GroupBox();
            this.lIpv4 = new System.Windows.Forms.Label();
            this.lName = new System.Windows.Forms.Label();
            this.lmyipv4 = new System.Windows.Forms.Label();
            this.lMachinename = new System.Windows.Forms.Label();
            this.gbConnections = new System.Windows.Forms.GroupBox();
            this.lServersS = new System.Windows.Forms.Label();
            this.lServersStatus = new System.Windows.Forms.Label();
            this.bAttack = new System.Windows.Forms.Button();
            this.tServerStatus = new System.Windows.Forms.Timer(this.components);
            this.bHelp = new System.Windows.Forms.Button();
            this.bClean = new System.Windows.Forms.Button();
            this.gbOutput.SuspendLayout();
            this.gbInput.SuspendLayout();
            this.gbMyData.SuspendLayout();
            this.gbConnections.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbOutput
            // 
            this.gbOutput.BackColor = System.Drawing.Color.Black;
            this.gbOutput.Controls.Add(this.lbOutput);
            this.gbOutput.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbOutput.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.gbOutput.Location = new System.Drawing.Point(264, 12);
            this.gbOutput.Name = "gbOutput";
            this.gbOutput.Size = new System.Drawing.Size(399, 152);
            this.gbOutput.TabIndex = 1;
            this.gbOutput.TabStop = false;
            this.gbOutput.Text = "Output";
            // 
            // lbOutput
            // 
            this.lbOutput.BackColor = System.Drawing.Color.Black;
            this.lbOutput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbOutput.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lbOutput.FormattingEnabled = true;
            this.lbOutput.Location = new System.Drawing.Point(6, 16);
            this.lbOutput.Name = "lbOutput";
            this.lbOutput.Size = new System.Drawing.Size(387, 132);
            this.lbOutput.TabIndex = 2;
            this.lbOutput.SelectedIndexChanged += new System.EventHandler(this.lbOutput_SelectedIndexChanged);
            // 
            // tbEnter
            // 
            this.tbEnter.BackColor = System.Drawing.Color.Black;
            this.tbEnter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbEnter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.tbEnter.Location = new System.Drawing.Point(6, 19);
            this.tbEnter.Name = "tbEnter";
            this.tbEnter.Size = new System.Drawing.Size(347, 20);
            this.tbEnter.TabIndex = 2;
            this.tbEnter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbEnter_KeyDown);
            // 
            // gbInput
            // 
            this.gbInput.BackColor = System.Drawing.Color.Black;
            this.gbInput.Controls.Add(this.tbEnter);
            this.gbInput.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbInput.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.gbInput.Location = new System.Drawing.Point(12, 170);
            this.gbInput.Name = "gbInput";
            this.gbInput.Size = new System.Drawing.Size(359, 47);
            this.gbInput.TabIndex = 3;
            this.gbInput.TabStop = false;
            this.gbInput.Text = "Enter Command";
            // 
            // lConnectionStatus
            // 
            this.lConnectionStatus.AutoSize = true;
            this.lConnectionStatus.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lConnectionStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lConnectionStatus.Location = new System.Drawing.Point(6, 16);
            this.lConnectionStatus.Name = "lConnectionStatus";
            this.lConnectionStatus.Size = new System.Drawing.Size(171, 19);
            this.lConnectionStatus.TabIndex = 5;
            this.lConnectionStatus.Text = "Connection Status:";
            // 
            // lPortNumber
            // 
            this.lPortNumber.AutoSize = true;
            this.lPortNumber.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lPortNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lPortNumber.Location = new System.Drawing.Point(6, 54);
            this.lPortNumber.Name = "lPortNumber";
            this.lPortNumber.Size = new System.Drawing.Size(117, 19);
            this.lPortNumber.TabIndex = 6;
            this.lPortNumber.Text = "Port Number:";
            // 
            // lCstatus
            // 
            this.lCstatus.AutoSize = true;
            this.lCstatus.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lCstatus.ForeColor = System.Drawing.Color.Red;
            this.lCstatus.Location = new System.Drawing.Point(183, 16);
            this.lCstatus.Name = "lCstatus";
            this.lCstatus.Size = new System.Drawing.Size(54, 19);
            this.lCstatus.TabIndex = 7;
            this.lCstatus.Text = "Offline";
            this.lCstatus.Click += new System.EventHandler(this.lCstatus_Click);
            // 
            // lPortN
            // 
            this.lPortN.AutoSize = true;
            this.lPortN.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lPortN.ForeColor = System.Drawing.Color.Orange;
            this.lPortN.Location = new System.Drawing.Point(129, 54);
            this.lPortN.Name = "lPortN";
            this.lPortN.Size = new System.Drawing.Size(41, 19);
            this.lPortN.TabIndex = 8;
            this.lPortN.Text = "0000";
            this.lPortN.Click += new System.EventHandler(this.lPortN_Click);
            // 
            // tConnectionCheck
            // 
            this.tConnectionCheck.Enabled = true;
            this.tConnectionCheck.Interval = 1000;
            this.tConnectionCheck.Tick += new System.EventHandler(this.tConnectionCheck_Tick);
            // 
            // gbMyData
            // 
            this.gbMyData.BackColor = System.Drawing.Color.Black;
            this.gbMyData.Controls.Add(this.lIpv4);
            this.gbMyData.Controls.Add(this.lName);
            this.gbMyData.Controls.Add(this.lmyipv4);
            this.gbMyData.Controls.Add(this.lMachinename);
            this.gbMyData.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbMyData.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.gbMyData.Location = new System.Drawing.Point(12, 102);
            this.gbMyData.Name = "gbMyData";
            this.gbMyData.Size = new System.Drawing.Size(246, 62);
            this.gbMyData.TabIndex = 11;
            this.gbMyData.TabStop = false;
            this.gbMyData.Text = "My Data";
            // 
            // lIpv4
            // 
            this.lIpv4.AutoSize = true;
            this.lIpv4.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lIpv4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lIpv4.Location = new System.Drawing.Point(36, 38);
            this.lIpv4.Name = "lIpv4";
            this.lIpv4.Size = new System.Drawing.Size(28, 15);
            this.lIpv4.TabIndex = 14;
            this.lIpv4.Text = "---";
            // 
            // lName
            // 
            this.lName.AutoSize = true;
            this.lName.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lName.Location = new System.Drawing.Point(36, 19);
            this.lName.Name = "lName";
            this.lName.Size = new System.Drawing.Size(28, 15);
            this.lName.TabIndex = 13;
            this.lName.Text = "---";
            // 
            // lmyipv4
            // 
            this.lmyipv4.AutoSize = true;
            this.lmyipv4.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lmyipv4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lmyipv4.Location = new System.Drawing.Point(6, 35);
            this.lmyipv4.Name = "lmyipv4";
            this.lmyipv4.Size = new System.Drawing.Size(24, 18);
            this.lmyipv4.TabIndex = 12;
            this.lmyipv4.Text = "2)";
            // 
            // lMachinename
            // 
            this.lMachinename.AutoSize = true;
            this.lMachinename.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lMachinename.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lMachinename.Location = new System.Drawing.Point(6, 16);
            this.lMachinename.Name = "lMachinename";
            this.lMachinename.Size = new System.Drawing.Size(24, 18);
            this.lMachinename.TabIndex = 11;
            this.lMachinename.Text = "1)";
            // 
            // gbConnections
            // 
            this.gbConnections.BackColor = System.Drawing.Color.Black;
            this.gbConnections.Controls.Add(this.lServersS);
            this.gbConnections.Controls.Add(this.lServersStatus);
            this.gbConnections.Controls.Add(this.lCstatus);
            this.gbConnections.Controls.Add(this.lConnectionStatus);
            this.gbConnections.Controls.Add(this.lPortN);
            this.gbConnections.Controls.Add(this.lPortNumber);
            this.gbConnections.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbConnections.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.gbConnections.Location = new System.Drawing.Point(12, 12);
            this.gbConnections.Name = "gbConnections";
            this.gbConnections.Size = new System.Drawing.Size(246, 84);
            this.gbConnections.TabIndex = 12;
            this.gbConnections.TabStop = false;
            this.gbConnections.Text = "Connections";
            this.gbConnections.Enter += new System.EventHandler(this.gbConnections_Enter);
            // 
            // lServersS
            // 
            this.lServersS.AutoSize = true;
            this.lServersS.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lServersS.ForeColor = System.Drawing.Color.Red;
            this.lServersS.Location = new System.Drawing.Point(156, 35);
            this.lServersS.Name = "lServersS";
            this.lServersS.Size = new System.Drawing.Size(54, 19);
            this.lServersS.TabIndex = 10;
            this.lServersS.Text = "Offline";
            this.lServersS.Click += new System.EventHandler(this.lServersS_Click);
            // 
            // lServersStatus
            // 
            this.lServersStatus.AutoSize = true;
            this.lServersStatus.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lServersStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lServersStatus.Location = new System.Drawing.Point(6, 35);
            this.lServersStatus.Name = "lServersStatus";
            this.lServersStatus.Size = new System.Drawing.Size(144, 19);
            this.lServersStatus.TabIndex = 9;
            this.lServersStatus.Text = "Servers Status:";
            this.lServersStatus.Click += new System.EventHandler(this.lServersStatus_Click);
            // 
            // bAttack
            // 
            this.bAttack.BackColor = System.Drawing.Color.Black;
            this.bAttack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bAttack.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bAttack.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.bAttack.Location = new System.Drawing.Point(377, 181);
            this.bAttack.Name = "bAttack";
            this.bAttack.Size = new System.Drawing.Size(99, 32);
            this.bAttack.TabIndex = 13;
            this.bAttack.Text = "ATTACK";
            this.bAttack.UseVisualStyleBackColor = false;
            this.bAttack.Click += new System.EventHandler(this.bAttack_Click);
            // 
            // tServerStatus
            // 
            this.tServerStatus.Enabled = true;
            this.tServerStatus.Interval = 1000;
            this.tServerStatus.Tick += new System.EventHandler(this.tServerStatus_Tick);
            // 
            // bHelp
            // 
            this.bHelp.BackColor = System.Drawing.Color.Black;
            this.bHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bHelp.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bHelp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.bHelp.Location = new System.Drawing.Point(627, 181);
            this.bHelp.Margin = new System.Windows.Forms.Padding(1);
            this.bHelp.Name = "bHelp";
            this.bHelp.Size = new System.Drawing.Size(36, 32);
            this.bHelp.TabIndex = 15;
            this.bHelp.Text = "¿?";
            this.bHelp.UseVisualStyleBackColor = false;
            this.bHelp.Click += new System.EventHandler(this.bHelp_Click);
            // 
            // bClean
            // 
            this.bClean.BackColor = System.Drawing.Color.Black;
            this.bClean.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bClean.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bClean.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.bClean.Location = new System.Drawing.Point(482, 181);
            this.bClean.Name = "bClean";
            this.bClean.Size = new System.Drawing.Size(141, 32);
            this.bClean.TabIndex = 16;
            this.bClean.Text = "CLEAN TEXT";
            this.bClean.UseVisualStyleBackColor = false;
            this.bClean.Click += new System.EventHandler(this.bClean_Click);
            // 
            // ClientRAT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(676, 225);
            this.Controls.Add(this.bClean);
            this.Controls.Add(this.bHelp);
            this.Controls.Add(this.bAttack);
            this.Controls.Add(this.gbInput);
            this.Controls.Add(this.gbConnections);
            this.Controls.Add(this.gbMyData);
            this.Controls.Add(this.gbOutput);
            this.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ClientRAT";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ClientRAT2";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.endconnection);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.exit);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.gbOutput.ResumeLayout(false);
            this.gbInput.ResumeLayout(false);
            this.gbInput.PerformLayout();
            this.gbMyData.ResumeLayout(false);
            this.gbMyData.PerformLayout();
            this.gbConnections.ResumeLayout(false);
            this.gbConnections.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox gbOutput;
        private System.Windows.Forms.ListBox lbOutput;
        private System.Windows.Forms.TextBox tbEnter;
        private System.Windows.Forms.GroupBox gbInput;
        private System.Windows.Forms.Label lConnectionStatus;
        private System.Windows.Forms.Label lPortNumber;
        private System.Windows.Forms.Label lCstatus;
        private System.Windows.Forms.Label lPortN;
        private System.Windows.Forms.Timer tConnectionCheck;
        private System.Windows.Forms.GroupBox gbMyData;
        private System.Windows.Forms.GroupBox gbConnections;
        private System.Windows.Forms.Button bAttack;
        private System.Windows.Forms.Timer tServerStatus;
        private System.Windows.Forms.Label lServersStatus;
        private System.Windows.Forms.Label lServersS;
        private System.Windows.Forms.Button bHelp;
        private System.Windows.Forms.Button bClean;
        private System.Windows.Forms.Label lMachinename;
        private System.Windows.Forms.Label lmyipv4;
        private System.Windows.Forms.Label lName;
        private System.Windows.Forms.Label lIpv4;
    }
}

