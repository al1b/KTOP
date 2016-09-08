using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTOP.Base
{
    public class BookEngineConfig
    {
        /// <summary>
        /// تبدیل ي و ک عربی به ی و ک فارس
        /// </summary>
        public bool FixArabicYeKe { get; set; }

        /// <summary>
        /// اصلاح پیشوندها و پسوندها مثلاً:
        /// شرکت ها => شرکت‌ها
        /// بعنوان => به عنوان
        /// می روم => می‌روم
        /// </summary>
        public bool FixVirtualSpaceAndPrefixSuffixes { get; set; }

        /// <summary>
        /// تبدیل کارکترهای فارسی به یونیکد آنها مثلاً:
        /// به جای نوشتن علی با حروف ع ل ی از ع اول، ل وسط و ی آخر استفاده شود
        /// </summary>
        public bool PersianShape { get; set; }
    }
}
