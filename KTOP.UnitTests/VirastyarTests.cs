using KTOP.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using System.Xml;
using System.Xml.Linq;
using System.IO;

namespace KTOP.UnitTests
{
    public class VirastyarTests
    {
        [Fact]
        public void CheckSpellTest1()
        {
            var sampleString = "ویکی‌پدیای فارسی نام یکی از دانشنامه‌های فارسی‌زبان در اینترنت است. ویکی‌پدیای فارسی یکی از نسخه‌های ویکی‌پدیا، از پروژه‌های بنیاد ویکی‌مدیا است. ویکی‌پدیا پروژه بزرگی است که هدف آن ساخت دانشنامه‌هایی با محتوای آزاد با مشارکت همگان و به همهٔ زبان‌های ممکن است.";
            var dest = new SpellChecker().FixString(sampleString);

            Assert.Equal(sampleString, dest);
        }

        [Fact]
        public void CheckSpellTest2()
        {
            var sampleText = "می روم تنها بسوی دریا. بعنوان یک انسان تنها، شرکتهای زیادی اینچنین آنها اینها میخواندم خاندم.";
            var expected = "می‌روم تنها بسوی دریا. به عنوان یک انسان تنها، شرکتهای زیادی اینچنین آن‌ها این‌ها می‌خواندم خاندم.";

            var dest = new SpellChecker().FixString(sampleText);

            Assert.Equal(expected, dest);
        }

        /// <summary>
        /// Check if the xhtml is valid after check spell
        /// </summary>
        [Fact]
        public void CheckSPellTest3()
        {
            var xml = XDocument.Load("./SampleFiles/ch003.xhtml");

            var data = File.ReadAllText("./SampleFiles/ch003.xhtml", Encoding.UTF8);

            data = new SpellChecker().FixString(data);

            File.WriteAllText("./SampleFiles/ch004.xhtml", data);

            xml = XDocument.Load("./SampleFiles/ch004.xhtml");

        }
    }
}
