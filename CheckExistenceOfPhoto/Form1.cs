using CheckExistenceOfPhoto.Components;
using CheckExistenceOfPhoto.Model;
using CheckExistenceOfPhoto.SqlHelper;

namespace CheckExistenceOfPhoto
{
    public partial class Form1 : Form
    {
        private const string MsgFound = "Status: {0}, Url:{1}";
        private const string MsgNotFound = "Status: {0}, Url:{1}";

        public Form1()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            TextBoxLink.KeyDown += KeyDownTextBoxLink;

            List<ImagensModel> Models = SqLiteHelper.GetAllImagens();

            foreach (var model in Models)            
                ListBoxImage.Items.Add(String.Format(MsgFound, (model.Status ? "Encontrado" : "Não encontrado"), model.Url));            
        }

        private void Check(string Input)
        {
            if (String.IsNullOrWhiteSpace(Input))
                return;

            if (Ping.Image(Input))
            {
                SqLiteHelper.InsertImage(
                    new Model.ImagensModel()
                    {
                        Url = Input,
                        Status = true
                    });
                ListBoxImage.Items.Add(String.Format(MsgFound, "Encontrado", Input));
            }
            else
            {
                SqLiteHelper.InsertImage(
                    new Model.ImagensModel()
                    {
                        Url = Input,
                        Status = false
                    });
                ListBoxImage.Items.Add(String.Format(MsgNotFound, "Não encontrado", Input));
            }

            Application.DoEvents();
        }

        private void KeyDownTextBoxLink(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                if (!String.IsNullOrWhiteSpace(TextBoxLink.Text))
                    Check(TextBoxLink.Text);
        }

        private void ButtonBuscar_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(TextBoxLink.Text))
                Check(TextBoxLink.Text);
        }
    }
}