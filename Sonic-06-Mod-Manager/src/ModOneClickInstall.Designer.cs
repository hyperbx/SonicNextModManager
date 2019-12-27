namespace Sonic_06_Mod_Manager.src
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
            this.pnl_Backdrop = new System.Windows.Forms.Panel();
            this.pic_Logo = new System.Windows.Forms.PictureBox();
            this.lbl_Title = new System.Windows.Forms.Label();
            this.mainControls_Split = new System.Windows.Forms.SplitContainer();
            this.tb_Information = new System.Windows.Forms.RichTextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pic_Thumbnail = new System.Windows.Forms.PictureBox();
            this.web_Description = new System.Windows.Forms.WebBrowser();
            this.btn_Decline = new System.Windows.Forms.Button();
            this.btn_Accept = new System.Windows.Forms.Button();
            this.lbl_Query = new System.Windows.Forms.Label();
            this.dl_Progress = new System.Windows.Forms.ProgressBar();
            this.pnl_DescriptionBackdrop = new System.Windows.Forms.Panel();
            this.pnl_InfoBackdrop = new System.Windows.Forms.Panel();
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
            ((System.ComponentModel.ISupportInitialize)(this.pic_Thumbnail)).BeginInit();
            this.pnl_DescriptionBackdrop.SuspendLayout();
            this.pnl_InfoBackdrop.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_Backdrop
            // 
            this.pnl_Backdrop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnl_Backdrop.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pnl_Backdrop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_Backdrop.Controls.Add(this.pic_Logo);
            this.pnl_Backdrop.Controls.Add(this.lbl_Title);
            this.pnl_Backdrop.Location = new System.Drawing.Point(-1, -1);
            this.pnl_Backdrop.Name = "pnl_Backdrop";
            this.pnl_Backdrop.Size = new System.Drawing.Size(574, 69);
            this.pnl_Backdrop.TabIndex = 50;
            // 
            // pic_Logo
            // 
            this.pic_Logo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pic_Logo.BackColor = System.Drawing.Color.Transparent;
            this.pic_Logo.BackgroundImage = global::Sonic_06_Mod_Manager.Properties.Resources.logo_gamebanana;
            this.pic_Logo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pic_Logo.Location = new System.Drawing.Point(494, 0);
            this.pic_Logo.Name = "pic_Logo";
            this.pic_Logo.Size = new System.Drawing.Size(72, 69);
            this.pic_Logo.TabIndex = 11;
            this.pic_Logo.TabStop = false;
            // 
            // lbl_Title
            // 
            this.lbl_Title.AutoSize = true;
            this.lbl_Title.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Bold);
            this.lbl_Title.Location = new System.Drawing.Point(16, 10);
            this.lbl_Title.Name = "lbl_Title";
            this.lbl_Title.Size = new System.Drawing.Size(109, 47);
            this.lbl_Title.TabIndex = 1;
            this.lbl_Title.Text = "None";
            // 
            // mainControls_Split
            // 
            this.mainControls_Split.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainControls_Split.Location = new System.Drawing.Point(8, 75);
            this.mainControls_Split.Name = "mainControls_Split";
            // 
            // mainControls_Split.Panel1
            // 
            this.mainControls_Split.Panel1.Controls.Add(this.pnl_InfoBackdrop);
            // 
            // mainControls_Split.Panel2
            // 
            this.mainControls_Split.Panel2.Controls.Add(this.splitContainer1);
            this.mainControls_Split.Size = new System.Drawing.Size(549, 461);
            this.mainControls_Split.SplitterDistance = 183;
            this.mainControls_Split.TabIndex = 52;
            // 
            // tb_Information
            // 
            this.tb_Information.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tb_Information.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_Information.Cursor = System.Windows.Forms.Cursors.Default;
            this.tb_Information.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_Information.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_Information.Location = new System.Drawing.Point(0, 0);
            this.tb_Information.Name = "tb_Information";
            this.tb_Information.ReadOnly = true;
            this.tb_Information.Size = new System.Drawing.Size(179, 459);
            this.tb_Information.TabIndex = 19;
            this.tb_Information.Text = "";
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
            this.splitContainer1.Panel1.Controls.Add(this.pic_Thumbnail);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pnl_DescriptionBackdrop);
            this.splitContainer1.Size = new System.Drawing.Size(362, 461);
            this.splitContainer1.SplitterDistance = 202;
            this.splitContainer1.TabIndex = 22;
            // 
            // pic_Thumbnail
            // 
            this.pic_Thumbnail.BackgroundImage = global::Sonic_06_Mod_Manager.Properties.Resources.logo_exception;
            this.pic_Thumbnail.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pic_Thumbnail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic_Thumbnail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pic_Thumbnail.Location = new System.Drawing.Point(0, 0);
            this.pic_Thumbnail.Name = "pic_Thumbnail";
            this.pic_Thumbnail.Size = new System.Drawing.Size(362, 202);
            this.pic_Thumbnail.TabIndex = 1;
            this.pic_Thumbnail.TabStop = false;
            // 
            // web_Description
            // 
            this.web_Description.AllowNavigation = false;
            this.web_Description.AllowWebBrowserDrop = false;
            this.web_Description.Dock = System.Windows.Forms.DockStyle.Fill;
            this.web_Description.IsWebBrowserContextMenuEnabled = false;
            this.web_Description.Location = new System.Drawing.Point(0, 0);
            this.web_Description.MinimumSize = new System.Drawing.Size(20, 20);
            this.web_Description.Name = "web_Description";
            this.web_Description.ScriptErrorsSuppressed = true;
            this.web_Description.Size = new System.Drawing.Size(360, 251);
            this.web_Description.TabIndex = 0;
            this.web_Description.WebBrowserShortcutsEnabled = false;
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
            this.btn_Decline.TabIndex = 55;
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
            this.btn_Accept.TabIndex = 54;
            this.btn_Accept.Text = "Yes";
            this.btn_Accept.UseVisualStyleBackColor = false;
            this.btn_Accept.Click += new System.EventHandler(this.Btn_Accept_Click);
            // 
            // lbl_Query
            // 
            this.lbl_Query.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_Query.AutoSize = true;
            this.lbl_Query.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.lbl_Query.Location = new System.Drawing.Point(10, 546);
            this.lbl_Query.Name = "lbl_Query";
            this.lbl_Query.Size = new System.Drawing.Size(251, 20);
            this.lbl_Query.TabIndex = 53;
            this.lbl_Query.Text = "Do you want to download this mod?";
            // 
            // dl_Progress
            // 
            this.dl_Progress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dl_Progress.Location = new System.Drawing.Point(8, 545);
            this.dl_Progress.Name = "dl_Progress";
            this.dl_Progress.Size = new System.Drawing.Size(403, 23);
            this.dl_Progress.TabIndex = 56;
            this.dl_Progress.Visible = false;
            // 
            // pnl_DescriptionBackdrop
            // 
            this.pnl_DescriptionBackdrop.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnl_DescriptionBackdrop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_DescriptionBackdrop.Controls.Add(this.web_Description);
            this.pnl_DescriptionBackdrop.Location = new System.Drawing.Point(0, 2);
            this.pnl_DescriptionBackdrop.Name = "pnl_DescriptionBackdrop";
            this.pnl_DescriptionBackdrop.Size = new System.Drawing.Size(362, 253);
            this.pnl_DescriptionBackdrop.TabIndex = 1;
            // 
            // pnl_InfoBackdrop
            // 
            this.pnl_InfoBackdrop.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnl_InfoBackdrop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_InfoBackdrop.Controls.Add(this.tb_Information);
            this.pnl_InfoBackdrop.Location = new System.Drawing.Point(0, 0);
            this.pnl_InfoBackdrop.Name = "pnl_InfoBackdrop";
            this.pnl_InfoBackdrop.Size = new System.Drawing.Size(181, 461);
            this.pnl_InfoBackdrop.TabIndex = 20;
            // 
            // ModOneClickInstall
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 577);
            this.Controls.Add(this.btn_Decline);
            this.Controls.Add(this.btn_Accept);
            this.Controls.Add(this.lbl_Query);
            this.Controls.Add(this.dl_Progress);
            this.Controls.Add(this.mainControls_Split);
            this.Controls.Add(this.pnl_Backdrop);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(580, 616);
            this.Name = "ModOneClickInstall";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GameBanana - 1-Click Mod Install";
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
            ((System.ComponentModel.ISupportInitialize)(this.pic_Thumbnail)).EndInit();
            this.pnl_DescriptionBackdrop.ResumeLayout(false);
            this.pnl_InfoBackdrop.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnl_Backdrop;
        internal System.Windows.Forms.PictureBox pic_Logo;
        private System.Windows.Forms.Label lbl_Title;
        private System.Windows.Forms.SplitContainer mainControls_Split;
        private System.Windows.Forms.RichTextBox tb_Information;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.PictureBox pic_Thumbnail;
        private System.Windows.Forms.Button btn_Decline;
        private System.Windows.Forms.Button btn_Accept;
        private System.Windows.Forms.Label lbl_Query;
        private System.Windows.Forms.ProgressBar dl_Progress;
        private System.Windows.Forms.WebBrowser web_Description;
        private System.Windows.Forms.Panel pnl_InfoBackdrop;
        private System.Windows.Forms.Panel pnl_DescriptionBackdrop;
    }
}