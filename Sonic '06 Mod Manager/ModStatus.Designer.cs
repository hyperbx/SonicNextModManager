namespace Sonic_06_Mod_Manager
{
    partial class ModStatus
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModStatus));
            this.pic_Logo = new System.Windows.Forms.PictureBox();
            this.pnl_windowCheck = new System.Windows.Forms.Panel();
            this.lbl_unpackState = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Logo)).BeginInit();
            this.pnl_windowCheck.SuspendLayout();
            this.SuspendLayout();
            // 
            // pic_Logo
            // 
            this.pic_Logo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pic_Logo.BackgroundImage")));
            this.pic_Logo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pic_Logo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic_Logo.Location = new System.Drawing.Point(9, 8);
            this.pic_Logo.Name = "pic_Logo";
            this.pic_Logo.Size = new System.Drawing.Size(86, 83);
            this.pic_Logo.TabIndex = 7;
            this.pic_Logo.TabStop = false;
            // 
            // pnl_windowCheck
            // 
            this.pnl_windowCheck.AutoSize = true;
            this.pnl_windowCheck.BackColor = System.Drawing.Color.Honeydew;
            this.pnl_windowCheck.Controls.Add(this.pic_Logo);
            this.pnl_windowCheck.Controls.Add(this.lbl_unpackState);
            this.pnl_windowCheck.Location = new System.Drawing.Point(0, 0);
            this.pnl_windowCheck.Name = "pnl_windowCheck";
            this.pnl_windowCheck.Size = new System.Drawing.Size(262, 100);
            this.pnl_windowCheck.TabIndex = 9;
            // 
            // lbl_unpackState
            // 
            this.lbl_unpackState.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_unpackState.AutoSize = true;
            this.lbl_unpackState.Location = new System.Drawing.Point(105, 48);
            this.lbl_unpackState.Name = "lbl_unpackState";
            this.lbl_unpackState.Size = new System.Drawing.Size(35, 13);
            this.lbl_unpackState.TabIndex = 6;
            this.lbl_unpackState.Text = "status";
            // 
            // ModStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Honeydew;
            this.ClientSize = new System.Drawing.Size(259, 97);
            this.ControlBox = false;
            this.Controls.Add(this.pnl_windowCheck);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ModStatus";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Status";
            this.Load += new System.EventHandler(this.ModStatus_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pic_Logo)).EndInit();
            this.pnl_windowCheck.ResumeLayout(false);
            this.pnl_windowCheck.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.PictureBox pic_Logo;
        internal System.Windows.Forms.Panel pnl_windowCheck;
        internal System.Windows.Forms.Label lbl_unpackState;
    }
}