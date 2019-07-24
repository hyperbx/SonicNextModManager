﻿namespace Sonic_06_Mod_Manager
{
    partial class ModCreate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModCreate));
            this.label1 = new System.Windows.Forms.Label();
            this.modTitleBox = new System.Windows.Forms.TextBox();
            this.versionLabel = new System.Windows.Forms.Label();
            this.modVersionBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.modDateBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.modAuthorBox = new System.Windows.Forms.TextBox();
            this.createButton = new System.Windows.Forms.Button();
            this.check_Merge = new System.Windows.Forms.CheckBox();
            this.tool_Info = new System.Windows.Forms.ToolTip(this.components);
            this.combo_System = new System.Windows.Forms.ComboBox();
            this.lbl_System = new System.Windows.Forms.Label();
            this.lbl_Copy = new System.Windows.Forms.Label();
            this.modCopyBox = new System.Windows.Forms.TextBox();
            this.readonlyButtonHelp = new System.Windows.Forms.Button();
            this.deleteMod = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Title:";
            // 
            // modTitleBox
            // 
            this.modTitleBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.modTitleBox.Location = new System.Drawing.Point(73, 11);
            this.modTitleBox.Name = "modTitleBox";
            this.modTitleBox.Size = new System.Drawing.Size(283, 20);
            this.modTitleBox.TabIndex = 4;
            this.modTitleBox.TextChanged += new System.EventHandler(this.ModTitleBox_TextChanged);
            // 
            // versionLabel
            // 
            this.versionLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.versionLabel.AutoSize = true;
            this.versionLabel.Location = new System.Drawing.Point(23, 40);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(45, 13);
            this.versionLabel.TabIndex = 7;
            this.versionLabel.Text = "Version:";
            // 
            // modVersionBox
            // 
            this.modVersionBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.modVersionBox.Location = new System.Drawing.Point(73, 37);
            this.modVersionBox.Name = "modVersionBox";
            this.modVersionBox.Size = new System.Drawing.Size(283, 20);
            this.modVersionBox.TabIndex = 6;
            this.modVersionBox.TextChanged += new System.EventHandler(this.ModVersionBox_TextChanged);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Date:";
            // 
            // modDateBox
            // 
            this.modDateBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.modDateBox.Location = new System.Drawing.Point(73, 63);
            this.modDateBox.Name = "modDateBox";
            this.modDateBox.Size = new System.Drawing.Size(283, 20);
            this.modDateBox.TabIndex = 8;
            this.modDateBox.TextChanged += new System.EventHandler(this.ModDateBox_TextChanged);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Author:";
            // 
            // modAuthorBox
            // 
            this.modAuthorBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.modAuthorBox.Location = new System.Drawing.Point(73, 89);
            this.modAuthorBox.Name = "modAuthorBox";
            this.modAuthorBox.Size = new System.Drawing.Size(283, 20);
            this.modAuthorBox.TabIndex = 10;
            this.modAuthorBox.TextChanged += new System.EventHandler(this.ModAuthorBox_TextChanged);
            // 
            // createButton
            // 
            this.createButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.createButton.BackColor = System.Drawing.Color.LightGreen;
            this.createButton.Enabled = false;
            this.createButton.FlatAppearance.BorderSize = 0;
            this.createButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.createButton.Location = new System.Drawing.Point(281, 169);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(75, 23);
            this.createButton.TabIndex = 12;
            this.createButton.Text = "Create Mod";
            this.createButton.UseVisualStyleBackColor = false;
            this.createButton.Click += new System.EventHandler(this.CreateButton_Click);
            // 
            // check_Merge
            // 
            this.check_Merge.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.check_Merge.AutoSize = true;
            this.check_Merge.Location = new System.Drawing.Point(73, 172);
            this.check_Merge.Name = "check_Merge";
            this.check_Merge.Size = new System.Drawing.Size(62, 17);
            this.check_Merge.TabIndex = 13;
            this.check_Merge.Text = "Merge?";
            this.tool_Info.SetToolTip(this.check_Merge, "Does this mod need to merge files, rather than replacing them?");
            this.check_Merge.UseVisualStyleBackColor = true;
            this.check_Merge.CheckedChanged += new System.EventHandler(this.Check_Merge_CheckedChanged);
            // 
            // tool_Info
            // 
            this.tool_Info.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.tool_Info.ToolTipTitle = "Information";
            // 
            // combo_System
            // 
            this.combo_System.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.combo_System.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_System.FormattingEnabled = true;
            this.combo_System.Items.AddRange(new object[] {
            "Xbox 360",
            "PlayStation 3"});
            this.combo_System.Location = new System.Drawing.Point(73, 115);
            this.combo_System.Name = "combo_System";
            this.combo_System.Size = new System.Drawing.Size(283, 21);
            this.combo_System.TabIndex = 50;
            // 
            // lbl_System
            // 
            this.lbl_System.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_System.AutoSize = true;
            this.lbl_System.Location = new System.Drawing.Point(24, 118);
            this.lbl_System.Name = "lbl_System";
            this.lbl_System.Size = new System.Drawing.Size(44, 13);
            this.lbl_System.TabIndex = 49;
            this.lbl_System.Text = "System:";
            // 
            // lbl_Copy
            // 
            this.lbl_Copy.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_Copy.AutoSize = true;
            this.lbl_Copy.Enabled = false;
            this.lbl_Copy.Location = new System.Drawing.Point(10, 145);
            this.lbl_Copy.Name = "lbl_Copy";
            this.lbl_Copy.Size = new System.Drawing.Size(58, 13);
            this.lbl_Copy.TabIndex = 52;
            this.lbl_Copy.Text = "Read-only:";
            // 
            // modCopyBox
            // 
            this.modCopyBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.modCopyBox.Enabled = false;
            this.modCopyBox.Location = new System.Drawing.Point(73, 142);
            this.modCopyBox.Name = "modCopyBox";
            this.modCopyBox.Size = new System.Drawing.Size(257, 20);
            this.modCopyBox.TabIndex = 51;
            this.modCopyBox.TextChanged += new System.EventHandler(this.ModCopy_TextChanged);
            // 
            // readonlyButtonHelp
            // 
            this.readonlyButtonHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.readonlyButtonHelp.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.readonlyButtonHelp.Enabled = false;
            this.readonlyButtonHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.readonlyButtonHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.readonlyButtonHelp.Location = new System.Drawing.Point(334, 142);
            this.readonlyButtonHelp.Name = "readonlyButtonHelp";
            this.readonlyButtonHelp.Size = new System.Drawing.Size(22, 20);
            this.readonlyButtonHelp.TabIndex = 66;
            this.readonlyButtonHelp.Text = "?";
            this.readonlyButtonHelp.UseVisualStyleBackColor = false;
            this.readonlyButtonHelp.Click += new System.EventHandler(this.ReadonlyButtonHelp_Click);
            // 
            // deleteMod
            // 
            this.deleteMod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.deleteMod.BackColor = System.Drawing.Color.Tomato;
            this.deleteMod.FlatAppearance.BorderSize = 0;
            this.deleteMod.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteMod.Location = new System.Drawing.Point(200, 169);
            this.deleteMod.Name = "deleteMod";
            this.deleteMod.Size = new System.Drawing.Size(75, 23);
            this.deleteMod.TabIndex = 67;
            this.deleteMod.Text = "Delete Mod";
            this.deleteMod.UseVisualStyleBackColor = false;
            this.deleteMod.Visible = false;
            this.deleteMod.Click += new System.EventHandler(this.DeleteMod_Click);
            // 
            // ModCreate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(365, 200);
            this.Controls.Add(this.deleteMod);
            this.Controls.Add(this.readonlyButtonHelp);
            this.Controls.Add(this.lbl_Copy);
            this.Controls.Add(this.modCopyBox);
            this.Controls.Add(this.combo_System);
            this.Controls.Add(this.lbl_System);
            this.Controls.Add(this.check_Merge);
            this.Controls.Add(this.createButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.modAuthorBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.modDateBox);
            this.Controls.Add(this.versionLabel);
            this.Controls.Add(this.modVersionBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.modTitleBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(381, 213);
            this.Name = "ModCreate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Mod Creator";
            this.Load += new System.EventHandler(this.ModCreate_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox modTitleBox;
        private System.Windows.Forms.Label versionLabel;
        private System.Windows.Forms.TextBox modVersionBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox modDateBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox modAuthorBox;
        private System.Windows.Forms.Button createButton;
        private System.Windows.Forms.CheckBox check_Merge;
        private System.Windows.Forms.ToolTip tool_Info;
        private System.Windows.Forms.ComboBox combo_System;
        private System.Windows.Forms.Label lbl_System;
        private System.Windows.Forms.Label lbl_Copy;
        private System.Windows.Forms.TextBox modCopyBox;
        private System.Windows.Forms.Button readonlyButtonHelp;
        private System.Windows.Forms.Button deleteMod;
    }
}