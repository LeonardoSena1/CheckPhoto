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
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.ButtonDownload = new System.Windows.Forms.Button();
            this.ButtonExcluirDados = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.ButtonUpload = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
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
            this.ListBoxImage.Location = new System.Drawing.Point(29, 108);
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
            // ButtonDownload
            // 
            this.ButtonDownload.Location = new System.Drawing.Point(29, 403);
            this.ButtonDownload.Name = "ButtonDownload";
            this.ButtonDownload.Size = new System.Drawing.Size(75, 23);
            this.ButtonDownload.TabIndex = 4;
            this.ButtonDownload.Text = "Download";
            this.ButtonDownload.UseVisualStyleBackColor = true;
            this.ButtonDownload.Click += new System.EventHandler(this.ButtonDownloadAllImagens_Click);
            // 
            // ButtonExcluirDados
            // 
            this.ButtonExcluirDados.Location = new System.Drawing.Point(110, 403);
            this.ButtonExcluirDados.Name = "ButtonExcluirDados";
            this.ButtonExcluirDados.Size = new System.Drawing.Size(75, 23);
            this.ButtonExcluirDados.TabIndex = 5;
            this.ButtonExcluirDados.Text = "Excluir dados";
            this.ButtonExcluirDados.UseVisualStyleBackColor = true;
            this.ButtonExcluirDados.Click += new System.EventHandler(this.ButtonExcluirDados_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // ButtonUpload
            // 
            this.ButtonUpload.Location = new System.Drawing.Point(125, 63);
            this.ButtonUpload.Name = "ButtonUpload";
            this.ButtonUpload.Size = new System.Drawing.Size(75, 23);
            this.ButtonUpload.TabIndex = 6;
            this.ButtonUpload.Text = "Upload";
            this.ButtonUpload.UseVisualStyleBackColor = true;
            this.ButtonUpload.Click += new System.EventHandler(this.ButtonUpload_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "Upload planilha";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(209, 63);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Planilha modelo";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ButtonUpload);
            this.Controls.Add(this.ButtonExcluirDados);
            this.Controls.Add(this.ButtonDownload);
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
        private SaveFileDialog saveFileDialog1;
        private Button ButtonDownload;
        private Button ButtonExcluirDados;
        private OpenFileDialog openFileDialog1;
        private Button ButtonUpload;
        private Label label1;
        private Button button1;
    }
}