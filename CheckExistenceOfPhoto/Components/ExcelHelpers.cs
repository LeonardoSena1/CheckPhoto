using CheckExistenceOfPhoto.Model;
using CheckExistenceOfPhoto.SqlHelper;
using ClosedXML.Excel;

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
    }
}
