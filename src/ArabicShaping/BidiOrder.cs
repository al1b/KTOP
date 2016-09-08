// LGPL

using System;

namespace ArabicShaping
{
  public sealed class BidiOrder
  {
    private static sbyte[] rtypes = new sbyte[65536];
    private static char[] baseTypes = new char[1725]
    {
      char.MinValue,
      '\b',
      '\x000E',
      '\t',
      '\t',
      '\x0010',
      '\n',
      '\n',
      '\x000F',
      '\v',
      '\v',
      '\x0010',
      '\f',
      '\f',
      '\x0011',
      '\r',
      '\r',
      '\x000F',
      '\x000E',
      '\x001B',
      '\x000E',
      '\x001C',
      '\x001E',
      '\x000F',
      '\x001F',
      '\x001F',
      '\x0010',
      ' ',
      ' ',
      '\x0011',
      '!',
      '"',
      '\x0012',
      '#',
      '%',
      '\n',
      '&',
      '*',
      '\x0012',
      '+',
      '+',
      '\n',
      ',',
      ',',
      '\f',
      '-',
      '-',
      '\n',
      '.',
      '.',
      '\f',
      '/',
      '/',
      '\t',
      '0',
      '9',
      '\b',
      ':',
      ':',
      '\f',
      ';',
      '@',
      '\x0012',
      'A',
      'Z',
      char.MinValue,
      '[',
      '`',
      '\x0012',
      'a',
      'z',
      char.MinValue,
      '{',
      '~',
      '\x0012',
      '\x007F',
      '\x0084',
      '\x000E',
      '\x0085',
      '\x0085',
      '\x000F',
      '\x0086',
      '\x009F',
      '\x000E',
      ' ',
      ' ',
      '\f',
      '¡',
      '¡',
      '\x0012',
      '¢',
      '¥',
      '\n',
      '¦',
      '©',
      '\x0012',
      'ª',
      'ª',
      char.MinValue,
      '«',
      '¯',
      '\x0012',
      '°',
      '±',
      '\n',
      '\x00B2',
      '\x00B3',
      '\b',
      '´',
      '´',
      '\x0012',
      'µ',
      'µ',
      char.MinValue,
      '¶',
      '¸',
      '\x0012',
      '\x00B9',
      '\x00B9',
      '\b',
      'º',
      'º',
      char.MinValue,
      '»',
      '¿',
      '\x0012',
      'À',
      'Ö',
      char.MinValue,
      '×',
      '×',
      '\x0012',
      'Ø',
      'ö',
      char.MinValue,
      '÷',
      '÷',
      '\x0012',
      'ø',
      '\x02B8',
      char.MinValue,
      '\x02B9',
      '\x02BA',
      '\x0012',
      '\x02BB',
      '\x02C1',
      char.MinValue,
      '˂',
      '\x02CF',
      '\x0012',
      '\x02D0',
      '\x02D1',
      char.MinValue,
      '˒',
      '˟',
      '\x0012',
      '\x02E0',
      '\x02E4',
      char.MinValue,
      '˥',
      '˭',
      '\x0012',
      '\x02EE',
      '\x02EE',
      char.MinValue,
      '˯',
      '˿',
      '\x0012',
      '̀',
      '͗',
      '\r',
      '͘',
      '͜',
      char.MinValue,
      '͝',
      'ͯ',
      '\r',
      'Ͱ',
      'ͳ',
      char.MinValue,
      '\x0374',
      '͵',
      '\x0012',
      'Ͷ',
      'ͽ',
      char.MinValue,
      ';',
      ';',
      '\x0012',
      '\x037F',
      '\x0383',
      char.MinValue,
      '΄',
      '΅',
      '\x0012',
      'Ά',
      'Ά',
      char.MinValue,
      '·',
      '·',
      '\x0012',
      'Έ',
      'ϵ',
      char.MinValue,
      '϶',
      '϶',
      '\x0012',
      'Ϸ',
      '҂',
      char.MinValue,
      '҃',
      '҆',
      '\r',
      '҇',
      '҇',
      char.MinValue,
      '҈',
      '҉',
      '\r',
      'Ҋ',
      '։',
      char.MinValue,
      '֊',
      '֊',
      '\x0012',
      '\x058B',
      '\x0590',
      char.MinValue,
      '֑',
      '֡',
      '\r',
      '֢',
      '֢',
      char.MinValue,
      '֣',
      'ֹ',
      '\r',
      'ֺ',
      'ֺ',
      char.MinValue,
      'ֻ',
      'ֽ',
      '\r',
      '־',
      '־',
      '\x0003',
      'ֿ',
      'ֿ',
      '\r',
      '׀',
      '׀',
      '\x0003',
      'ׁ',
      'ׂ',
      '\r',
      '׃',
      '׃',
      '\x0003',
      'ׄ',
      'ׄ',
      '\r',
      'ׅ',
      '\x05CF',
      char.MinValue,
      'א',
      'ת',
      '\x0003',
      '\x05EB',
      '\x05EF',
      char.MinValue,
      'װ',
      '״',
      '\x0003',
      '\x05F5',
      '\x05FF',
      char.MinValue,
      '\x0600',
      '\x0603',
      '\x0004',
      '\x0604',
      '؋',
      char.MinValue,
      '،',
      '،',
      '\f',
      '؍',
      '؍',
      '\x0004',
      '؎',
      '؏',
      '\x0012',
      'ؐ',
      'ؕ',
      '\r',
      'ؖ',
      'ؚ',
      char.MinValue,
      '؛',
      '؛',
      '\x0004',
      '\x061C',
      '؞',
      char.MinValue,
      '؟',
      '؟',
      '\x0004',
      'ؠ',
      'ؠ',
      char.MinValue,
      'ء',
      'غ',
      '\x0004',
      'ػ',
      'ؿ',
      char.MinValue,
      '\x0640',
      'ي',
      '\x0004',
      'ً',
      '٘',
      '\r',
      'ٙ',
      'ٟ',
      char.MinValue,
      '٠',
      '٩',
      '\v',
      '٪',
      '٪',
      '\n',
      '٫',
      '٬',
      '\v',
      '٭',
      'ٯ',
      '\x0004',
      'ٰ',
      'ٰ',
      '\r',
      'ٱ',
      'ە',
      '\x0004',
      'ۖ',
      'ۜ',
      '\r',
      '\x06DD',
      '\x06DD',
      '\x0004',
      '۞',
      'ۤ',
      '\r',
      '\x06E5',
      '\x06E6',
      '\x0004',
      'ۧ',
      'ۨ',
      '\r',
      '۩',
      '۩',
      '\x0012',
      '۪',
      'ۭ',
      '\r',
      'ۮ',
      'ۯ',
      '\x0004',
      '۰',
      '۹',
      '\b',
      'ۺ',
      '܍',
      '\x0004',
      '\x070E',
      '\x070E',
      char.MinValue,
      '\x070F',
      '\x070F',
      '\x000E',
      'ܐ',
      'ܐ',
      '\x0004',
      'ܑ',
      'ܑ',
      '\r',
      'ܒ',
      'ܯ',
      '\x0004',
      'ܰ',
      '݊',
      '\r',
      '\x074B',
      '\x074C',
      char.MinValue,
      'ݍ',
      'ݏ',
      '\x0004',
      'ݐ',
      'ݿ',
      char.MinValue,
      'ހ',
      'ޥ',
      '\x0004',
      'ަ',
      'ް',
      '\r',
      'ޱ',
      'ޱ',
      '\x0004',
      '\x07B2',
      'ऀ',
      char.MinValue,
      'ँ',
      'ं',
      '\r',
      'ः',
      'ऻ',
      char.MinValue,
      '़',
      '़',
      '\r',
      'ऽ',
      'ी',
      char.MinValue,
      'ु',
      'ै',
      '\r',
      'ॉ',
      'ौ',
      char.MinValue,
      '्',
      '्',
      '\r',
      'ॎ',
      'ॐ',
      char.MinValue,
      '॑',
      '॔',
      '\r',
      'ॕ',
      'ॡ',
      char.MinValue,
      'ॢ',
      'ॣ',
      '\r',
      '।',
      '\x0980',
      char.MinValue,
      'ঁ',
      'ঁ',
      '\r',
      'ং',
      '\x09BB',
      char.MinValue,
      '়',
      '়',
      '\r',
      'ঽ',
      'ী',
      char.MinValue,
      'ু',
      'ৄ',
      '\r',
      '\x09C5',
      'ৌ',
      char.MinValue,
      '্',
      '্',
      '\r',
      'ৎ',
      'ৡ',
      char.MinValue,
      'ৢ',
      'ৣ',
      '\r',
      '\x09E4',
      'ৱ',
      char.MinValue,
      '৲',
      '৳',
      '\n',
      '\x09F4',
      '\x0A00',
      char.MinValue,
      'ਁ',
      'ਂ',
      '\r',
      'ਃ',
      '\x0A3B',
      char.MinValue,
      '਼',
      '਼',
      '\r',
      '\x0A3D',
      'ੀ',
      char.MinValue,
      'ੁ',
      'ੂ',
      '\r',
      '\x0A43',
      '\x0A46',
      char.MinValue,
      'ੇ',
      'ੈ',
      '\r',
      '\x0A49',
      '\x0A4A',
      char.MinValue,
      'ੋ',
      '੍',
      '\r',
      '\x0A4E',
      '੯',
      char.MinValue,
      'ੰ',
      'ੱ',
      '\r',
      'ੲ',
      '\x0A80',
      char.MinValue,
      'ઁ',
      'ં',
      '\r',
      'ઃ',
      '\x0ABB',
      char.MinValue,
      '઼',
      '઼',
      '\r',
      'ઽ',
      'ી',
      char.MinValue,
      'ુ',
      'ૅ',
      '\r',
      '\x0AC6',
      '\x0AC6',
      char.MinValue,
      'ે',
      'ૈ',
      '\r',
      'ૉ',
      'ૌ',
      char.MinValue,
      '્',
      '્',
      '\r',
      '\x0ACE',
      'ૡ',
      char.MinValue,
      'ૢ',
      'ૣ',
      '\r',
      '\x0AE4',
      '૰',
      char.MinValue,
      '૱',
      '૱',
      '\n',
      '\x0AF2',
      '\x0B00',
      char.MinValue,
      'ଁ',
      'ଁ',
      '\r',
      'ଂ',
      '\x0B3B',
      char.MinValue,
      '଼',
      '଼',
      '\r',
      'ଽ',
      'ା',
      char.MinValue,
      'ି',
      'ି',
      '\r',
      'ୀ',
      'ୀ',
      char.MinValue,
      'ୁ',
      'ୃ',
      '\r',
      'ୄ',
      'ୌ',
      char.MinValue,
      '୍',
      '୍',
      '\r',
      '\x0B4E',
      '\x0B55',
      char.MinValue,
      'ୖ',
      'ୖ',
      '\r',
      'ୗ',
      '\x0B81',
      char.MinValue,
      'ஂ',
      'ஂ',
      '\r',
      'ஃ',
      'ி',
      char.MinValue,
      'ீ',
      'ீ',
      '\r',
      'ு',
      'ௌ',
      char.MinValue,
      '்',
      '்',
      '\r',
      '\x0BCE',
      '\x0BF2',
      char.MinValue,
      '௳',
      '௸',
      '\x0012',
      '௹',
      '௹',
      '\n',
      '௺',
      '௺',
      '\x0012',
      '\x0BFB',
      'ఽ',
      char.MinValue,
      'ా',
      'ీ',
      '\r',
      'ు',
      '\x0C45',
      char.MinValue,
      'ె',
      'ై',
      '\r',
      '\x0C49',
      '\x0C49',
      char.MinValue,
      'ొ',
      '్',
      '\r',
      '\x0C4E',
      '\x0C54',
      char.MinValue,
      'ౕ',
      'ౖ',
      '\r',
      '\x0C57',
      '\x0CBB',
      char.MinValue,
      '಼',
      '಼',
      '\r',
      'ಽ',
      'ೋ',
      char.MinValue,
      'ೌ',
      '್',
      '\r',
      '\x0CCE',
      'ീ',
      char.MinValue,
      'ു',
      'ൃ',
      '\r',
      'ൄ',
      'ൌ',
      char.MinValue,
      '്',
      '്',
      '\r',
      'ൎ',
      '\x0DC9',
      char.MinValue,
      '්',
      '්',
      '\r',
      '\x0DCB',
      'ෑ',
      char.MinValue,
      'ි',
      'ු',
      '\r',
      '\x0DD5',
      '\x0DD5',
      char.MinValue,
      'ූ',
      'ූ',
      '\r',
      '\x0DD7',
      'ะ',
      char.MinValue,
      'ั',
      'ั',
      '\r',
      'า',
      'ำ',
      char.MinValue,
      'ิ',
      'ฺ',
      '\r',
      '\x0E3B',
      '\x0E3E',
      char.MinValue,
      '฿',
      '฿',
      '\n',
      'เ',
      '\x0E46',
      char.MinValue,
      '็',
      '๎',
      '\r',
      '๏',
      'ະ',
      char.MinValue,
      'ັ',
      'ັ',
      '\r',
      'າ',
      'ຳ',
      char.MinValue,
      'ິ',
      'ູ',
      '\r',
      '\x0EBA',
      '\x0EBA',
      char.MinValue,
      'ົ',
      'ຼ',
      '\r',
      'ຽ',
      '\x0EC7',
      char.MinValue,
      '່',
      'ໍ',
      '\r',
      '\x0ECE',
      '༗',
      char.MinValue,
      '༘',
      '༙',
      '\r',
      '༚',
      '༴',
      char.MinValue,
      '༵',
      '༵',
      '\r',
      '༶',
      '༶',
      char.MinValue,
      '༷',
      '༷',
      '\r',
      '༸',
      '༸',
      char.MinValue,
      '༹',
      '༹',
      '\r',
      '༺',
      '༽',
      '\x0012',
      '༾',
      '\x0F70',
      char.MinValue,
      'ཱ',
      'ཾ',
      '\r',
      'ཿ',
      'ཿ',
      char.MinValue,
      'ྀ',
      '྄',
      '\r',
      '྅',
      '྅',
      char.MinValue,
      '྆',
      '྇',
      '\r',
      'ྈ',
      'ྏ',
      char.MinValue,
      'ྐ',
      'ྗ',
      '\r',
      '\x0F98',
      '\x0F98',
      char.MinValue,
      'ྙ',
      'ྼ',
      '\r',
      '\x0FBD',
      '࿅',
      char.MinValue,
      '࿆',
      '࿆',
      '\r',
      '࿇',
      'ာ',
      char.MinValue,
      'ိ',
      'ူ',
      '\r',
      'ေ',
      'ေ',
      char.MinValue,
      'ဲ',
      'ဲ',
      '\r',
      'ဳ',
      'ဵ',
      char.MinValue,
      'ံ',
      '့',
      '\r',
      'း',
      'း',
      char.MinValue,
      '္',
      '္',
      '\r',
      '်',
      'ၗ',
      char.MinValue,
      'ၘ',
      'ၙ',
      '\r',
      'ၚ',
      'ᙿ',
      char.MinValue,
      ' ',
      ' ',
      '\x0011',
      'ᚁ',
      'ᚚ',
      char.MinValue,
      '᚛',
      '᚜',
      '\x0012',
      '\x169D',
      'ᜑ',
      char.MinValue,
      'ᜒ',
      '᜔',
      '\r',
      '\x1715',
      'ᜱ',
      char.MinValue,
      'ᜲ',
      '᜴',
      '\r',
      '᜵',
      'ᝑ',
      char.MinValue,
      'ᝒ',
      'ᝓ',
      '\r',
      '\x1754',
      '\x1771',
      char.MinValue,
      'ᝲ',
      'ᝳ',
      '\r',
      '\x1774',
      'ា',
      char.MinValue,
      'ិ',
      'ួ',
      '\r',
      'ើ',
      'ៅ',
      char.MinValue,
      'ំ',
      'ំ',
      '\r',
      'ះ',
      'ៈ',
      char.MinValue,
      '៉',
      '៓',
      '\r',
      '។',
      '៚',
      char.MinValue,
      '៛',
      '៛',
      '\n',
      'ៜ',
      'ៜ',
      char.MinValue,
      '៝',
      '៝',
      '\r',
      '\x17DE',
      '\x17EF',
      char.MinValue,
      '\x17F0',
      '\x17F9',
      '\x0012',
      '\x17FA',
      '\x17FF',
      char.MinValue,
      '᠀',
      '᠊',
      '\x0012',
      '᠋',
      '᠍',
      '\r',
      '\x180E',
      '\x180E',
      '\x0011',
      '\x180F',
      'ᢨ',
      char.MinValue,
      'ᢩ',
      'ᢩ',
      '\r',
      'ᢪ',
      '\x191F',
      char.MinValue,
      'ᤠ',
      'ᤢ',
      '\r',
      'ᤣ',
      'ᤦ',
      char.MinValue,
      'ᤧ',
      'ᤫ',
      '\r',
      '\x192C',
      'ᤱ',
      char.MinValue,
      'ᤲ',
      'ᤲ',
      '\r',
      'ᤳ',
      'ᤸ',
      char.MinValue,
      '᤹',
      '᤻',
      '\r',
      '\x193C',
      '\x193F',
      char.MinValue,
      '᥀',
      '᥀',
      '\x0012',
      '\x1941',
      '\x1943',
      char.MinValue,
      '᥄',
      '᥅',
      '\x0012',
      '᥆',
      '᧟',
      char.MinValue,
      '᧠',
      '᧿',
      '\x0012',
      'ᨀ',
      'ᾼ',
      char.MinValue,
      '᾽',
      '᾽',
      '\x0012',
      'ι',
      'ι',
      char.MinValue,
      '᾿',
      '῁',
      '\x0012',
      'ῂ',
      'ῌ',
      char.MinValue,
      '῍',
      '῏',
      '\x0012',
      'ῐ',
      '\x1FDC',
      char.MinValue,
      '῝',
      '῟',
      '\x0012',
      'ῠ',
      'Ῥ',
      char.MinValue,
      '῭',
      '`',
      '\x0012',
      '\x1FF0',
      'ῼ',
      char.MinValue,
      '´',
      '῾',
      '\x0012',
      '\x1FFF',
      '\x1FFF',
      char.MinValue,
      ' ',
      ' ',
      '\x0011',
      '\x200B',
      '\x200D',
      '\x000E',
      '\x200E',
      '\x200E',
      char.MinValue,
      '\x200F',
      '\x200F',
      '\x0003',
      '‐',
      '‧',
      '\x0012',
      '\x2028',
      '\x2028',
      '\x0011',
      '\x2029',
      '\x2029',
      '\x000F',
      '\x202A',
      '\x202A',
      '\x0001',
      '\x202B',
      '\x202B',
      '\x0005',
      '\x202C',
      '\x202C',
      '\a',
      '\x202D',
      '\x202D',
      '\x0002',
      '\x202E',
      '\x202E',
      '\x0006',
      ' ',
      ' ',
      '\x0011',
      '‰',
      '‴',
      '\n',
      '‵',
      '⁔',
      '\x0012',
      '⁕',
      '⁖',
      char.MinValue,
      '⁗',
      '⁗',
      '\x0012',
      '⁘',
      '⁞',
      char.MinValue,
      ' ',
      ' ',
      '\x0011',
      '\x2060',
      '\x2063',
      '\x000E',
      '\x2064',
      '\x2069',
      char.MinValue,
      '\x206A',
      '\x206F',
      '\x000E',
      '\x2070',
      '\x2070',
      '\b',
      '\x2071',
      '\x2073',
      char.MinValue,
      '\x2074',
      '\x2079',
      '\b',
      '⁺',
      '⁻',
      '\n',
      '⁼',
      '⁾',
      '\x0012',
      '\x207F',
      '\x207F',
      char.MinValue,
      '\x2080',
      '\x2089',
      '\b',
      '₊',
      '₋',
      '\n',
      '₌',
      '₎',
      '\x0012',
      '\x208F',
      '\x209F',
      char.MinValue,
      '₠',
      '₱',
      '\n',
      '₲',
      '\x20CF',
      char.MinValue,
      '⃐',
      '⃪',
      '\r',
      '⃫',
      '\x20FF',
      char.MinValue,
      '℀',
      '℁',
      '\x0012',
      'ℂ',
      'ℂ',
      char.MinValue,
      '℃',
      '℆',
      '\x0012',
      'ℇ',
      'ℇ',
      char.MinValue,
      '℈',
      '℉',
      '\x0012',
      'ℊ',
      'ℓ',
      char.MinValue,
      '℔',
      '℔',
      '\x0012',
      'ℕ',
      'ℕ',
      char.MinValue,
      '№',
      '℘',
      '\x0012',
      'ℙ',
      'ℝ',
      char.MinValue,
      '℞',
      '℣',
      '\x0012',
      'ℤ',
      'ℤ',
      char.MinValue,
      '℥',
      '℥',
      '\x0012',
      'Ω',
      'Ω',
      char.MinValue,
      '℧',
      '℧',
      '\x0012',
      'ℨ',
      'ℨ',
      char.MinValue,
      '℩',
      '℩',
      '\x0012',
      'K',
      'ℭ',
      char.MinValue,
      '℮',
      '℮',
      '\n',
      'ℯ',
      'ℱ',
      char.MinValue,
      'Ⅎ',
      'Ⅎ',
      '\x0012',
      'ℳ',
      'ℹ',
      char.MinValue,
      '℺',
      '℻',
      '\x0012',
      'ℼ',
      'ℿ',
      char.MinValue,
      '⅀',
      '⅄',
      '\x0012',
      'ⅅ',
      'ⅉ',
      char.MinValue,
      '⅊',
      '⅋',
      '\x0012',
      '⅌',
      '\x2152',
      char.MinValue,
      '\x2153',
      '\x215F',
      '\x0012',
      'Ⅰ',
      '\x218F',
      char.MinValue,
      '←',
      '∑',
      '\x0012',
      '−',
      '∓',
      '\n',
      '∔',
      '⌵',
      '\x0012',
      '⌶',
      '⍺',
      char.MinValue,
      '⍻',
      '⎔',
      '\x0012',
      '⎕',
      '⎕',
      char.MinValue,
      '⎖',
      '⏐',
      '\x0012',
      '⏑',
      '\x23FF',
      char.MinValue,
      '␀',
      '␦',
      '\x0012',
      '\x2427',
      '\x243F',
      char.MinValue,
      '⑀',
      '⑊',
      '\x0012',
      '\x244B',
      '\x245F',
      char.MinValue,
      '\x2460',
      '\x249B',
      '\b',
      '⒜',
      'ⓩ',
      char.MinValue,
      '\x24EA',
      '\x24EA',
      '\b',
      '\x24EB',
      '☗',
      '\x0012',
      '☘',
      '☘',
      char.MinValue,
      '☙',
      '♽',
      '\x0012',
      '♾',
      '♿',
      char.MinValue,
      '⚀',
      '⚑',
      '\x0012',
      '⚒',
      '⚟',
      char.MinValue,
      '⚠',
      '⚡',
      '\x0012',
      '⚢',
      '\x2700',
      char.MinValue,
      '✁',
      '✄',
      '\x0012',
      '✅',
      '✅',
      char.MinValue,
      '✆',
      '✉',
      '\x0012',
      '✊',
      '✋',
      char.MinValue,
      '✌',
      '✧',
      '\x0012',
      '✨',
      '✨',
      char.MinValue,
      '✩',
      '❋',
      '\x0012',
      '❌',
      '❌',
      char.MinValue,
      '❍',
      '❍',
      '\x0012',
      '❎',
      '❎',
      char.MinValue,
      '❏',
      '❒',
      '\x0012',
      '❓',
      '❕',
      char.MinValue,
      '❖',
      '❖',
      '\x0012',
      '❗',
      '❗',
      char.MinValue,
      '❘',
      '❞',
      '\x0012',
      '❟',
      '❠',
      char.MinValue,
      '❡',
      '➔',
      '\x0012',
      '➕',
      '➗',
      char.MinValue,
      '➘',
      '➯',
      '\x0012',
      '➰',
      '➰',
      char.MinValue,
      '➱',
      '➾',
      '\x0012',
      '➿',
      '⟏',
      char.MinValue,
      '⟐',
      '⟫',
      '\x0012',
      '⟬',
      '⟯',
      char.MinValue,
      '⟰',
      '⬍',
      '\x0012',
      '⬎',
      '\x2E7F',
      char.MinValue,
      '⺀',
      '⺙',
      '\x0012',
      '\x2E9A',
      '\x2E9A',
      char.MinValue,
      '⺛',
      '⻳',
      '\x0012',
      '\x2EF4',
      '\x2EFF',
      char.MinValue,
      '⼀',
      '⿕',
      '\x0012',
      '\x2FD6',
      '\x2FEF',
      char.MinValue,
      '⿰',
      '⿻',
      '\x0012',
      '\x2FFC',
      '\x2FFF',
      char.MinValue,
      '　',
      '　',
      '\x0011',
      '、',
      '〄',
      '\x0012',
      '\x3005',
      '〇',
      char.MinValue,
      '〈',
      '〠',
      '\x0012',
      '〡',
      '〩',
      char.MinValue,
      '〪',
      '〯',
      '\r',
      '〰',
      '〰',
      '\x0012',
      '\x3031',
      '\x3035',
      char.MinValue,
      '〶',
      '〷',
      '\x0012',
      '〸',
      '〼',
      char.MinValue,
      '〽',
      '〿',
      '\x0012',
      '\x3040',
      '\x3098',
      char.MinValue,
      '゙',
      '゚',
      '\r',
      '゛',
      '゜',
      '\x0012',
      '\x309D',
      'ゟ',
      char.MinValue,
      '゠',
      '゠',
      '\x0012',
      'ァ',
      'ヺ',
      char.MinValue,
      '・',
      '・',
      '\x0012',
      '\x30FC',
      '㈜',
      char.MinValue,
      '㈝',
      '㈞',
      '\x0012',
      '\x321F',
      '\x324F',
      char.MinValue,
      '㉐',
      '\x325F',
      '\x0012',
      '㉠',
      '㉻',
      char.MinValue,
      '㉼',
      '㉽',
      '\x0012',
      '㉾',
      '㊰',
      char.MinValue,
      '\x32B1',
      '\x32BF',
      '\x0012',
      '㋀',
      '㋋',
      char.MinValue,
      '㋌',
      '㋏',
      '\x0012',
      '㋐',
      '㍶',
      char.MinValue,
      '㍷',
      '㍺',
      '\x0012',
      '㍻',
      '㏝',
      char.MinValue,
      '㏞',
      '㏟',
      '\x0012',
      '㏠',
      '㏾',
      char.MinValue,
      '㏿',
      '㏿',
      '\x0012',
      '㐀',
      '\x4DBF',
      char.MinValue,
      '䷀',
      '䷿',
      '\x0012',
      '一',
      '\xA48F',
      char.MinValue,
      '꒐',
      '꓆',
      '\x0012',
      '\xA4C7',
      '\xFB1C',
      char.MinValue,
      'יִ',
      'יִ',
      '\x0003',
      'ﬞ',
      'ﬞ',
      '\r',
      'ײַ',
      'ﬨ',
      '\x0003',
      '﬩',
      '﬩',
      '\n',
      'שׁ',
      'זּ',
      '\x0003',
      '\xFB37',
      '\xFB37',
      char.MinValue,
      'טּ',
      'לּ',
      '\x0003',
      '\xFB3D',
      '\xFB3D',
      char.MinValue,
      'מּ',
      'מּ',
      '\x0003',
      '\xFB3F',
      '\xFB3F',
      char.MinValue,
      'נּ',
      'סּ',
      '\x0003',
      '\xFB42',
      '\xFB42',
      char.MinValue,
      'ףּ',
      'פּ',
      '\x0003',
      '\xFB45',
      '\xFB45',
      char.MinValue,
      'צּ',
      'ﭏ',
      '\x0003',
      'ﭐ',
      'ﮱ',
      '\x0004',
      '﮲',
      '\xFBD2',
      char.MinValue,
      'ﯓ',
      'ﴽ',
      '\x0004',
      '﴾',
      '﴿',
      '\x0012',
      '\xFD40',
      '\xFD4F',
      char.MinValue,
      'ﵐ',
      'ﶏ',
      '\x0004',
      '\xFD90',
      '\xFD91',
      char.MinValue,
      'ﶒ',
      'ﷇ',
      '\x0004',
      '\xFDC8',
      '\xFDEF',
      char.MinValue,
      'ﷰ',
      '﷼',
      '\x0004',
      '﷽',
      '﷽',
      '\x0012',
      '\xFDFE',
      '\xFDFF',
      char.MinValue,
      '︀',
      '️',
      '\r',
      '︐',
      '\xFE1F',
      char.MinValue,
      '︠',
      '︣',
      '\r',
      '︤',
      '\xFE2F',
      char.MinValue,
      '︰',
      '﹏',
      '\x0012',
      '﹐',
      '﹐',
      '\f',
      '﹑',
      '﹑',
      '\x0012',
      '﹒',
      '﹒',
      '\f',
      '\xFE53',
      '\xFE53',
      char.MinValue,
      '﹔',
      '﹔',
      '\x0012',
      '﹕',
      '﹕',
      '\f',
      '﹖',
      '﹞',
      '\x0012',
      '﹟',
      '﹟',
      '\n',
      '﹠',
      '﹡',
      '\x0012',
      '﹢',
      '﹣',
      '\n',
      '﹤',
      '﹦',
      '\x0012',
      '\xFE67',
      '\xFE67',
      char.MinValue,
      '﹨',
      '﹨',
      '\x0012',
      '﹩',
      '﹪',
      '\n',
      '﹫',
      '﹫',
      '\x0012',
      '\xFE6C',
      '\xFE6F',
      char.MinValue,
      'ﹰ',
      'ﹴ',
      '\x0004',
      '\xFE75',
      '\xFE75',
      char.MinValue,
      'ﹶ',
      'ﻼ',
      '\x0004',
      '\xFEFD',
      '\xFEFE',
      char.MinValue,
      '\xFEFF',
      '\xFEFF',
      '\x000E',
      '\xFF00',
      '\xFF00',
      char.MinValue,
      '！',
      '＂',
      '\x0012',
      '＃',
      '％',
      '\n',
      '＆',
      '＊',
      '\x0012',
      '＋',
      '＋',
      '\n',
      '，',
      '，',
      '\f',
      '－',
      '－',
      '\n',
      '．',
      '．',
      '\f',
      '／',
      '／',
      '\t',
      '０',
      '９',
      '\b',
      '：',
      '：',
      '\f',
      '；',
      '＠',
      '\x0012',
      'Ａ',
      'Ｚ',
      char.MinValue,
      '［',
      '｀',
      '\x0012',
      'ａ',
      'ｚ',
      char.MinValue,
      '｛',
      '･',
      '\x0012',
      'ｦ',
      '\xFFDF',
      char.MinValue,
      '￠',
      '￡',
      '\n',
      '￢',
      '￤',
      '\x0012',
      '￥',
      '￦',
      '\n',
      '\xFFE7',
      '\xFFE7',
      char.MinValue,
      '￨',
      '￮',
      '\x0012',
      '\xFFEF',
      '\xFFF8',
      char.MinValue,
      '\xFFF9',
      '\xFFFB',
      '\x000E',
      '￼',
      '�',
      '\x0012',
      '\xFFFE',
      char.MaxValue,
      char.MinValue
    };
    private sbyte paragraphEmbeddingLevel = (sbyte) -1;
    public const sbyte L = (sbyte) 0;
    public const sbyte LRE = (sbyte) 1;
    public const sbyte LRO = (sbyte) 2;
    public const sbyte R = (sbyte) 3;
    public const sbyte AL = (sbyte) 4;
    public const sbyte RLE = (sbyte) 5;
    public const sbyte RLO = (sbyte) 6;
    public const sbyte PDF = (sbyte) 7;
    public const sbyte EN = (sbyte) 8;
    public const sbyte ES = (sbyte) 9;
    public const sbyte ET = (sbyte) 10;
    public const sbyte AN = (sbyte) 11;
    public const sbyte CS = (sbyte) 12;
    public const sbyte NSM = (sbyte) 13;
    public const sbyte BN = (sbyte) 14;
    public const sbyte B = (sbyte) 15;
    public const sbyte S = (sbyte) 16;
    public const sbyte WS = (sbyte) 17;
    public const sbyte ON = (sbyte) 18;
    public const sbyte TYPE_MIN = (sbyte) 0;
    public const sbyte TYPE_MAX = (sbyte) 18;
    private sbyte[] initialTypes;
    private sbyte[] embeddings;
    private int textLength;
    private sbyte[] resultTypes;
    private sbyte[] resultLevels;

    static BidiOrder()
    {
      int num1;
      for (int index = 0; index < BidiOrder.baseTypes.Length; index = num1 + 1)
      {
        int num2 = (int) BidiOrder.baseTypes[index];
        int num3;
        int num4 = (int) BidiOrder.baseTypes[num3 = index + 1];
        sbyte num5 = (sbyte) BidiOrder.baseTypes[num1 = num3 + 1];
        while (num2 <= num4)
          BidiOrder.rtypes[num2++] = num5;
      }
    }

    public BidiOrder(sbyte[] types)
    {
      BidiOrder.ValidateTypes(types);
      this.initialTypes = (sbyte[]) types.Clone();
      this.RunAlgorithm();
    }

    public BidiOrder(sbyte[] types, sbyte paragraphEmbeddingLevel)
    {
      BidiOrder.ValidateTypes(types);
      BidiOrder.ValidateParagraphEmbeddingLevel(paragraphEmbeddingLevel);
      this.initialTypes = (sbyte[]) types.Clone();
      this.paragraphEmbeddingLevel = paragraphEmbeddingLevel;
      this.RunAlgorithm();
    }

    public BidiOrder(char[] text, int offset, int length, sbyte paragraphEmbeddingLevel)
    {
      this.initialTypes = new sbyte[length];
      for (int index = 0; index < length; ++index)
        this.initialTypes[index] = BidiOrder.rtypes[(int) text[offset + index]];
      BidiOrder.ValidateParagraphEmbeddingLevel(paragraphEmbeddingLevel);
      this.paragraphEmbeddingLevel = paragraphEmbeddingLevel;
      this.RunAlgorithm();
    }

    public static sbyte GetDirection(char c)
    {
      return BidiOrder.rtypes[(int) c];
    }

    private void RunAlgorithm()
    {
      this.textLength = this.initialTypes.Length;
      this.resultTypes = (sbyte[]) this.initialTypes.Clone();
      if ((int) this.paragraphEmbeddingLevel == -1)
        this.DetermineParagraphEmbeddingLevel();
      this.resultLevels = new sbyte[this.textLength];
      this.SetLevels(0, this.textLength, this.paragraphEmbeddingLevel);
      this.DetermineExplicitEmbeddingLevels();
      this.textLength = this.RemoveExplicitCodes();
      sbyte val1 = this.paragraphEmbeddingLevel;
      int limit;
      for (int start = 0; start < this.textLength; start = limit)
      {
        sbyte num = this.resultLevels[start];
        sbyte sor = BidiOrder.TypeForLevel((int) Math.Max(val1, num));
        limit = start + 1;
        while (limit < this.textLength && (int) this.resultLevels[limit] == (int) num)
          ++limit;
        sbyte eor = BidiOrder.TypeForLevel((int) Math.Max(limit < this.textLength ? this.resultLevels[limit] : this.paragraphEmbeddingLevel, num));
        this.ResolveWeakTypes(start, limit, num, sor, eor);
        this.ResolveNeutralTypes(start, limit, num, sor, eor);
        this.ResolveImplicitLevels(start, limit, num, sor, eor);
        val1 = num;
      }
      this.textLength = this.ReinsertExplicitCodes(this.textLength);
    }

    private void DetermineParagraphEmbeddingLevel()
    {
      sbyte num1 = (sbyte) -1;
      for (int index = 0; index < this.textLength; ++index)
      {
        sbyte num2 = this.resultTypes[index];
        switch (num2)
        {
          case (sbyte) 0:
          case (sbyte) 4:
          case (sbyte) 3:
            num1 = num2;
            goto label_5;
          default:
            goto default;
        }
      }
label_5:
      if ((int) num1 == -1)
        this.paragraphEmbeddingLevel = (sbyte) 0;
      else if ((int) num1 == 0)
        this.paragraphEmbeddingLevel = (sbyte) 0;
      else
        this.paragraphEmbeddingLevel = (sbyte) 1;
    }

    private void DetermineExplicitEmbeddingLevels()
    {
      this.embeddings = BidiOrder.ProcessEmbeddings(this.resultTypes, this.paragraphEmbeddingLevel);
      for (int index = 0; index < this.textLength; ++index)
      {
        sbyte num = this.embeddings[index];
        if (((int) num & 128) != 0)
        {
          num &= sbyte.MaxValue;
          this.resultTypes[index] = BidiOrder.TypeForLevel((int) num);
        }
        this.resultLevels[index] = num;
      }
    }

    private int RemoveExplicitCodes()
    {
      int index1 = 0;
      for (int index2 = 0; index2 < this.textLength; ++index2)
      {
        switch (this.initialTypes[index2])
        {
          case (sbyte) 1:
          case (sbyte) 5:
          case (sbyte) 2:
          case (sbyte) 6:
          case (sbyte) 7:
          case (sbyte) 14:
            goto case (sbyte) 1;
          default:
            this.embeddings[index1] = this.embeddings[index2];
            this.resultTypes[index1] = this.resultTypes[index2];
            this.resultLevels[index1] = this.resultLevels[index2];
            ++index1;
            goto case (sbyte) 1;
        }
      }
      return index1;
    }

    private int ReinsertExplicitCodes(int textLength)
    {
      int length = this.initialTypes.Length;
      while (--length >= 0)
      {
        sbyte num = this.initialTypes[length];
        switch (num)
        {
          case (sbyte) 1:
          case (sbyte) 5:
          case (sbyte) 2:
          case (sbyte) 6:
          case (sbyte) 7:
          case (sbyte) 14:
            this.embeddings[length] = (sbyte) 0;
            this.resultTypes[length] = num;
            this.resultLevels[length] = (sbyte) -1;
            continue;
          default:
            --textLength;
            this.embeddings[length] = this.embeddings[textLength];
            this.resultTypes[length] = this.resultTypes[textLength];
            this.resultLevels[length] = this.resultLevels[textLength];
            continue;
        }
      }
      if ((int) this.resultLevels[0] == -1)
        this.resultLevels[0] = this.paragraphEmbeddingLevel;
      for (int index = 1; index < this.initialTypes.Length; ++index)
      {
        if ((int) this.resultLevels[index] == -1)
          this.resultLevels[index] = this.resultLevels[index - 1];
      }
      return this.initialTypes.Length;
    }

    private static sbyte[] ProcessEmbeddings(sbyte[] resultTypes, sbyte paragraphEmbeddingLevel)
    {
      int length1 = 62;
      int length2 = resultTypes.Length;
      sbyte[] numArray1 = new sbyte[length2];
      sbyte[] numArray2 = new sbyte[length1];
      int index1 = 0;
      int num1 = 0;
      int num2 = 0;
      sbyte num3 = paragraphEmbeddingLevel;
      sbyte num4 = paragraphEmbeddingLevel;
      for (int index2 = 0; index2 < length2; ++index2)
      {
        numArray1[index2] = num4;
        sbyte num5 = resultTypes[index2];
        switch (num5)
        {
          case (sbyte) 1:
          case (sbyte) 2:
          case (sbyte) 5:
          case (sbyte) 6:
            if (num2 == 0)
            {
              sbyte num6 = (int) num5 == 5 || (int) num5 == 6 ? (sbyte) ((int) num3 + 1 | 1) : (sbyte) ((int) num3 + 2 & -2);
              if ((int) num6 < length1)
              {
                numArray2[index1] = num4;
                ++index1;
                num3 = num6;
                num4 = (int) num5 == 2 || (int) num5 == 6 ? (sbyte) ((int) (byte) num6 | 128) : num6;
                numArray1[index2] = num4;
                break;
              }
              if ((int) num3 == 60)
              {
                ++num1;
                break;
              }
            }
            ++num2;
            break;
          case (sbyte) 7:
            if (num2 > 0)
            {
              --num2;
              break;
            }
            if (num1 > 0 && (int) num3 != 61)
            {
              --num1;
              break;
            }
            if (index1 > 0)
            {
              --index1;
              num4 = numArray2[index1];
              num3 = (sbyte) ((int) num4 & (int) sbyte.MaxValue);
              break;
            }
            break;
          case (sbyte) 15:
            index1 = 0;
            num2 = 0;
            num1 = 0;
            num3 = paragraphEmbeddingLevel;
            num4 = paragraphEmbeddingLevel;
            numArray1[index2] = paragraphEmbeddingLevel;
            break;
        }
      }
      return numArray1;
    }

    private void ResolveWeakTypes(int start, int limit, sbyte level, sbyte sor, sbyte eor)
    {
      sbyte num1 = sor;
      for (int index = start; index < limit; ++index)
      {
        sbyte num2 = this.resultTypes[index];
        if ((int) num2 == 13)
          this.resultTypes[index] = num1;
        else
          num1 = num2;
      }
label_15:
      for (int index1 = start; index1 < limit; ++index1)
      {
        if ((int) this.resultTypes[index1] == 8)
        {
          for (int index2 = index1 - 1; index2 >= start; --index2)
          {
            sbyte num2 = this.resultTypes[index2];
            switch (num2)
            {
              case (sbyte) 0:
              case (sbyte) 3:
              case (sbyte) 4:
                if ((int) num2 == 4)
                {
                  this.resultTypes[index1] = (sbyte) 11;
                  goto label_15;
                }
                else
                  goto label_15;
              default:
                goto default;
            }
          }
        }
      }
      for (int index = start; index < limit; ++index)
      {
        if ((int) this.resultTypes[index] == 4)
          this.resultTypes[index] = (sbyte) 3;
      }
      for (int index = start + 1; index < limit - 1; ++index)
      {
        if ((int) this.resultTypes[index] == 9 || (int) this.resultTypes[index] == 12)
        {
          sbyte num2 = this.resultTypes[index - 1];
          sbyte num3 = this.resultTypes[index + 1];
          if ((int) num2 == 8 && (int) num3 == 8)
            this.resultTypes[index] = (sbyte) 8;
          else if ((int) this.resultTypes[index] == 12 && (int) num2 == 11 && (int) num3 == 11)
            this.resultTypes[index] = (sbyte) 11;
        }
      }
      for (int index = start; index < limit; ++index)
      {
        if ((int) this.resultTypes[index] == 10)
        {
          int num2 = index;
          int runLimit = this.FindRunLimit(num2, limit, new sbyte[1]
          {
            (sbyte) 10
          });
          sbyte num3 = num2 == start ? sor : this.resultTypes[num2 - 1];
          if ((int) num3 != 8)
            num3 = runLimit == limit ? eor : this.resultTypes[runLimit];
          if ((int) num3 == 8)
            this.SetTypes(num2, runLimit, (sbyte) 8);
          index = runLimit;
        }
      }
      for (int index = start; index < limit; ++index)
      {
        switch (this.resultTypes[index])
        {
          case (sbyte) 9:
          case (sbyte) 10:
          case (sbyte) 12:
            this.resultTypes[index] = (sbyte) 18;
            break;
        }
      }
      for (int index1 = start; index1 < limit; ++index1)
      {
        if ((int) this.resultTypes[index1] == 8)
        {
          sbyte num2 = sor;
          for (int index2 = index1 - 1; index2 >= start; --index2)
          {
            sbyte num3 = this.resultTypes[index2];
            switch (num3)
            {
              case (sbyte) 0:
              case (sbyte) 3:
                num2 = num3;
                goto label_50;
              default:
                goto default;
            }
          }
label_50:
          if ((int) num2 == 0)
            this.resultTypes[index1] = (sbyte) 0;
        }
      }
    }

    private void ResolveNeutralTypes(int start, int limit, sbyte level, sbyte sor, sbyte eor)
    {
      for (int index = start; index < limit; ++index)
      {
        switch (this.resultTypes[index])
        {
          case (sbyte) 17:
          case (sbyte) 18:
          case (sbyte) 15:
          case (sbyte) 16:
            int num1 = index;
            int runLimit = this.FindRunLimit(num1, limit, new sbyte[4]
            {
              (sbyte) 15,
              (sbyte) 16,
              (sbyte) 17,
              (sbyte) 18
            });
            sbyte num2;
            if (num1 == start)
            {
              num2 = sor;
            }
            else
            {
              num2 = this.resultTypes[num1 - 1];
              switch (num2)
              {
                case (sbyte) 11:
                  num2 = (sbyte) 3;
                  break;
                case (sbyte) 8:
                  num2 = (sbyte) 3;
                  break;
              }
            }
            sbyte num3;
            if (runLimit == limit)
            {
              num3 = eor;
            }
            else
            {
              num3 = this.resultTypes[runLimit];
              switch (num3)
              {
                case (sbyte) 11:
                  num3 = (sbyte) 3;
                  break;
                case (sbyte) 8:
                  num3 = (sbyte) 3;
                  break;
              }
            }
            sbyte newType = (int) num2 != (int) num3 ? BidiOrder.TypeForLevel((int) level) : num2;
            this.SetTypes(num1, runLimit, newType);
            index = runLimit;
            break;
        }
      }
    }

    private void ResolveImplicitLevels(int start, int limit, sbyte level, sbyte sor, sbyte eor)
    {
      if (((int) level & 1) == 0)
      {
        for (int index = start; index < limit; ++index)
        {
          switch (this.resultTypes[index])
          {
            case (sbyte) 0:
              goto case (sbyte) 0;
            case (sbyte) 3:
              ++this.resultLevels[index];
              goto case (sbyte) 0;
            default:
              this.resultLevels[index] += (sbyte) 2;
              goto case (sbyte) 0;
          }
        }
      }
      else
      {
        for (int index = start; index < limit; ++index)
        {
          if ((int) this.resultTypes[index] != 3)
            ++this.resultLevels[index];
        }
      }
    }

    public byte[] GetLevels()
    {
      return this.GetLevels(new int[1]
      {
        this.textLength
      });
    }

    public byte[] GetLevels(int[] linebreaks)
    {
      BidiOrder.ValidateLineBreaks(linebreaks, this.textLength);
      byte[] numArray = new byte[this.resultLevels.Length];
      for (int index = 0; index < this.resultLevels.Length; ++index)
        numArray[index] = (byte) this.resultLevels[index];
      for (int index1 = 0; index1 < numArray.Length; ++index1)
      {
        switch (this.initialTypes[index1])
        {
          case (sbyte) 15:
          case (sbyte) 16:
            numArray[index1] = (byte) this.paragraphEmbeddingLevel;
            for (int index2 = index1 - 1; index2 >= 0 && BidiOrder.IsWhitespace(this.initialTypes[index2]); --index2)
              numArray[index2] = (byte) this.paragraphEmbeddingLevel;
            break;
        }
      }
      int num1 = 0;
      for (int index1 = 0; index1 < linebreaks.Length; ++index1)
      {
        int num2 = linebreaks[index1];
        for (int index2 = num2 - 1; index2 >= num1 && BidiOrder.IsWhitespace(this.initialTypes[index2]); --index2)
          numArray[index2] = (byte) this.paragraphEmbeddingLevel;
        num1 = num2;
      }
      return numArray;
    }

    private static int[] ComputeMultilineReordering(sbyte[] levels, int[] linebreaks)
    {
      int[] numArray = new int[levels.Length];
      int sourceIndex = 0;
      for (int index1 = 0; index1 < linebreaks.Length; ++index1)
      {
        int num = linebreaks[index1];
        sbyte[] levels1 = new sbyte[num - sourceIndex];
        Array.Copy((Array) levels, sourceIndex, (Array) levels1, 0, levels1.Length);
        int[] reordering = BidiOrder.ComputeReordering(levels1);
        for (int index2 = 0; index2 < reordering.Length; ++index2)
          numArray[sourceIndex + index2] = reordering[index2] + sourceIndex;
        sourceIndex = num;
      }
      return numArray;
    }

    private static int[] ComputeReordering(sbyte[] levels)
    {
      int length = levels.Length;
      int[] numArray = new int[length];
      for (int index = 0; index < length; ++index)
        numArray[index] = index;
      sbyte num1 = (sbyte) 0;
      sbyte num2 = (sbyte) 63;
      for (int index = 0; index < length; ++index)
      {
        sbyte num3 = levels[index];
        if ((int) num3 > (int) num1)
          num1 = num3;
        if (((int) num3 & 1) != 0 && (int) num3 < (int) num2)
          num2 = num3;
      }
      for (int index1 = (int) num1; index1 >= (int) num2; --index1)
      {
        for (int index2 = 0; index2 < length; ++index2)
        {
          if ((int) levels[index2] >= index1)
          {
            int num3 = index2;
            int index3 = index2 + 1;
            while (index3 < length && (int) levels[index3] >= index1)
              ++index3;
            int index4 = num3;
            for (int index5 = index3 - 1; index4 < index5; --index5)
            {
              int num4 = numArray[index4];
              numArray[index4] = numArray[index5];
              numArray[index5] = num4;
              ++index4;
            }
            index2 = index3;
          }
        }
      }
      return numArray;
    }

    public sbyte GetBaseLevel()
    {
      return this.paragraphEmbeddingLevel;
    }

    private static bool IsWhitespace(sbyte biditype)
    {
      switch (biditype)
      {
        case (sbyte) 1:
        case (sbyte) 2:
        case (sbyte) 5:
        case (sbyte) 6:
        case (sbyte) 7:
        case (sbyte) 14:
        case (sbyte) 17:
          return true;
        default:
          return false;
      }
    }

    private static sbyte TypeForLevel(int level)
    {
      return (level & 1) != 0 ? (sbyte) 3 : (sbyte) 0;
    }

    private int FindRunLimit(int index, int limit, sbyte[] validSet)
    {
      --index;
label_6:
      while (++index < limit)
      {
        sbyte num = this.resultTypes[index];
        for (int index1 = 0; index1 < validSet.Length; ++index1)
        {
          if ((int) num == (int) validSet[index1])
            goto label_6;
        }
        return index;
      }
      return limit;
    }

    private int FindRunStart(int index, sbyte[] validSet)
    {
label_6:
      while (--index >= 0)
      {
        sbyte num = this.resultTypes[index];
        for (int index1 = 0; index1 < validSet.Length; ++index1)
        {
          if ((int) num == (int) validSet[index1])
            goto label_6;
        }
        return index + 1;
      }
      return 0;
    }

    private void SetTypes(int start, int limit, sbyte newType)
    {
      for (int index = start; index < limit; ++index)
        this.resultTypes[index] = newType;
    }

    private void SetLevels(int start, int limit, sbyte newLevel)
    {
      for (int index = start; index < limit; ++index)
        this.resultLevels[index] = newLevel;
    }

    private static void ValidateTypes(sbyte[] types)
    {
      if (types == null)
        throw new ArgumentException("types is null");
      for (int index = 0; index < types.Length; ++index)
      {
        if ((int) types[index] < 0 || (int) types[index] > 18)
          throw new ArgumentException(string.Concat(new object[4]
          {
            (object) "illegal type value at ",
            (object) index,
            (object) ": ",
            (object) types[index]
          }));
      }
      for (int index = 0; index < types.Length - 1; ++index)
      {
        if ((int) types[index] == 15)
          throw new ArgumentException("B type before end of paragraph at index: " + (object) index);
      }
    }

    private static void ValidateParagraphEmbeddingLevel(sbyte paragraphEmbeddingLevel)
    {
      if ((int) paragraphEmbeddingLevel != -1 && (int) paragraphEmbeddingLevel != 0 && (int) paragraphEmbeddingLevel != 1)
        throw new ArgumentException("illegal paragraph embedding level: " + (object) paragraphEmbeddingLevel);
    }

    private static void ValidateLineBreaks(int[] linebreaks, int textLength)
    {
      int num1 = 0;
      for (int index = 0; index < linebreaks.Length; ++index)
      {
        int num2 = linebreaks[index];
        if (num2 <= num1)
          throw new ArgumentException(string.Concat(new object[4]
          {
            (object) "bad linebreak: ",
            (object) num2,
            (object) " at index: ",
            (object) index
          }));
        num1 = num2;
      }
      if (num1 != textLength)
        throw new ArgumentException("last linebreak must be at " + (object) textLength);
    }
  }
}
