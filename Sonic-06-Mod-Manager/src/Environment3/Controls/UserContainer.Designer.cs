namespace Unify.Environment3
{
    partial class UserContainer
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
            this.Container_Control = new System.Windows.Forms.SplitContainer();
            this.Label_Title = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Container_Control)).BeginInit();
            this.Container_Control.Panel1.SuspendLayout();
            this.Container_Control.SuspendLayout();
            this.SuspendLayout();
            // 
            // Container_Control
            // 
            this.Container_Control.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Container_Control.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.Container_Control.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.Container_Control.IsSplitterFixed = true;
            this.Container_Control.Location = new System.Drawing.Point(0, 0);
            this.Container_Control.Name = "Container_Control";
            // 
            // Container_Control.Panel1
            // 
            this.Container_Control.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.Container_Control.Panel1.Controls.Add(this.Label_Title);
            this.Container_Control.Panel1MinSize = 281;
            this.Container_Control.Panel2MinSize = 389;
            this.Container_Control.Size = new System.Drawing.Size(849, 435);
            this.Container_Control.SplitterDistance = 281;
            this.Container_Control.TabIndex = 2;
            // 
            // Label_Title
            // 
            this.Label_Title.AutoSize = true;
            this.Label_Title.Font = new System.Drawing.Font("Segoe UI Semibold", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Title.ForeColor = System.Drawing.SystemColors.Control;
            this.Label_Title.Location = new System.Drawing.Point(7, 8);
            this.Label_Title.Name = "Label_Title";
            this.Label_Title.Size = new System.Drawing.Size(163, 45);
            this.Label_Title.TabIndex = 1;
            this.Label_Title.Text = "Container";
            // 
            // UserContainer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Container_Control);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "UserContainer";
            this.Size = new System.Drawing.Size(849, 435);
            this.Container_Control.Panel1.ResumeLayout(false);
            this.Container_Control.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Container_Control)).EndInit();
            this.Container_Control.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer Container_Control;
        private System.Windows.Forms.Label Label_Title;
    }
}
