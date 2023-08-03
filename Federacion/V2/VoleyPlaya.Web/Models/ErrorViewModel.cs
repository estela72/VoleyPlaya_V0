using System.Net;

namespace VoleyPlaya.Web.Models
{
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        public HttpStatusCode StatusCode { get; set; }
    }
}