namespace SONIC_THE_HEDGEHOG__2006__Mod_Manager
{
    partial class ModManager
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
            this.modList = new System.Windows.Forms.CheckedListBox();
            this.s06PathBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.s06PathButton = new System.Windows.Forms.Button();
            this.xeniaButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.xeniaBox = new System.Windows.Forms.TextBox();
            this.refreshButton = new System.Windows.Forms.Button();
            this.createButton = new System.Windows.Forms.Button();
            this.playButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.modsButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.modsBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // modList
            // 
            this.modList.FormattingEnabled = true;
            this.modList.Location = new System.Drawing.Point(12, 12);
            this.modList.Name = "modList";
            this.modList.Size = new System.Drawing.Size(370, 214);
            this.modList.TabIndex = 1;
            // 
            // s06PathBox
            // 
            this.s06PathBox.Location = new System.Drawing.Point(101, 287);
            this.s06PathBox.Name = "s06PathBox";
            this.s06PathBox.Size = new System.Drawing.Size(255, 20);
            this.s06PathBox.TabIndex = 2;
            this.s06PathBox.TextChanged += new System.EventHandler(this.S06PathBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 290);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Game Directory:";
            // 
            // s06PathButton
            // 
            this.s06PathButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.s06PathButton.Location = new System.Drawing.Point(362, 286);
            this.s06PathButton.Name = "s06PathButton";
            this.s06PathButton.Size = new System.Drawing.Size(22, 22);
            this.s06PathButton.TabIndex = 25;
            this.s06PathButton.Text = "...";
            this.s06PathButton.UseVisualStyleBackColor = true;
            this.s06PathButton.Click += new System.EventHandler(this.S06PathButton_Click);
            // 
            // xeniaButton
            // 
            this.xeniaButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xeniaButton.Location = new System.Drawing.Point(362, 312);
            this.xeniaButton.Name = "xeniaButton";
            this.xeniaButton.Size = new System.Drawing.Size(22, 22);
            this.xeniaButton.TabIndex = 28;
            this.xeniaButton.Text = "...";
            this.xeniaButton.UseVisualStyleBackColor = true;
            this.xeniaButton.Click += new System.EventHandler(this.XeniaButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 316);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "Xenia Executable:";
            // 
            // xeniaBox
            // 
            this.xeniaBox.Location = new System.Drawing.Point(111, 313);
            this.xeniaBox.Name = "xeniaBox";
            this.xeniaBox.Size = new System.Drawing.Size(245, 20);
            this.xeniaBox.TabIndex = 26;
            this.xeniaBox.TextChanged += new System.EventHandler(this.XeniaBox_TextChanged);
            // 
            // refreshButton
            // 
            this.refreshButton.Location = new System.Drawing.Point(12, 232);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(83, 23);
            this.refreshButton.TabIndex = 29;
            this.refreshButton.Text = "Refresh Mods";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // createButton
            // 
            this.createButton.Location = new System.Drawing.Point(101, 232);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(192, 23);
            this.createButton.TabIndex = 30;
            this.createButton.Text = "Create New Mod";
            this.createButton.UseVisualStyleBackColor = true;
            this.createButton.Click += new System.EventHandler(this.CreateButton_Click);
            // 
            // playButton
            // 
            this.playButton.Location = new System.Drawing.Point(15, 340);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(367, 23);
            this.playButton.TabIndex = 31;
            this.playButton.Text = "Save and Play";
            this.playButton.UseVisualStyleBackColor = true;
            this.playButton.Click += new System.EventHandler(this.PlayButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(299, 232);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(83, 23);
            this.button1.TabIndex = 33;
            this.button1.Text = "Mod Info";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // modsButton
            // 
            this.modsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modsButton.Location = new System.Drawing.Point(362, 260);
            this.modsButton.Name = "modsButton";
            this.modsButton.Size = new System.Drawing.Size(22, 22);
            this.modsButton.TabIndex = 36;
            this.modsButton.Text = "...";
            this.modsButton.UseVisualStyleBackColor = true;
            this.modsButton.Click += new System.EventHandler(this.ModsButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 264);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 35;
            this.label3.Text = "Mods Directory:";
            // 
            // modsBox
            // 
            this.modsBox.Location = new System.Drawing.Point(99, 261);
            this.modsBox.Name = "modsBox";
            this.modsBox.Size = new System.Drawing.Size(257, 20);
            this.modsBox.TabIndex = 34;
            this.modsBox.TextChanged += new System.EventHandler(this.ModsBox_TextChanged);
            // 
            // ModManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 375);
            this.Controls.Add(this.modsButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.modsBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.playButton);
            this.Controls.Add(this.createButton);
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.xeniaButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.xeniaBox);
            this.Controls.Add(this.s06PathButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.s06PathBox);
            this.Controls.Add(this.modList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ModManager";
            this.Text = "SONIC THE HEDGEHOG (2006) Mod Manager";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox modList;
        private System.Windows.Forms.TextBox s06PathBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button s06PathButton;
        private System.Windows.Forms.Button xeniaButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox xeniaBox;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.Button createButton;
        private System.Windows.Forms.Button playButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button modsButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox modsBox;
    }
}

