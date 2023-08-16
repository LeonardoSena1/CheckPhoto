using CheckExistenceOfPhoto.Model;
using CheckExistenceOfPhoto.SqlHelper;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Drawing;

namespace CheckExistenceOfPhoto.Components
{
    public class ExcelHelpers
    {
        public static void InsertLogAllImagens(string FilePath)
        {
            using (var excelWorkbook = new XLWorkbook(FilePath))
            {
                var planilha = excelWorkbook.Worksheet(1);
                var linha = 2;

                List<ImagensModel> Models = SqLiteHelper.GetAllImagens();

                foreach (var model in Models)
                {
                    planilha.Cell("A" + linha.ToString()).Value = String.Format(model.Status ? "Encontrado" : "Não encontrado");
                    planilha.Cell("B" + linha.ToString()).Value = String.Format(model.Url);
                    linha++;
                }

                excelWorkbook.SaveAs(FilePath);
            }
        }

        public static bool VerificaPlanilhaParaImport(string FilePath)
        {
            using (var excelWorkbook = new XLWorkbook(FilePath))
                if (excelWorkbook.Worksheet(1).Cell("A1").Value.ToString().ToUpper().Equals("URL"))
                    return true;
                else
                    return false;
        }

        public static HashSet<string> GetUrlsPlanilhaImport(string FilePath)
        {
            HashSet<string> Models = new HashSet<string>();

            using (var excelWorkbook = new XLWorkbook(FilePath))
            {
                var planilha = excelWorkbook.Worksheet(1);
                var linha = 2;

                while (true)
                {
                    if (string.IsNullOrEmpty(planilha.Cell("A" + linha.ToString()).Value.ToString()))
                        break;

                    Models.Add(planilha.Cell("A" + linha.ToString()).Value.ToString());

                    linha++;
                }
            }

            return Models;
        }
    }
}
