// LGPL

using System;
using System.Text;

namespace ArabicShaping
{
    public class ArabicLigaturizer
    {
        private static char[][] chartable = new char[76][]
        {
      new char[2]
      {
        'ء',
        'ﺀ'
      },
      new char[3]
      {
        'آ',
        'ﺁ',
        'ﺂ'
      },
      new char[3]
      {
        'أ',
        'ﺃ',
        'ﺄ'
      },
      new char[3]
      {
        'ؤ',
        'ﺅ',
        'ﺆ'
      },
      new char[3]
      {
        'إ',
        'ﺇ',
        'ﺈ'
      },
      new char[5]
      {
        'ئ',
        'ﺉ',
        'ﺊ',
        'ﺋ',
        'ﺌ'
      },
      new char[3]
      {
        'ا',
        'ﺍ',
        'ﺎ'
      },
      new char[5]
      {
        'ب',
        'ﺏ',
        'ﺐ',
        'ﺑ',
        'ﺒ'
      },
      new char[3]
      {
        'ة',
        'ﺓ',
        'ﺔ'
      },
      new char[5]
      {
        'ت',
        'ﺕ',
        'ﺖ',
        'ﺗ',
        'ﺘ'
      },
      new char[5]
      {
        'ث',
        'ﺙ',
        'ﺚ',
        'ﺛ',
        'ﺜ'
      },
      new char[5]
      {
        'ج',
        'ﺝ',
        'ﺞ',
        'ﺟ',
        'ﺠ'
      },
      new char[5]
      {
        'ح',
        'ﺡ',
        'ﺢ',
        'ﺣ',
        'ﺤ'
      },
      new char[5]
      {
        'خ',
        'ﺥ',
        'ﺦ',
        'ﺧ',
        'ﺨ'
      },
      new char[3]
      {
        'د',
        'ﺩ',
        'ﺪ'
      },
      new char[3]
      {
        'ذ',
        'ﺫ',
        'ﺬ'
      },
      new char[3]
      {
        'ر',
        'ﺭ',
        'ﺮ'
      },
      new char[3]
      {
        'ز',
        'ﺯ',
        'ﺰ'
      },
      new char[5]
      {
        'س',
        'ﺱ',
        'ﺲ',
        'ﺳ',
        'ﺴ'
      },
      new char[5]
      {
        'ش',
        'ﺵ',
        'ﺶ',
        'ﺷ',
        'ﺸ'
      },
      new char[5]
      {
        'ص',
        'ﺹ',
        'ﺺ',
        'ﺻ',
        'ﺼ'
      },
      new char[5]
      {
        'ض',
        'ﺽ',
        'ﺾ',
        'ﺿ',
        'ﻀ'
      },
      new char[5]
      {
        'ط',
        'ﻁ',
        'ﻂ',
        'ﻃ',
        'ﻄ'
      },
      new char[5]
      {
        'ظ',
        'ﻅ',
        'ﻆ',
        'ﻇ',
        'ﻈ'
      },
      new char[5]
      {
        'ع',
        'ﻉ',
        'ﻊ',
        'ﻋ',
        'ﻌ'
      },
      new char[5]
      {
        'غ',
        'ﻍ',
        'ﻎ',
        'ﻏ',
        'ﻐ'
      },
      new char[5]
      {
        '\x0640',
        '\x0640',
        '\x0640',
        '\x0640',
        '\x0640'
      },
      new char[5]
      {
        'ف',
        'ﻑ',
        'ﻒ',
        'ﻓ',
        'ﻔ'
      },
      new char[5]
      {
        'ق',
        'ﻕ',
        'ﻖ',
        'ﻗ',
        'ﻘ'
      },
      new char[5]
      {
        'ك',
        'ﻙ',
        'ﻚ',
        'ﻛ',
        'ﻜ'
      },
      new char[5]
      {
        'ل',
        'ﻝ',
        'ﻞ',
        'ﻟ',
        'ﻠ'
      },
      new char[5]
      {
        'م',
        'ﻡ',
        'ﻢ',
        'ﻣ',
        'ﻤ'
      },
      new char[5]
      {
        'ن',
        'ﻥ',
        'ﻦ',
        'ﻧ',
        'ﻨ'
      },
      new char[5]
      {
        'ه',
        'ﻩ',
        'ﻪ',
        'ﻫ',
        'ﻬ'
      },
      new char[3]
      {
        'و',
        'ﻭ',
        'ﻮ'
      },
      new char[5]
      {
        'ى',
        'ﻯ',
        'ﻰ',
        'ﯨ',
        'ﯩ'
      },
      new char[5]
      {
        'ي',
        'ﻱ',
        'ﻲ',
        'ﻳ',
        'ﻴ'
      },
      new char[3]
      {
        'ٱ',
        'ﭐ',
        'ﭑ'
      },
      new char[5]
      {
        'ٹ',
        'ﭦ',
        'ﭧ',
        'ﭨ',
        'ﭩ'
      },
      new char[5]
      {
        'ٺ',
        'ﭞ',
        'ﭟ',
        'ﭠ',
        'ﭡ'
      },
      new char[5]
      {
        'ٻ',
        'ﭒ',
        'ﭓ',
        'ﭔ',
        'ﭕ'
      },
      new char[5]
      {
        'پ',
        'ﭖ',
        'ﭗ',
        'ﭘ',
        'ﭙ'
      },
      new char[5]
      {
        'ٿ',
        'ﭢ',
        'ﭣ',
        'ﭤ',
        'ﭥ'
      },
      new char[5]
      {
        'ڀ',
        'ﭚ',
        'ﭛ',
        'ﭜ',
        'ﭝ'
      },
      new char[5]
      {
        'ڃ',
        'ﭶ',
        'ﭷ',
        'ﭸ',
        'ﭹ'
      },
      new char[5]
      {
        'ڄ',
        'ﭲ',
        'ﭳ',
        'ﭴ',
        'ﭵ'
      },
      new char[5]
      {
        'چ',
        'ﭺ',
        'ﭻ',
        'ﭼ',
        'ﭽ'
      },
      new char[5]
      {
        'ڇ',
        'ﭾ',
        'ﭿ',
        'ﮀ',
        'ﮁ'
      },
      new char[3]
      {
        'ڈ',
        'ﮈ',
        'ﮉ'
      },
      new char[3]
      {
        'ڌ',
        'ﮄ',
        'ﮅ'
      },
      new char[3]
      {
        'ڍ',
        'ﮂ',
        'ﮃ'
      },
      new char[3]
      {
        'ڎ',
        'ﮆ',
        'ﮇ'
      },
      new char[3]
      {
        'ڑ',
        'ﮌ',
        'ﮍ'
      },
      new char[3]
      {
        'ژ',
        'ﮊ',
        'ﮋ'
      },
      new char[5]
      {
        'ڤ',
        'ﭪ',
        'ﭫ',
        'ﭬ',
        'ﭭ'
      },
      new char[5]
      {
        'ڦ',
        'ﭮ',
        'ﭯ',
        'ﭰ',
        'ﭱ'
      },
      new char[5]
      {
        'ک',
        'ﮎ',
        'ﮏ',
        'ﮐ',
        'ﮑ'
      },
      new char[5]
      {
        'ڭ',
        'ﯓ',
        'ﯔ',
        'ﯕ',
        'ﯖ'
      },
      new char[5]
      {
        'گ',
        'ﮒ',
        'ﮓ',
        'ﮔ',
        'ﮕ'
      },
      new char[5]
      {
        'ڱ',
        'ﮚ',
        'ﮛ',
        'ﮜ',
        'ﮝ'
      },
      new char[5]
      {
        'ڳ',
        'ﮖ',
        'ﮗ',
        'ﮘ',
        'ﮙ'
      },
      new char[3]
      {
        'ں',
        'ﮞ',
        'ﮟ'
      },
      new char[5]
      {
        'ڻ',
        'ﮠ',
        'ﮡ',
        'ﮢ',
        'ﮣ'
      },
      new char[5]
      {
        'ھ',
        'ﮪ',
        'ﮫ',
        'ﮬ',
        'ﮭ'
      },
      new char[3]
      {
        'ۀ',
        'ﮤ',
        'ﮥ'
      },
      new char[5]
      {
        'ہ',
        'ﮦ',
        'ﮧ',
        'ﮨ',
        'ﮩ'
      },
      new char[3]
      {
        'ۅ',
        'ﯠ',
        'ﯡ'
      },
      new char[3]
      {
        'ۆ',
        'ﯙ',
        'ﯚ'
      },
      new char[3]
      {
        'ۇ',
        'ﯗ',
        'ﯘ'
      },
      new char[3]
      {
        'ۈ',
        'ﯛ',
        'ﯜ'
      },
      new char[3]
      {
        'ۉ',
        'ﯢ',
        'ﯣ'
      },
      new char[3]
      {
        'ۋ',
        'ﯞ',
        'ﯟ'
      },
      new char[5]
      {
        'ی',
        'ﯼ',
        'ﯽ',
        'ﯾ',
        'ﯿ'
      },
      new char[5]
      {
        'ې',
        'ﯤ',
        'ﯥ',
        'ﯦ',
        'ﯧ'
      },
      new char[3]
      {
        'ے',
        'ﮮ',
        'ﮯ'
      },
      new char[3]
      {
        'ۓ',
        'ﮰ',
        'ﮱ'
      }
        };
        private const char ALEF = 'ا';
        private const char ALEFHAMZA = 'أ';
        private const char ALEFHAMZABELOW = 'إ';
        private const char ALEFMADDA = 'آ';
        private const char LAM = 'ل';
        private const char HAMZA = 'ء';
        private const char TATWEEL = '\x0640';
        private const char ZWJ = '\x200D';
        private const char HAMZAABOVE = 'ٔ';
        private const char HAMZABELOW = 'ٕ';
        private const char WAWHAMZA = 'ؤ';
        private const char YEHHAMZA = 'ئ';
        private const char WAW = 'و';
        private const char ALEFMAKSURA = 'ى';
        private const char YEH = 'ي';
        private const char FARSIYEH = 'ی';
        private const char SHADDA = 'ّ';
        private const char KASRA = 'ِ';
        private const char FATHA = 'َ';
        private const char DAMMA = 'ُ';
        private const char MADDA = 'ٓ';
        private const char LAM_ALEF = 'ﻻ';
        private const char LAM_ALEFHAMZA = 'ﻷ';
        private const char LAM_ALEFHAMZABELOW = 'ﻹ';
        private const char LAM_ALEFMADDA = 'ﻵ';
        public const int ar_nothing = 0;
        public const int ar_novowel = 1;
        public const int ar_composedtashkeel = 4;
        public const int ar_lig = 8;
        public const int DIGITS_EN2AN = 32;
        public const int DIGITS_AN2EN = 64;
        public const int DIGITS_EN2AN_INIT_LR = 96;
        public const int DIGITS_EN2AN_INIT_AL = 128;
        private const int DIGITS_RESERVED = 160;
        public const int DIGITS_MASK = 224;
        public const int DIGIT_TYPE_AN = 0;
        public const int DIGIT_TYPE_AN_EXTENDED = 256;
        public const int DIGIT_TYPE_MASK = 256;

        private static bool IsVowel(char s)
        {
            if ((int)s < 1611 || (int)s > 1621)
                return (int)s == 1648;
            return true;
        }

        private static char Charshape(char s, int which)
        {
            if ((int)s >= 1569 && (int)s <= 1747)
            {
                int num1 = 0;
                int num2 = ArabicLigaturizer.chartable.Length - 1;
                while (num1 <= num2)
                {
                    int index = (num1 + num2) / 2;
                    if ((int)s == (int)ArabicLigaturizer.chartable[index][0])
                        return ArabicLigaturizer.chartable[index][which + 1];
                    if ((int)s < (int)ArabicLigaturizer.chartable[index][0])
                        num2 = index - 1;
                    else
                        num1 = index + 1;
                }
            }
            else if ((int)s >= 65269 && (int)s <= 65275)
                return (char)((uint)s + (uint)which);
            return s;
        }

        private static int Shapecount(char s)
        {
            if ((int)s >= 1569 && (int)s <= 1747 && !ArabicLigaturizer.IsVowel(s))
            {
                int num1 = 0;
                int num2 = ArabicLigaturizer.chartable.Length - 1;
                while (num1 <= num2)
                {
                    int index = (num1 + num2) / 2;
                    if ((int)s == (int)ArabicLigaturizer.chartable[index][0])
                        return ArabicLigaturizer.chartable[index].Length - 1;
                    if ((int)s < (int)ArabicLigaturizer.chartable[index][0])
                        num2 = index - 1;
                    else
                        num1 = index + 1;
                }
            }
            else if ((int)s == 8205)
                return 4;
            return 1;
        }

        private static int Ligature(char newchar, ArabicLigaturizer.Charstruct oldchar)
        {
            int num1 = 0;
            if ((int)oldchar.basechar == 0)
                return 0;
            if (ArabicLigaturizer.IsVowel(newchar))
            {
                int num2 = 1;
                if ((int)oldchar.vowel != 0 && (int)newchar != 1617)
                    num2 = 2;
                switch (newchar)
                {
                    case 'ّ':
                        if ((int)oldchar.mark1 != 0)
                            return 0;
                        oldchar.mark1 = 'ّ';
                        break;
                    case 'ٓ':
                        if ((int)oldchar.basechar == 1575)
                        {
                            oldchar.basechar = 'آ';
                            num2 = 2;
                            break;
                        }
                        break;
                    case 'ٔ':
                        switch (oldchar.basechar)
                        {
                            case 'ی':
                            case 'ى':
                            case 'ي':
                                oldchar.basechar = 'ئ';
                                num2 = 2;
                                break;
                            case 'ﻻ':
                                oldchar.basechar = 'ﻷ';
                                num2 = 2;
                                break;
                            case 'ا':
                                oldchar.basechar = 'أ';
                                num2 = 2;
                                break;
                            case 'و':
                                oldchar.basechar = 'ؤ';
                                num2 = 2;
                                break;
                            default:
                                oldchar.mark1 = 'ٔ';
                                break;
                        }
                        break;
                    case 'ٕ':
                        switch (oldchar.basechar)
                        {
                            case 'ا':
                                oldchar.basechar = 'إ';
                                num2 = 2;
                                break;
                            case 'ﻻ':
                                oldchar.basechar = 'ﻹ';
                                num2 = 2;
                                break;
                            default:
                                oldchar.mark1 = 'ٕ';
                                break;
                        }
                        break;
                    default:
                        oldchar.vowel = newchar;
                        break;
                }
                if (num2 == 1)
                    ++oldchar.lignum;
                return num2;
            }
            if ((int)oldchar.vowel != 0)
                return 0;
            switch (oldchar.basechar)
            {
                case char.MinValue:
                    oldchar.basechar = newchar;
                    oldchar.numshapes = ArabicLigaturizer.Shapecount(newchar);
                    num1 = 1;
                    break;
                case 'ل':
                    switch (newchar)
                    {
                        case 'آ':
                            oldchar.basechar = 'ﻵ';
                            oldchar.numshapes = 2;
                            num1 = 3;
                            break;
                        case 'أ':
                            oldchar.basechar = 'ﻷ';
                            oldchar.numshapes = 2;
                            num1 = 3;
                            break;
                        case 'إ':
                            oldchar.basechar = 'ﻹ';
                            oldchar.numshapes = 2;
                            num1 = 3;
                            break;
                        case 'ا':
                            oldchar.basechar = 'ﻻ';
                            oldchar.numshapes = 2;
                            num1 = 3;
                            break;
                    }
                    break;
            }
            return num1;
        }

        private static void Copycstostring(StringBuilder str, ArabicLigaturizer.Charstruct s, int level)
        {
            if ((int)s.basechar == 0)
                return;
            str.Append(s.basechar);
            --s.lignum;
            if ((int)s.mark1 != 0)
            {
                if ((level & 1) == 0)
                {
                    str.Append(s.mark1);
                    --s.lignum;
                }
                else
                    --s.lignum;
            }
            if ((int)s.vowel == 0)
                return;
            if ((level & 1) == 0)
            {
                str.Append(s.vowel);
                --s.lignum;
            }
            else
                --s.lignum;
        }

        internal static void Doublelig(StringBuilder str, int level)
        {
            int length;
            int num = length = str.Length;
            int index1 = 0;
            int index2 = 1;
            while (index2 < num)
            {
                char ch = char.MinValue;
                if ((level & 4) != 0)
                {
                    switch (str[index1])
                    {
                        case 'َ':
                            if ((int)str[index2] == 1617)
                            {
                                ch = 'ﱠ';
                                break;
                            }
                            break;
                        case 'ُ':
                            if ((int)str[index2] == 1617)
                            {
                                ch = 'ﱡ';
                                break;
                            }
                            break;
                        case 'ِ':
                            if ((int)str[index2] == 1617)
                            {
                                ch = 'ﱢ';
                                break;
                            }
                            break;
                        case 'ّ':
                            switch (str[index2])
                            {
                                case 'ٌ':
                                    ch = 'ﱞ';
                                    break;
                                case 'ٍ':
                                    ch = 'ﱟ';
                                    break;
                                case 'َ':
                                    ch = 'ﱠ';
                                    break;
                                case 'ُ':
                                    ch = 'ﱡ';
                                    break;
                                case 'ِ':
                                    ch = 'ﱢ';
                                    break;
                            }
                            break;
                    }
                }
                if ((level & 8) != 0)
                {
                    switch (str[index1])
                    {
                        case 'ﻟ':
                            switch (str[index2])
                            {
                                case 'ﺞ':
                                    ch = 'ﰿ';
                                    break;
                                case 'ﺠ':
                                    ch = 'ﳉ';
                                    break;
                                case 'ﺢ':
                                    ch = 'ﱀ';
                                    break;
                                case 'ﺤ':
                                    ch = 'ﳊ';
                                    break;
                                case 'ﺦ':
                                    ch = 'ﱁ';
                                    break;
                                case 'ﺨ':
                                    ch = 'ﳋ';
                                    break;
                                case 'ﻢ':
                                    ch = 'ﱂ';
                                    break;
                                case 'ﻤ':
                                    ch = 'ﳌ';
                                    break;
                            }
                            break;
                        case 'ﻣ':
                            switch (str[index2])
                            {
                                case 'ﺨ':
                                    ch = 'ﳐ';
                                    break;
                                case 'ﻤ':
                                    ch = 'ﳑ';
                                    break;
                                case 'ﺠ':
                                    ch = 'ﳎ';
                                    break;
                                case 'ﺤ':
                                    ch = 'ﳏ';
                                    break;
                            }
                            break;
                        case 'ﻧ':
                            switch (str[index2])
                            {
                                case 'ﺠ':
                                    ch = 'ﳒ';
                                    break;
                                case 'ﺤ':
                                    ch = 'ﳓ';
                                    break;
                                case 'ﺨ':
                                    ch = 'ﳔ';
                                    break;
                            }
                            break;

                        case 'ﻨ':
                            switch (str[index2])
                            {
                                case 'ﺮ':
                                    ch = 'ﲊ';
                                    break;
                                case 'ﺰ':
                                    ch = 'ﲋ';
                                    break;
                            }
                            break;
                        case 'ﺑ':
                            switch (str[index2])
                            {
                                case 'ﺠ':
                                    ch = 'ﲜ';
                                    break;
                                case 'ﺤ':
                                    ch = 'ﲝ';
                                    break;
                                case 'ﺨ':
                                    ch = 'ﲞ';
                                    break;
                            }
                            break;
                        case 'ﺗ':
                            switch (str[index2])
                            {
                                case 'ﺠ':
                                    ch = 'ﲡ';
                                    break;
                                case 'ﺤ':
                                    ch = 'ﲢ';
                                    break;
                                case 'ﺨ':
                                    ch = 'ﲣ';
                                    break;
                            }
                            break;
                        case 'ﻓ':
                            if ((int)str[index2] == 65266)
                            {
                                ch = 'ﰲ';
                                break;
                            }
                            break;
                    }
                }
                if ((int)ch != 0)
                {
                    str[index1] = ch;
                    --length;
                    ++index2;
                }
                else
                {
                    ++index1;
                    str[index1] = str[index2];
                    ++index2;
                }
            }
            str.Length = length;
        }

        private static bool Connects_to_left(ArabicLigaturizer.Charstruct a)
        {
            return a.numshapes > 2;
        }

        internal static void Shape(char[] text, StringBuilder str, int level)
        {
            int num1 = 0;
            ArabicLigaturizer.Charstruct charstruct1 = new ArabicLigaturizer.Charstruct();
            ArabicLigaturizer.Charstruct charstruct2 = new ArabicLigaturizer.Charstruct();
            while (num1 < text.Length)
            {
                char ch = text[num1++];
                if (ArabicLigaturizer.Ligature(ch, charstruct2) == 0)
                {
                    int num2 = ArabicLigaturizer.Shapecount(ch);
                    int num3 = num2 != 1 ? 2 : 0;
                    if (ArabicLigaturizer.Connects_to_left(charstruct1))
                        ++num3;
                    int which = num3 % charstruct2.numshapes;
                    charstruct2.basechar = ArabicLigaturizer.Charshape(charstruct2.basechar, which);
                    ArabicLigaturizer.Copycstostring(str, charstruct1, level);
                    charstruct1 = charstruct2;
                    charstruct2 = new ArabicLigaturizer.Charstruct();
                    charstruct2.basechar = ch;
                    charstruct2.numshapes = num2;
                    ++charstruct2.lignum;
                }
            }
            int which1 = (!ArabicLigaturizer.Connects_to_left(charstruct1) ? 0 : 1) % charstruct2.numshapes;
            charstruct2.basechar = ArabicLigaturizer.Charshape(charstruct2.basechar, which1);
            ArabicLigaturizer.Copycstostring(str, charstruct1, level);
            ArabicLigaturizer.Copycstostring(str, charstruct2, level);
        }

        public static int ArabicShape(char[] src, int srcoffset, int srclength, char[] dest, int destoffset, int destlength, int level)
        {
            char[] text = new char[srclength];
            for (int index = srclength + srcoffset - 1; index >= srcoffset; --index)
                text[index - srcoffset] = src[index];
            StringBuilder str = new StringBuilder(srclength);
            ArabicLigaturizer.Shape(text, str, level);
            if ((level & 12) != 0)
                ArabicLigaturizer.Doublelig(str, level);
            Array.Copy((Array)str.ToString().ToCharArray(), 0, (Array)dest, destoffset, str.Length);
            return str.Length;
        }

        public static string ArabicShape(string input, int level = 4)
        {
            var chArray = input.ToCharArray();
            var dest = new char[chArray.Length];

            ArabicShape(chArray, 0, chArray.Length, dest, 0, dest.Length, level);

            return new string(dest);
        }

        internal static void ProcessNumbers(char[] text, int offset, int length, int options)
        {
            int num1 = offset + length;
            if ((options & 224) == 0)
                return;
            char digitBase = '0';
            switch (options & 256)
            {
                case 0:
                    digitBase = '٠';
                    break;
                case 256:
                    digitBase = '۰';
                    break;
            }
            switch (options & 224)
            {
                case 96:
                    ArabicLigaturizer.ShapeToArabicDigitsWithContext(text, 0, length, digitBase, false);
                    break;
                case 128:
                    ArabicLigaturizer.ShapeToArabicDigitsWithContext(text, 0, length, digitBase, true);
                    break;
                case 32:
                    int num2 = (int)digitBase - 48;
                    for (int index = offset; index < num1; ++index)
                    {
                        char ch = text[index];
                        if ((int)ch <= 57 && (int)ch >= 48)
                            text[index] += (char)num2;
                    }
                    break;
                case 64:
                    char ch1 = (char)((uint)digitBase + 9U);
                    int num3 = 48 - (int)digitBase;
                    for (int index = offset; index < num1; ++index)
                    {
                        char ch2 = text[index];
                        if ((int)ch2 <= (int)ch1 && (int)ch2 >= (int)digitBase)
                            text[index] += (char)num3;
                    }
                    break;
            }
        }

        internal static void ShapeToArabicDigitsWithContext(char[] dest, int start, int length, char digitBase, bool lastStrongWasAL)
        {
            digitBase -= '0';
            int num = start + length;
            for (int index = start; index < num; ++index)
            {
                char c = dest[index];
                switch (BidiOrder.GetDirection(c))
                {
                    case (sbyte)0:
                    case (sbyte)3:
                        lastStrongWasAL = false;
                        break;
                    case (sbyte)4:
                        lastStrongWasAL = true;
                        break;
                    case (sbyte)8:
                        if (lastStrongWasAL && (int)c <= 57)
                        {
                            dest[index] = (char)((uint)c + (uint)digitBase);
                            break;
                        }
                        break;
                }
            }
        }

        private class Charstruct
        {
            internal int numshapes = 1;
            internal char basechar;
            internal char mark1;
            internal char vowel;
            internal int lignum;
        }
    }
}
