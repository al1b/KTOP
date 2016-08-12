using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTOP.EBookReader
{
    public interface IEBook
    {
        FileInfo FileName { get; set; }
        List<string> Files { get; }

        string SaveAs(string path = null);

        void LoadFile(string fileName);


    }
}
