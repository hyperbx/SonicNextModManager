
namespace Unify.Environment3
{
    partial class ProfileCreator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProfileCreator));
            this.Button_Create = new System.Windows.Forms.Button();
            this.unifytb_ModCreator = new Unify.Environment3.UnifyTabControl();
            this.unifytb_Tab_Details = new System.Windows.Forms.TabPage();
            this.text_Title = new System.Windows.Forms.TextBox();
            this.lbl_Title = new System.Windows.Forms.Label();
            this.unifytb_ModCreator.SuspendLayout();
            this.unifytb_Tab_Details.SuspendLayout();
            this.SuspendLayout();
            // 
            // Button_Create
            // 
            this.Button_Create.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_Create.BackColor = System.Drawing.Color.LightGreen;
            this.Button_Create.Enabled = false;
            this.Button_Create.FlatAppearance.BorderSize = 0;
            this.Button_Create.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_Create.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_Create.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Button_Create.Location = new System.Drawing.Point(273, 78);
            this.Button_Create.Name = "Button_Create";
            this.Button_Create.Size = new System.Drawing.Size(96, 23);
            this.Button_Create.TabIndex = 105;
            this.Button_Create.Text = "Create Profile";
            this.Button_Create.UseVisualStyleBackColor = false;
            this.Button_Create.Click += new System.EventHandler(this.Button_Create_Click);
            // 
            // unifytb_ModCreator
            // 
            this.unifytb_ModCreator.ActiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.unifytb_ModCreator.AllowDragging = false;
            this.unifytb_ModCreator.AllowDrop = true;
            this.unifytb_ModCreator.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.unifytb_ModCreator.BackTabColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.unifytb_ModCreator.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.unifytb_ModCreator.ClosingButtonColor = System.Drawing.Color.WhiteSmoke;
            this.unifytb_ModCreator.ClosingMessage = null;
            this.unifytb_ModCreator.Controls.Add(this.unifytb_Tab_Details);
            this.unifytb_ModCreator.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unifytb_ModCreator.HeaderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.unifytb_ModCreator.HorizontalLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.unifytb_ModCreator.ItemSize = new System.Drawing.Size(240, 16);
            this.unifytb_ModCreator.Location = new System.Drawing.Point(0, 0);
            this.unifytb_ModCreator.Name = "unifytb_ModCreator";
            this.unifytb_ModCreator.NoTabDisplay = false;
            this.unifytb_ModCreator.SelectedIndex = 0;
            this.unifytb_ModCreator.SelectedTextColor = System.Drawing.SystemColors.Control;
            this.unifytb_ModCreator.ShowClosingButton = false;
            this.unifytb_ModCreator.ShowClosingMessage = false;
            this.unifytb_ModCreator.Size = new System.Drawing.Size(381, 67);
            this.unifytb_ModCreator.TabIndex = 104;
            this.unifytb_ModCreator.TextColor = System.Drawing.SystemColors.Control;
            // 
            // unifytb_Tab_Details
            // 
            this.unifytb_Tab_Details.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.unifytb_Tab_Details.Controls.Add(this.text_Title);
            this.unifytb_Tab_Details.Controls.Add(this.lbl_Title);
            this.unifytb_Tab_Details.Location = new System.Drawing.Point(4, 20);
            this.unifytb_Tab_Details.Name = "unifytb_Tab_Details";
            this.unifytb_Tab_Details.Size = new System.Drawing.Size(373, 43);
            this.unifytb_Tab_Details.TabIndex = 0;
            this.unifytb_Tab_Details.Text = "Details";
            // 
            // text_Title
            // 
            this.text_Title.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.text_Title.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.text_Title.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.text_Title.ForeColor = System.Drawing.SystemColors.Control;
            this.text_Title.Location = new System.Drawing.Point(45, 12);
            this.text_Title.Name = "text_Title";
            this.text_Title.Size = new System.Drawing.Size(320, 23);
            this.text_Title.TabIndex = 0;
            this.text_Title.TextChanged += new System.EventHandler(this.text_Title_TextChanged);
            // 
            // lbl_Title
            // 
            this.lbl_Title.AutoSize = true;
            this.lbl_Title.ForeColor = System.Drawing.SystemColors.Control;
            this.lbl_Title.Location = new System.Drawing.Point(6, 16);
            this.lbl_Title.Name = "lbl_Title";
            this.lbl_Title.Size = new System.Drawing.Size(32, 15);
            this.lbl_Title.TabIndex = 69;
            this.lbl_Title.Text = "Title:";
            // 
            // ProfileCreator
            // 
            this.AcceptButton = this.Button_Create;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.ClientSize = new System.Drawing.Size(380, 112);
            this.Controls.Add(this.Button_Create);
            this.Controls.Add(this.unifytb_ModCreator);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProfileCreator";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Profile Creator";
            this.unifytb_ModCreator.ResumeLayout(false);
            this.unifytb_Tab_Details.ResumeLayout(false);
            this.unifytb_Tab_Details.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Button_Create;
        private Unify.Environment3.UnifyTabControl unifytb_ModCreator;
        private System.Windows.Forms.TabPage unifytb_Tab_Details;
        private System.Windows.Forms.TextBox text_Title;
        private System.Windows.Forms.Label lbl_Title;
    }
}