using System.Text.RegularExpressions;

namespace NHazm.Utility
{
    public class RegexPattern
    {
        public RegexPattern(string pattern, string replace) : this(new Regex(pattern), replace)
        {
        }

        public RegexPattern(Regex pattern, string replace)
        {
            this.Pattern = pattern;
            this.Replace = replace;
        }

        public Regex Pattern { get; private set; }
        public string Replace { get; private set; }

        public string Apply(string text)
        {
            return Pattern.Replace(text, Replace);
        }
    }
}