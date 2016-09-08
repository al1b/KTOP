using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Globalization;

namespace KTOP.Helper
{
    public static class StringHelper
    {
        /// <summary>
        /// Ignore case when comparing two strings
        /// </summary>
        /// <param name="str1"></param>
        /// <param name="str2"></param>
        /// <returns></returns>
        public static bool CompareIgnoreCase(this string str1, string str2)
        {            
            return CultureInfo.CurrentCulture.CompareInfo.IndexOf(str1, str2, System.Globalization.CompareOptions.IgnoreCase) >= 0;
        }
    }
}
