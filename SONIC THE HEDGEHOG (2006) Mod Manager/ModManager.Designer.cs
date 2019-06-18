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
            this.playButton = new System.Windows.Forms.Button();
            this.group_Mods = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.createButton = new System.Windows.Forms.Button();
            this.refreshButton = new System.Windows.Forms.Button();
            this.modList = new System.Windows.Forms.CheckedListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.modsButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.modsBox = new System.Windows.Forms.TextBox();
            this.xeniaButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.xeniaBox = new System.Windows.Forms.TextBox();
            this.s06PathButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.s06PathBox = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.group_Mods.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // playButton
            // 
            this.playButton.Location = new System.Drawing.Point(9, 373);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(283, 23);
            this.playButton.TabIndex = 31;
            this.playButton.Text = "Save and Play";
            this.playButton.UseVisualStyleBackColor = true;
            this.playButton.Click += new System.EventHandler(this.PlayButton_Click);
            // 
            // group_Mods
            // 
            this.group_Mods.Controls.Add(this.button1);
            this.group_Mods.Controls.Add(this.createButton);
            this.group_Mods.Controls.Add(this.refreshButton);
            this.group_Mods.Controls.Add(this.modList);
            this.group_Mods.Location = new System.Drawing.Point(10, 3);
            this.group_Mods.Name = "group_Mods";
            this.group_Mods.Size = new System.Drawing.Size(374, 262);
            this.group_Mods.TabIndex = 37;
            this.group_Mods.TabStop = false;
            this.group_Mods.Text = "Mods";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(284, 234);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(85, 23);
            this.button1.TabIndex = 37;
            this.button1.Text = "Mod Info";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // createButton
            // 
            this.createButton.Location = new System.Drawing.Point(90, 234);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(192, 23);
            this.createButton.TabIndex = 36;
            this.createButton.Text = "Create New Mod";
            this.createButton.UseVisualStyleBackColor = true;
            this.createButton.Click += new System.EventHandler(this.CreateButton_Click);
            // 
            // refreshButton
            // 
            this.refreshButton.Location = new System.Drawing.Point(5, 234);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(83, 23);
            this.refreshButton.TabIndex = 35;
            this.refreshButton.Text = "Refresh Mods";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // modList
            // 
            this.modList.FormattingEnabled = true;
            this.modList.Location = new System.Drawing.Point(6, 17);
            this.modList.Name = "modList";
            this.modList.Size = new System.Drawing.Size(362, 214);
            this.modList.TabIndex = 34;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.modsButton);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.modsBox);
            this.groupBox1.Controls.Add(this.xeniaButton);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.xeniaBox);
            this.groupBox1.Controls.Add(this.s06PathButton);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.s06PathBox);
            this.groupBox1.Location = new System.Drawing.Point(10, 267);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(374, 99);
            this.groupBox1.TabIndex = 38;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Directories";
            // 
            // modsButton
            // 
            this.modsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modsButton.Location = new System.Drawing.Point(346, 16);
            this.modsButton.Name = "modsButton";
            this.modsButton.Size = new System.Drawing.Size(22, 22);
            this.modsButton.TabIndex = 45;
            this.modsButton.Text = "...";
            this.modsButton.UseVisualStyleBackColor = true;
            this.modsButton.Click += new System.EventHandler(this.ModsButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 44;
            this.label3.Text = "Mods Directory:";
            // 
            // modsBox
            // 
            this.modsBox.Location = new System.Drawing.Point(100, 17);
            this.modsBox.Name = "modsBox";
            this.modsBox.Size = new System.Drawing.Size(241, 20);
            this.modsBox.TabIndex = 43;
            this.modsBox.TextChanged += new System.EventHandler(this.ModsBox_TextChanged);
            // 
            // xeniaButton
            // 
            this.xeniaButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xeniaButton.Location = new System.Drawing.Point(346, 68);
            this.xeniaButton.Name = "xeniaButton";
            this.xeniaButton.Size = new System.Drawing.Size(22, 22);
            this.xeniaButton.TabIndex = 42;
            this.xeniaButton.Text = "...";
            this.xeniaButton.UseVisualStyleBackColor = true;
            this.xeniaButton.Click += new System.EventHandler(this.XeniaButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 41;
            this.label2.Text = "Xenia Executable:";
            // 
            // xeniaBox
            // 
            this.xeniaBox.Location = new System.Drawing.Point(100, 69);
            this.xeniaBox.Name = "xeniaBox";
            this.xeniaBox.Size = new System.Drawing.Size(241, 20);
            this.xeniaBox.TabIndex = 40;
            this.xeniaBox.TextChanged += new System.EventHandler(this.XeniaBox_TextChanged);
            // 
            // s06PathButton
            // 
            this.s06PathButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.s06PathButton.Location = new System.Drawing.Point(346, 42);
            this.s06PathButton.Name = "s06PathButton";
            this.s06PathButton.Size = new System.Drawing.Size(22, 22);
            this.s06PathButton.TabIndex = 39;
            this.s06PathButton.Text = "...";
            this.s06PathButton.UseVisualStyleBackColor = true;
            this.s06PathButton.Click += new System.EventHandler(this.S06PathButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 38;
            this.label1.Text = "Game Directory:";
            // 
            // s06PathBox
            // 
            this.s06PathBox.Location = new System.Drawing.Point(100, 43);
            this.s06PathBox.Name = "s06PathBox";
            this.s06PathBox.Size = new System.Drawing.Size(241, 20);
            this.s06PathBox.TabIndex = 37;
            this.s06PathBox.TextChanged += new System.EventHandler(this.S06PathBox_TextChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(294, 373);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(91, 23);
            this.button2.TabIndex = 39;
            this.button2.Text = "About";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // ModManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 404);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.group_Mods);
            this.Controls.Add(this.playButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ModManager";
            this.Text = "Sonic \'06 Mod Manager";
            this.Load += new System.EventHandler(this.ModManager_Load);
            this.group_Mods.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button playButton;
        private System.Windows.Forms.GroupBox group_Mods;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button createButton;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.CheckedListBox modList;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button modsButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox modsBox;
        private System.Windows.Forms.Button xeniaButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox xeniaBox;
        private System.Windows.Forms.Button s06PathButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox s06PathBox;
        private System.Windows.Forms.Button button2;
    }
}

