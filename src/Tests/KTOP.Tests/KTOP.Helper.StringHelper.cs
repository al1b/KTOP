using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace KTOP.Helper.Tests
{
    public class StringHelperTest
    {
        [Fact]
        public void CompareIgnoreCaseTest()
        {
            Assert.Equal(StringHelper.CompareIgnoreCase("ABCDEFghijlmno", "ABCDEFGHIJLMNO"), true);

            Assert.Equal(StringHelper.CompareIgnoreCase("ABCDEFghijlmn", "ABCDEFGHIJLMNO"), false);

            Assert.Equal(StringHelper.CompareIgnoreCase("سلام", "سلام"), true);
        }
    }
}
