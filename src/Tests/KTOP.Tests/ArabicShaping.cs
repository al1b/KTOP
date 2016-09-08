using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace ArabicShaping.Tests
{
    public class ArabicShaping
    {
        [Fact]
        public void ArabicShape()
        {
            var samples = new List<string>();
            samples.Add("ﻧﮑﺘﻪﻫﺎﯼ");
            samples.Add("فرمت‌های");
            samples.Add("می¬رویم");


            var expected = new List<string>();
            expected.Add("ﻧﮑﺘﻪﻫﺎﯼ");
            expected.Add("ﻓﺮﻣﺖ‌ﻫﺎﯼ");
            expected.Add("ﻣﯽ¬ﺭﻭﯾﻢ");

            for (var i = 0; i < samples.Count; i++)
            {
                var dest = global::ArabicShaping.ArabicLigaturizer.ArabicShape(samples[i]);
                Assert.Equal(expected[i], dest);
            }
        }
    }
}
