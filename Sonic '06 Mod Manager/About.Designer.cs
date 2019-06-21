namespace Sonic_06_Mod_Manager
{
    partial class About
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(About));
            this.pic_Logo = new System.Windows.Forms.PictureBox();
            this.lbl_Title = new System.Windows.Forms.Label();
            this.lbl_versionNumber = new System.Windows.Forms.Label();
            this.lbl_Contributors = new System.Windows.Forms.Label();
            this.btn_GitHub = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Logo)).BeginInit();
            this.SuspendLayout();
            // 
            // pic_Logo
            // 
            this.pic_Logo.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pic_Logo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pic_Logo.BackgroundImage")));
            this.pic_Logo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pic_Logo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic_Logo.Location = new System.Drawing.Point(-1, -1);
            this.pic_Logo.Name = "pic_Logo";
            this.pic_Logo.Size = new System.Drawing.Size(228, 217);
            this.pic_Logo.TabIndex = 0;
            this.pic_Logo.TabStop = false;
            this.pic_Logo.Click += new System.EventHandler(this.Pic_Logo_Click);
            // 
            // lbl_Title
            // 
            this.lbl_Title.AutoSize = true;
            this.lbl_Title.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Title.Location = new System.Drawing.Point(233, 5);
            this.lbl_Title.Name = "lbl_Title";
            this.lbl_Title.Size = new System.Drawing.Size(149, 17);
            this.lbl_Title.TabIndex = 1;
            this.lbl_Title.Text = "Sonic \'06 Mod Manager";
            // 
            // lbl_versionNumber
            // 
            this.lbl_versionNumber.AutoSize = true;
            this.lbl_versionNumber.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_versionNumber.Location = new System.Drawing.Point(233, 22);
            this.lbl_versionNumber.Name = "lbl_versionNumber";
            this.lbl_versionNumber.Size = new System.Drawing.Size(98, 17);
            this.lbl_versionNumber.TabIndex = 2;
            this.lbl_versionNumber.Text = "versionNumber";
            // 
            // lbl_Contributors
            // 
            this.lbl_Contributors.AutoSize = true;
            this.lbl_Contributors.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Contributors.Location = new System.Drawing.Point(233, 51);
            this.lbl_Contributors.Name = "lbl_Contributors";
            this.lbl_Contributors.Size = new System.Drawing.Size(218, 85);
            this.lbl_Contributors.TabIndex = 3;
            this.lbl_Contributors.Text = "Contributors:\r\nKnuxfan24 - Lead Developer\r\nHyper - Co-developer and Designer\r\nxos" +
    "e - ARC Unpacker\r\ng0ldenlink - ARC Repacker";
            // 
            // btn_GitHub
            // 
            this.btn_GitHub.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(218)))), ((int)(((byte)(240)))));
            this.btn_GitHub.FlatAppearance.BorderSize = 0;
            this.btn_GitHub.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_GitHub.Location = new System.Drawing.Point(234, 184);
            this.btn_GitHub.Name = "btn_GitHub";
            this.btn_GitHub.Size = new System.Drawing.Size(246, 23);
            this.btn_GitHub.TabIndex = 4;
            this.btn_GitHub.Text = "GitHub";
            this.btn_GitHub.UseVisualStyleBackColor = false;
            this.btn_GitHub.Click += new System.EventHandler(this.Btn_GitHub_Click);
            // 
            // About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 214);
            this.Controls.Add(this.btn_GitHub);
            this.Controls.Add(this.lbl_Contributors);
            this.Controls.Add(this.lbl_versionNumber);
            this.Controls.Add(this.lbl_Title);
            this.Controls.Add(this.pic_Logo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "About";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About";
            this.Load += new System.EventHandler(this.About_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pic_Logo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pic_Logo;
        private System.Windows.Forms.Label lbl_Title;
        private System.Windows.Forms.Label lbl_versionNumber;
        private System.Windows.Forms.Label lbl_Contributors;
        private System.Windows.Forms.Button btn_GitHub;
    }
}