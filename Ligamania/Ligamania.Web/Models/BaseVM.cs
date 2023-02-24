namespace Ligamania.Web.Models
{
    public class BaseVM
    {
        public bool Error { get; set; }

        public string Message { get; set; }
        public bool Loading { get; set; }

        public BaseVM()
        {
        }

        public BaseVM(string message) : this()
        {
            Message = message;
            Error = string.IsNullOrEmpty(message) ? false : true;
            Loading = false;
        }
        public void Set(bool error, string msg,bool loading=false)
        {
            this.Error = error;
            Message = this.Error ? "Error ":"Info ";
            Message += msg;
            Loading = loading;
        }
    }
}