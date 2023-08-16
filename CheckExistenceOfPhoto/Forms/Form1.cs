using CheckExistenceOfPhoto.Components;
using CheckExistenceOfPhoto.Model;
using CheckExistenceOfPhoto.SqlHelper;

namespace CheckExistenceOfPhoto
{
    public partial class Form1 : Form
    {
        private List<string> listaItens = new List<string>();

        public Form1()
        {
            InitializeComponent();
        }

        private void AtualizaListBoxImage()
        {
            ListBoxImage.Items.Clear();

            List<ImagensModel> Models = SqLiteHelper.GetAllImagens();

            foreach (var model in Models)
                ListBoxImage.Items.Add(String.Format(SettingsConsts.MsgFound, (model.Status ? "Encontrado" : "Não encontrado"), model.Url));
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            TextBoxLink.KeyDown += KeyDownTextBoxLink;

            AtualizaListBoxImage();
        }

        private void Check(string Input)
        {
            if (String.IsNullOrWhiteSpace(Input))
                return;

            if (Ping.Image(Input))
                SqLiteHelper.InsertImage(
                    new Model.ImagensModel()
                    {
                        Url = Input,
                        Status = true
                    });
            else

                SqLiteHelper.InsertImage(
                    new Model.ImagensModel()
                    {
                        Url = Input,
                        Status = false
                    });


            AtualizaListBoxImage();
            TextBoxLink.Clear();
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

        private void ButtonDownloadAllImagens_Click(object sender, EventArgs e)
        {
            string filePath = Environment.CurrentDirectory + "\\Sources\\Excels\\Planilha-Imagens.xlsx";
            string fileName = Guid.NewGuid().ToString("N") + ".xlsx";

            if (File.Exists(filePath))
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.FileName = fileName;
                saveFileDialog.Filter = "Planilhas Excel (*.xlsx)|*.xlsx|Todos os arquivos (*.*)|*.*";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var NewExcel = Environment.CurrentDirectory + "\\Sources\\Excels\\" + fileName;

                    File.Copy(filePath, NewExcel, true);

                    ExcelHelpers.InsertLogAllImagens(NewExcel);

                    File.Move(NewExcel, saveFileDialog.FileName, true);

                    MessageBox.Show("Arquivo salvo com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("A planilha não foi encontrada.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonExcluirDados_Click(object sender, EventArgs e)
        {
            SqLiteHelper.DeleteImagens();
            ListBoxImage.Items.Clear();
            MessageBox.Show("Todos os registros forão apagados", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}