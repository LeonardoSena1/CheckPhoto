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
        private async void InitializeComponent()
        {
            this.LabelLink = new System.Windows.Forms.Label();
            this.TextBoxLink = new System.Windows.Forms.TextBox();
            this.ListBoxImage = new System.Windows.Forms.ListBox();
            this.ButtonBuscar = new System.Windows.Forms.Button();
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
            this.TextBoxLink.PlaceholderText = "https://url-imagem/550/tech.jpg";
            this.TextBoxLink.Size = new System.Drawing.Size(442, 23);
            this.TextBoxLink.TabIndex = 1;
            // 
            // ListBoxImage
            // 
            this.ListBoxImage.FormattingEnabled = true;
            this.ListBoxImage.ItemHeight = 15;
            this.ListBoxImage.Location = new System.Drawing.Point(29, 127);
            this.ListBoxImage.Name = "ListBoxImage";
            this.ListBoxImage.Size = new System.Drawing.Size(565, 289);
            this.ListBoxImage.TabIndex = 2;
            // 
            // ButtonBuscar
            // 
            this.ButtonBuscar.Location = new System.Drawing.Point(519, 33);
            this.ButtonBuscar.Name = "ButtonBuscar";
            this.ButtonBuscar.Size = new System.Drawing.Size(75, 23);
            this.ButtonBuscar.TabIndex = 3;
            this.ButtonBuscar.Text = "Buscar";
            this.ButtonBuscar.UseVisualStyleBackColor = true;
            this.ButtonBuscar.Click += new System.EventHandler(this.ButtonBuscar_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 450);
            this.Controls.Add(this.ButtonBuscar);
            this.Controls.Add(this.ListBoxImage);
            this.Controls.Add(this.TextBoxLink);
            this.Controls.Add(this.LabelLink);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label LabelLink;
        private TextBox TextBoxLink;
        private ListBox ListBoxImage;
        private Button ButtonBuscar;
    }
}