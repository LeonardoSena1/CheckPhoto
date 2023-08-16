using System.Net;

namespace CheckExistenceOfPhoto.Components
{
    public static class Ping
    {
        public static bool Image(string urlFoto)
        {
            if (String.IsNullOrWhiteSpace(urlFoto))
                return false;

            if (IsImageFile(urlFoto))
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = client.GetAsync(urlFoto).Result;
                    return response.StatusCode == HttpStatusCode.OK;
                }
            else
                return false;
        }

        public static bool IsImageFile(string filePath)
        {
            if (String.IsNullOrWhiteSpace(filePath))
                return false;

            string extension = Path.GetExtension(filePath)?.ToLower()!;

            if (extension == ".jpg" || extension == ".jpeg" || extension == ".png" ||
                extension == ".gif" || extension == ".bmp" || extension == ".tif" ||
                extension == ".tiff" || extension == ".webp" || extension == ".svg" ||
                extension == ".ico")
                return true;

            return false;
        }
    }
}
