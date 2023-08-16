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

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
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

            IsEnabledButtons(false);

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
            IsEnabledButtons(true);
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
            MessageBox.Show("Todos os registros foram apagados", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void IsEnabledButtons(bool Input)
        {
            TextBoxLink.Enabled = Input;
            ButtonBuscar.Enabled = Input;
            ButtonDownload.Enabled = Input;
            ButtonExcluirDados.Enabled = Input;
            ButtonUpload.Enabled = Input;
        }

        private void ButtonUpload_Click(object sender, EventArgs e)
        {
            string[] allowedExtensions = { ".xlsx", ".xlsm", ".xltx", ".xltm" };

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Arquivos Excel (*.xlsx)|*.xlsx|Todos os Arquivos (*.*)|*.*";
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string FilePath = openFileDialog.FileName;

                    if (Array.Exists(allowedExtensions, ext => ext == Path.GetExtension(FilePath).ToLower()))
                    {
                        if (ExcelHelpers.VerificaPlanilhaParaImport(FilePath))
                        {
                            IsEnabledButtons(false);
                            HashSet<string> UrlsImport = ExcelHelpers.GetUrlsPlanilhaImport(FilePath);

                            foreach (var urlI in UrlsImport)
                            {
                                if (Ping.Image(urlI))
                                    SqLiteHelper.InsertImage(
                                        new Model.ImagensModel()
                                        {
                                            Url = urlI,
                                            Status = true
                                        });
                                else
                                    SqLiteHelper.InsertImage(
                                        new Model.ImagensModel()
                                        {
                                            Url = urlI,
                                            Status = false
                                        });
                            }

                            AtualizaListBoxImage();
                            IsEnabledButtons(true);
                        }
                        else
                            MessageBox.Show($"Planilha não confere, faça o download da planilha correta", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                        MessageBox.Show($"Extensão inválida. As extensões permitidas são: {string.Join(", ", allowedExtensions)}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string filePath = Environment.CurrentDirectory + "\\Sources\\Excels\\Planilha-Imagens-Upload.xlsx";
            string fileName = "Planilha-Modelo-" + Guid.NewGuid().ToString("N") + ".xlsx";

            if (File.Exists(filePath))
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.FileName = fileName;
                saveFileDialog.Filter = "Planilhas Excel (*.xlsx)|*.xlsx|Todos os arquivos (*.*)|*.*";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    File.Copy(filePath, saveFileDialog.FileName, true);

                    MessageBox.Show("Arquivo salvo com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("A planilha não foi encontrada.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}