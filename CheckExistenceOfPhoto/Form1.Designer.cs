namespace CheckExistenceOfPhoto
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.LabelLink = new System.Windows.Forms.Label();
            this.TextBoxLink = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // LabelLink
            // 
            this.LabelLink.AutoSize = true;
            this.LabelLink.Location = new System.Drawing.Point(29, 35);
            this.LabelLink.Name = "LabelLink";
            this.LabelLink.Size = new System.Drawing.Size(29, 15);
            this.LabelLink.TabIndex = 0;
            this.LabelLink.Text = "Link";
            // 
            // TextBoxLink
            // 
            this.TextBoxLink.Location = new System.Drawing.Point(64, 32);
            this.TextBoxLink.Name = "TextBoxLink";
            this.TextBoxLink.Size = new System.Drawing.Size(442, 23);
            this.TextBoxLink.TabIndex = 1;
            this.TextBoxLink.KeyDown += KeyDownTextBoxLink;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 450);
            this.Controls.Add(this.TextBoxLink);
            this.Controls.Add(this.LabelLink);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label LabelLink;
        private TextBox TextBoxLink;
    }
}