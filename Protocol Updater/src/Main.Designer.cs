namespace Protocol_Manager
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.pic_Logo = new System.Windows.Forms.PictureBox();
            this.lbl_Title = new System.Windows.Forms.Label();
            this.pnl_Backdrop = new System.Windows.Forms.Panel();
            this.lbl_StatusText = new System.Windows.Forms.Label();
            this.lbl_Status = new System.Windows.Forms.Label();
            this.btn_Uninstall = new System.Windows.Forms.Button();
            this.btn_Install = new System.Windows.Forms.Button();
            this.lbl_Valid = new System.Windows.Forms.Label();
            this.lbl_ValidText = new System.Windows.Forms.Label();
            this.help_Invalid = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Logo)).BeginInit();
            this.pnl_Backdrop.SuspendLayout();
            this.SuspendLayout();
            // 
            // pic_Logo
            // 
            this.pic_Logo.BackColor = System.Drawing.Color.Transparent;
            this.pic_Logo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pic_Logo.BackgroundImage")));
            this.pic_Logo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pic_Logo.Location = new System.Drawing.Point(278, 0);
            this.pic_Logo.Name = "pic_Logo";
            this.pic_Logo.Size = new System.Drawing.Size(52, 48);
            this.pic_Logo.TabIndex = 11;
            this.pic_Logo.TabStop = false;
            // 
            // lbl_Title
            // 
            this.lbl_Title.AutoSize = true;
            this.lbl_Title.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Title.Location = new System.Drawing.Point(9, 4);
            this.lbl_Title.Name = "lbl_Title";
            this.lbl_Title.Size = new System.Drawing.Size(250, 37);
            this.lbl_Title.TabIndex = 1;
            this.lbl_Title.Text = "Protocol Manager";
            // 
            // pnl_Backdrop
            // 
            this.pnl_Backdrop.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pnl_Backdrop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_Backdrop.Controls.Add(this.pic_Logo);
            this.pnl_Backdrop.Controls.Add(this.lbl_Title);
            this.pnl_Backdrop.Location = new System.Drawing.Point(-1, -1);
            this.pnl_Backdrop.Name = "pnl_Backdrop";
            this.pnl_Backdrop.Size = new System.Drawing.Size(333, 49);
            this.pnl_Backdrop.TabIndex = 47;
            // 
            // lbl_StatusText
            // 
            this.lbl_StatusText.AutoSize = true;
            this.lbl_StatusText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_StatusText.Location = new System.Drawing.Point(14, 61);
            this.lbl_StatusText.Name = "lbl_StatusText";
            this.lbl_StatusText.Size = new System.Drawing.Size(144, 15);
            this.lbl_StatusText.TabIndex = 48;
            this.lbl_StatusText.Text = "GameBanana Registry Key";
            // 
            // lbl_Status
            // 
            this.lbl_Status.AutoSize = true;
            this.lbl_Status.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Status.ForeColor = System.Drawing.Color.Tomato;
            this.lbl_Status.Location = new System.Drawing.Point(234, 61);
            this.lbl_Status.Name = "lbl_Status";
            this.lbl_Status.Size = new System.Drawing.Size(75, 15);
            this.lbl_Status.TabIndex = 49;
            this.lbl_Status.Text = "Not Installed";
            this.lbl_Status.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btn_Uninstall
            // 
            this.btn_Uninstall.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_Uninstall.BackColor = System.Drawing.Color.Tomato;
            this.btn_Uninstall.Enabled = false;
            this.btn_Uninstall.FlatAppearance.BorderSize = 0;
            this.btn_Uninstall.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Uninstall.Location = new System.Drawing.Point(218, 114);
            this.btn_Uninstall.Name = "btn_Uninstall";
            this.btn_Uninstall.Size = new System.Drawing.Size(105, 23);
            this.btn_Uninstall.TabIndex = 51;
            this.btn_Uninstall.Text = "Uninstall";
            this.btn_Uninstall.UseVisualStyleBackColor = false;
            this.btn_Uninstall.Click += new System.EventHandler(this.btn_Uninstall_Click);
            // 
            // btn_Install
            // 
            this.btn_Install.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_Install.BackColor = System.Drawing.Color.LightGreen;
            this.btn_Install.Enabled = false;
            this.btn_Install.FlatAppearance.BorderSize = 0;
            this.btn_Install.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Install.Location = new System.Drawing.Point(7, 114);
            this.btn_Install.Name = "btn_Install";
            this.btn_Install.Size = new System.Drawing.Size(205, 23);
            this.btn_Install.TabIndex = 50;
            this.btn_Install.Text = "Install";
            this.btn_Install.UseVisualStyleBackColor = false;
            this.btn_Install.Click += new System.EventHandler(this.btn_Install_Click);
            // 
            // lbl_Valid
            // 
            this.lbl_Valid.AutoSize = true;
            this.lbl_Valid.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Valid.ForeColor = System.Drawing.Color.Tomato;
            this.lbl_Valid.Location = new System.Drawing.Point(234, 85);
            this.lbl_Valid.Name = "lbl_Valid";
            this.lbl_Valid.Size = new System.Drawing.Size(58, 15);
            this.lbl_Valid.TabIndex = 53;
            this.lbl_Valid.Text = "Unknown";
            this.lbl_Valid.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbl_ValidText
            // 
            this.lbl_ValidText.AutoSize = true;
            this.lbl_ValidText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ValidText.Location = new System.Drawing.Point(14, 85);
            this.lbl_ValidText.Name = "lbl_ValidText";
            this.lbl_ValidText.Size = new System.Drawing.Size(107, 15);
            this.lbl_ValidText.TabIndex = 52;
            this.lbl_ValidText.Text = "Protocol Validation";
            // 
            // help_Invalid
            // 
            this.help_Invalid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.help_Invalid.AutoSize = true;
            this.help_Invalid.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.help_Invalid.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.help_Invalid.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.help_Invalid.LinkColor = System.Drawing.SystemColors.ControlDark;
            this.help_Invalid.Location = new System.Drawing.Point(280, 85);
            this.help_Invalid.Name = "help_Invalid";
            this.help_Invalid.Size = new System.Drawing.Size(18, 15);
            this.help_Invalid.TabIndex = 106;
            this.help_Invalid.TabStop = true;
            this.help_Invalid.Text = " ? ";
            this.help_Invalid.Visible = false;
            this.help_Invalid.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.help_Invalid_LinkClicked);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 144);
            this.Controls.Add(this.lbl_Valid);
            this.Controls.Add(this.help_Invalid);
            this.Controls.Add(this.lbl_ValidText);
            this.Controls.Add(this.btn_Uninstall);
            this.Controls.Add(this.btn_Install);
            this.Controls.Add(this.lbl_Status);
            this.Controls.Add(this.lbl_StatusText);
            this.Controls.Add(this.pnl_Backdrop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Protocol Manager";
            ((System.ComponentModel.ISupportInitialize)(this.pic_Logo)).EndInit();
            this.pnl_Backdrop.ResumeLayout(false);
            this.pnl_Backdrop.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.PictureBox pic_Logo;
        private System.Windows.Forms.Label lbl_Title;
        private System.Windows.Forms.Panel pnl_Backdrop;
        private System.Windows.Forms.Label lbl_StatusText;
        private System.Windows.Forms.Label lbl_Status;
        private System.Windows.Forms.Button btn_Uninstall;
        private System.Windows.Forms.Button btn_Install;
        private System.Windows.Forms.Label lbl_Valid;
        private System.Windows.Forms.Label lbl_ValidText;
        private System.Windows.Forms.LinkLabel help_Invalid;
    }
}

