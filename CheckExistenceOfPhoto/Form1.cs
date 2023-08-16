namespace CheckExistenceOfPhoto
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void KeyDownTextBoxLink(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string userInput = TextBoxLink.Text;
                MessageBox.Show("Você pressionou Enter. O texto digitado é: " + userInput);
            }
        }
    }
}