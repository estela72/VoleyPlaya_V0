using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoleyPlaya
{
    public interface IFilePicker
    {
        Task<string> PickFile();
    }
}
