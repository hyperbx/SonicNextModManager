namespace Unify.Environment
{
    partial class UnifyEnvironment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UnifyEnvironment));
            this.Unify_Rush = new Unify.Environment.RushInterface();
            this.SuspendLayout();
            // 
            // Unify_Rush
            // 
            this.Unify_Rush.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.Unify_Rush.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Unify_Rush.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Unify_Rush.ForeColor = System.Drawing.SystemColors.Control;
            this.Unify_Rush.Location = new System.Drawing.Point(0, 0);
            this.Unify_Rush.Name = "Unify_Rush";
            this.Unify_Rush.SelectedIndex = 0;
            this.Unify_Rush.Size = new System.Drawing.Size(849, 569);
            this.Unify_Rush.TabIndex = 0;
            // 
            // UnifyEnvironment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.ClientSize = new System.Drawing.Size(849, 569);
            this.Controls.Add(this.Unify_Rush);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(865, 608);
            this.Name = "UnifyEnvironment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sonic \'06 Mod Manager";
            this.ResumeLayout(false);

        }

        #endregion
        private RushInterface Unify_Rush;
        private UnifyTabControl Rush_TabControl;
        private System.Windows.Forms.TabPage Tab_Rush_Mods;
        private System.Windows.Forms.TabPage Tab_Rush_Emulator;
        private System.Windows.Forms.TabPage Tab_Rush_Patches;
        private System.Windows.Forms.TabPage Tab_Rush_Settings;
        private System.Windows.Forms.TabPage Tab_Rush_About;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox TextBox_ModsDirectory;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label5;
        private WindowsColourPicker windowsColourPicker1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox CheckBox_HighContrastText;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox CheckBox_AutoColour;
        private System.Windows.Forms.Button Button_ColourPicker_Preview;
        private System.Windows.Forms.Button button3;
        private SectionButton sectionButton1;
    }
}