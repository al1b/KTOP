using KTOP.EBookReader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTOP.Base
{
    public interface IBookEngine
    {
        IEBook ProcessBook(string bookPath);

        BookEngineConfig Config { get; set; }
    }
}
