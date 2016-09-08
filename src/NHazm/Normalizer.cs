using NHazm.Utility;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace NHazm
{
    public class Normalizer
    {
        private bool _characterRefinement = true;
        private List<RegexPattern> _characterRefinementPatterns;

        private bool _punctuationSpacing = true;
        private List<RegexPattern> _punctuationSpacingPatterns;

        private bool _affixSpacing = true;
        private List<RegexPattern> _affixSpacingPatterns;

        private string _puncAfter = @"!:\.،؛؟»\]\)\}";
        private string _puncBefore = @"«\[\(\{";

        private MakeTrans _translations;

        public Normalizer()
            : this(true, true, true)
        {
        }

        public Normalizer(bool characterRefinement, bool punctuationSpacing, bool affixSpacing)
        {
            this._characterRefinement = characterRefinement;
            this._punctuationSpacing = punctuationSpacing;
            this._affixSpacing = affixSpacing;

            this._translations = new MakeTrans(" ;%1234567890", " ؛٪۱۲۳۴۵۶۷۸۹۰");


            Regex r = new Regex("");
            if (this._characterRefinement)
            {
                this._characterRefinementPatterns = new List<RegexPattern>();
                // remove "keshide" and "carriage return" characters
                this._characterRefinementPatterns.Add(new RegexPattern(@"[ـ\r]", ""));
                // remove extra spaces
                this._characterRefinementPatterns.Add(new RegexPattern(" +", " "));
                // remove extra newlines
                this._characterRefinementPatterns.Add(new RegexPattern(@"\n\n+", "\n\n"));
                // replace 3 dots
                this._characterRefinementPatterns.Add(new RegexPattern(@" ?\.\.\.", " …"));
            }

            if (this._punctuationSpacing)
            {
                this._punctuationSpacingPatterns = new List<RegexPattern>();
                // remove space before punctuation
                this._punctuationSpacingPatterns.Add(new RegexPattern(" ([" + _puncAfter + "])", "$1"));
                // remove space after punctuation
                this._punctuationSpacingPatterns.Add(new RegexPattern("([" + _puncBefore + "]) ", "$1"));
                // put space after
                this._punctuationSpacingPatterns.Add(new RegexPattern("([" + _puncAfter + "])([^ " + _puncAfter + "])", "$1 $2"));
                // put space before
                this._punctuationSpacingPatterns.Add(new RegexPattern("([^ " + _puncBefore + "])([" + _puncBefore + "])", "$1 $2"));
            }

            if (this._affixSpacing)
            {
                this._affixSpacingPatterns = new List<RegexPattern>();
                // fix ی space
                this._affixSpacingPatterns.Add(new RegexPattern("([^ ]ه) ی ", @"$1‌ی "));
                // put zwnj after می, نمی
                this._affixSpacingPatterns.Add(new RegexPattern("(^| )(ن?می) ", @"$1$2‌"));
                // put zwnj before تر, ترین, ها, های
                this._affixSpacingPatterns.Add(new RegexPattern(" (تر(ی(ن)?)?|ها(ی)?)(?=[ \n" + _puncAfter + _puncBefore + "]|$)", @"‌$1"));
                // join ام, ات, اش, ای
                this._affixSpacingPatterns.Add(new RegexPattern("([^ ]ه) (ا(م|ت|ش|ی))(?=[ \n" + _puncAfter + "]|$)", @"$1‌$2"));
            }
        }

        public string Run(string text)
        {
            if (this._characterRefinement)
                text = CharacterRefinement(text);

            if (this._punctuationSpacing)
                text = PunctuationSpacing(text);

            if (this._affixSpacing)
                text = AffixSpacing(text);

            return text;
        }

        private string CharacterRefinement(string text)
        {
            text = this._translations.Translate(text);
            foreach (var pattern in this._characterRefinementPatterns)
                text = pattern.Apply(text);
            return text;
        }

        private string PunctuationSpacing(string text)
        {
            // TODO: don't put space inside time and float numbers
            foreach (var pattern in this._punctuationSpacingPatterns)
                text = pattern.Apply(text);
            return text;
        }

        private string AffixSpacing(string text)
        {
            foreach (var pattern in this._affixSpacingPatterns)
                text = pattern.Apply(text);
            return text;
        }
    }
}