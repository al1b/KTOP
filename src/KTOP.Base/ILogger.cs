using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTOP.Base
{
    public interface ILogger
    {
        void Info(string message);
        void Warning(string message);
        void Error(string message);
    }

    public enum LogLevel
    {
        Info,
        Warning,
        Error
    }
}
