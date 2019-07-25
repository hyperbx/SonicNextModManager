namespace Sonic_06_Mod_Manager
{
    partial class ModOneClickInstall
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModOneClickInstall));
            this.title = new System.Windows.Forms.Label();
            this.pnl_Backdrop = new System.Windows.Forms.Panel();
            this.pic_Logo = new System.Windows.Forms.PictureBox();
            this.credits = new System.Windows.Forms.RichTextBox();
            this.mainControls_Split = new System.Windows.Forms.SplitContainer();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.description = new System.Windows.Forms.WebBrowser();
            this.lbl_Query = new System.Windows.Forms.Label();
            this.btn_Decline = new System.Windows.Forms.Button();
            this.btn_Accept = new System.Windows.Forms.Button();
            this.dl_Progress = new System.Windows.Forms.ProgressBar();
            this.pnl_Backdrop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Logo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainControls_Split)).BeginInit();
            this.mainControls_Split.Panel1.SuspendLayout();
            this.mainControls_Split.Panel2.SuspendLayout();
            this.mainControls_Split.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Bold);
            this.title.Location = new System.Drawing.Point(16, 10);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(94, 47);
            this.title.TabIndex = 1;
            this.title.Text = "Title";
            // 
            // pnl_Backdrop
            // 
            this.pnl_Backdrop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnl_Backdrop.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pnl_Backdrop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_Backdrop.Controls.Add(this.pic_Logo);
            this.pnl_Backdrop.Controls.Add(this.title);
            this.pnl_Backdrop.Location = new System.Drawing.Point(-5, -2);
            this.pnl_Backdrop.Name = "pnl_Backdrop";
            this.pnl_Backdrop.Size = new System.Drawing.Size(574, 69);
            this.pnl_Backdrop.TabIndex = 18;
            // 
            // pic_Logo
            // 
            this.pic_Logo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pic_Logo.BackColor = System.Drawing.Color.Transparent;
            this.pic_Logo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pic_Logo.BackgroundImage")));
            this.pic_Logo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pic_Logo.Location = new System.Drawing.Point(497, 0);
            this.pic_Logo.Name = "pic_Logo";
            this.pic_Logo.Size = new System.Drawing.Size(72, 69);
            this.pic_Logo.TabIndex = 11;
            this.pic_Logo.TabStop = false;
            // 
            // credits
            // 
            this.credits.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.credits.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.credits.Dock = System.Windows.Forms.DockStyle.Fill;
            this.credits.Location = new System.Drawing.Point(0, 0);
            this.credits.Name = "credits";
            this.credits.ReadOnly = true;
            this.credits.Size = new System.Drawing.Size(183, 461);
            this.credits.TabIndex = 19;
            this.credits.Text = "";
            // 
            // mainControls_Split
            // 
            this.mainControls_Split.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainControls_Split.Location = new System.Drawing.Point(8, 74);
            this.mainControls_Split.Name = "mainControls_Split";
            // 
            // mainControls_Split.Panel1
            // 
            this.mainControls_Split.Panel1.Controls.Add(this.credits);
            // 
            // mainControls_Split.Panel2
            // 
            this.mainControls_Split.Panel2.Controls.Add(this.splitContainer1);
            this.mainControls_Split.Size = new System.Drawing.Size(549, 461);
            this.mainControls_Split.SplitterDistance = 183;
            this.mainControls_Split.TabIndex = 21;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.pictureBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.description);
            this.splitContainer1.Size = new System.Drawing.Size(362, 461);
            this.splitContainer1.SplitterDistance = 202;
            this.splitContainer1.TabIndex = 22;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::Sonic_06_Mod_Manager.Properties.Resources.logo_image_not_found;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(362, 202);
            this.pictureBox1.TabIndex = 44;
            this.pictureBox1.TabStop = false;
            // 
            // description
            // 
            this.description.Dock = System.Windows.Forms.DockStyle.Fill;
            this.description.Location = new System.Drawing.Point(0, 0);
            this.description.MinimumSize = new System.Drawing.Size(20, 20);
            this.description.Name = "description";
            this.description.Size = new System.Drawing.Size(362, 255);
            this.description.TabIndex = 45;
            // 
            // lbl_Query
            // 
            this.lbl_Query.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_Query.AutoSize = true;
            this.lbl_Query.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.lbl_Query.Location = new System.Drawing.Point(10, 546);
            this.lbl_Query.Name = "lbl_Query";
            this.lbl_Query.Size = new System.Drawing.Size(251, 20);
            this.lbl_Query.TabIndex = 21;
            this.lbl_Query.Text = "Do you want to download this mod?";
            // 
            // btn_Decline
            // 
            this.btn_Decline.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Decline.BackColor = System.Drawing.Color.Tomato;
            this.btn_Decline.FlatAppearance.BorderSize = 0;
            this.btn_Decline.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Decline.Location = new System.Drawing.Point(417, 545);
            this.btn_Decline.Name = "btn_Decline";
            this.btn_Decline.Size = new System.Drawing.Size(139, 23);
            this.btn_Decline.TabIndex = 43;
            this.btn_Decline.Text = "No";
            this.btn_Decline.UseVisualStyleBackColor = false;
            this.btn_Decline.Click += new System.EventHandler(this.Btn_Decline_Click);
            // 
            // btn_Accept
            // 
            this.btn_Accept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Accept.BackColor = System.Drawing.Color.LightGreen;
            this.btn_Accept.FlatAppearance.BorderSize = 0;
            this.btn_Accept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Accept.Location = new System.Drawing.Point(272, 545);
            this.btn_Accept.Name = "btn_Accept";
            this.btn_Accept.Size = new System.Drawing.Size(139, 23);
            this.btn_Accept.TabIndex = 42;
            this.btn_Accept.Text = "Yes";
            this.btn_Accept.UseVisualStyleBackColor = false;
            this.btn_Accept.Click += new System.EventHandler(this.Btn_Accept_Click);
            // 
            // dl_Progress
            // 
            this.dl_Progress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dl_Progress.Location = new System.Drawing.Point(8, 545);
            this.dl_Progress.Name = "dl_Progress";
            this.dl_Progress.Size = new System.Drawing.Size(403, 23);
            this.dl_Progress.TabIndex = 44;
            this.dl_Progress.Visible = false;
            // 
            // ModOneClickInstall
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 577);
            this.Controls.Add(this.btn_Decline);
            this.Controls.Add(this.btn_Accept);
            this.Controls.Add(this.mainControls_Split);
            this.Controls.Add(this.lbl_Query);
            this.Controls.Add(this.pnl_Backdrop);
            this.Controls.Add(this.dl_Progress);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(580, 510);
            this.Name = "ModOneClickInstall";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GameBanana - 1-Click Mod Install";
            this.Load += new System.EventHandler(this.ModOneClickInstall_Load);
            this.Shown += new System.EventHandler(this.ModOneClickInstall_Shown);
            this.pnl_Backdrop.ResumeLayout(false);
            this.pnl_Backdrop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Logo)).EndInit();
            this.mainControls_Split.Panel1.ResumeLayout(false);
            this.mainControls_Split.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainControls_Split)).EndInit();
            this.mainControls_Split.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Panel pnl_Backdrop;
        internal System.Windows.Forms.PictureBox pic_Logo;
        private System.Windows.Forms.RichTextBox credits;
        private System.Windows.Forms.SplitContainer mainControls_Split;
        private System.Windows.Forms.Label lbl_Query;
        private System.Windows.Forms.Button btn_Decline;
        private System.Windows.Forms.Button btn_Accept;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.WebBrowser description;
        private System.Windows.Forms.ProgressBar dl_Progress;
    }
}