namespace Unify.Environment3
{
    partial class SectionButton
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
            this.Selected = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // Selected
            // 
            this.Selected.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Selected.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Selected.Location = new System.Drawing.Point(277, 6);
            this.Selected.Name = "Selected";
            this.Selected.Size = new System.Drawing.Size(5, 23);
            this.Selected.TabIndex = 0;
            this.Selected.Visible = false;
            // 
            // SectionButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(45)))));
            this.Controls.Add(this.Selected);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "SectionButton";
            this.Size = new System.Drawing.Size(281, 35);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SectionButton_MouseDown);
            this.MouseEnter += new System.EventHandler(this.SectionButton_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.SectionButton_MouseLeave);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.SectionButton_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Selected;
    }
}
