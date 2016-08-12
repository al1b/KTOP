using KTOP.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace KTOP.UnitTests
{
    public class StringHelperTests
    {
        [Fact]
        public void IgnoreCaseCompareTest()
        {
            Assert.Equal(StringHelper.CompareIgnoreCase("ABCDEFghijlmno", "ABCDEFGHIJLMNO"), true);

            Assert.Equal(StringHelper.CompareIgnoreCase("ABCDEFghijlmn", "ABCDEFGHIJLMNO"), false);

            Assert.Equal(StringHelper.CompareIgnoreCase("سلام", "سلام"), true);
        }
    }
}
