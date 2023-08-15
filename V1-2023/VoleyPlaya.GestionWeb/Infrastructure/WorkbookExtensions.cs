using Microsoft.Net.Http.Headers;

using NPOI.SS.UserModel;

namespace VoleyPlaya.GestionWeb.Infrastructure
{
    public static class WorkBookExtensions
    {

        public static void WriteExcelToResponse(this IWorkbook book, HttpContext httpContext, string templateName)
        {
            var response = httpContext.Response;
            response.ContentType = "application/vnd.ms-excel";
            if (!string.IsNullOrEmpty(templateName))
            {
                var contentDisposition = new Microsoft.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
                contentDisposition.SetHttpFileName(templateName);
                response.Headers[HeaderNames.ContentDisposition] = contentDisposition.ToString();
            }
            book.Write(response.Body,false);
        }
    }
}
