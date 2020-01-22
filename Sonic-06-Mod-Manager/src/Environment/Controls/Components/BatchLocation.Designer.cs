namespace Unify.Environment
{
    partial class BatchLocation
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Label_Description_Location = new System.Windows.Forms.Label();
            this.Button_Location = new System.Windows.Forms.Button();
            this.Label_Location = new System.Windows.Forms.Label();
            this.TextBox_Location = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Label_Description_Location
            // 
            this.Label_Description_Location.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Label_Description_Location.AutoSize = true;
            this.Label_Description_Location.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Label_Description_Location.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.Label_Description_Location.Location = new System.Drawing.Point(190, 1);
            this.Label_Description_Location.Name = "Label_Description_Location";
            this.Label_Description_Location.Size = new System.Drawing.Size(288, 15);
            this.Label_Description_Location.TabIndex = 20;
            this.Label_Description_Location.Text = "Path to where you want to perform batch processing.";
            // 
            // Button_Location
            // 
            this.Button_Location.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_Location.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Button_Location.FlatAppearance.BorderSize = 0;
            this.Button_Location.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_Location.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Button_Location.Location = new System.Drawing.Point(484, 21);
            this.Button_Location.Name = "Button_Location";
            this.Button_Location.Size = new System.Drawing.Size(25, 23);
            this.Button_Location.TabIndex = 19;
            this.Button_Location.Text = "...";
            this.Button_Location.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Button_Location.UseVisualStyleBackColor = false;
            this.Button_Location.Click += new System.EventHandler(this.Button_Location_Click);
            // 
            // Label_Location
            // 
            this.Label_Location.AutoSize = true;
            this.Label_Location.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.Label_Location.ForeColor = System.Drawing.SystemColors.Control;
            this.Label_Location.Location = new System.Drawing.Point(-1, -1);
            this.Label_Location.Name = "Label_Location";
            this.Label_Location.Size = new System.Drawing.Size(57, 17);
            this.Label_Location.TabIndex = 17;
            this.Label_Location.Text = "Location";
            // 
            // TextBox_Location
            // 
            this.TextBox_Location.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBox_Location.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.TextBox_Location.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TextBox_Location.ForeColor = System.Drawing.SystemColors.Control;
            this.TextBox_Location.Location = new System.Drawing.Point(2, 21);
            this.TextBox_Location.Name = "TextBox_Location";
            this.TextBox_Location.Size = new System.Drawing.Size(476, 23);
            this.TextBox_Location.TabIndex = 18;
            // 
            // BatchLocation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.Controls.Add(this.Button_Location);
            this.Controls.Add(this.Label_Location);
            this.Controls.Add(this.TextBox_Location);
            this.Controls.Add(this.Label_Description_Location);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "BatchLocation";
            this.Size = new System.Drawing.Size(509, 48);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Label_Description_Location;
        private System.Windows.Forms.Button Button_Location;
        private System.Windows.Forms.Label Label_Location;
        private System.Windows.Forms.TextBox TextBox_Location;
    }
}
