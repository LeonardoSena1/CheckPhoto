using CheckExistenceOfPhoto.Components;

namespace CheckExistenceOfPhoto
{
    public partial class Form1 : Form
    {
        private const string MsgFound = "Status: Encontrado, Url:{0}";
        private const string MsgNotFound = "Status: Não encontrado, Url:{0}";

        public Form1()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            TextBoxLink.KeyDown += KeyDownTextBoxLink;
        }

        private void Check(string Input)
        {
            if (String.IsNullOrWhiteSpace(Input))
                return;

            if (Ping.Image(Input))
                ListBoxImage.Items.Add(String.Format(MsgFound, Input));
            else
                ListBoxImage.Items.Add(String.Format(MsgNotFound, Input));

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