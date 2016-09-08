using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTOP.Base
{
    /// <summary>
    /// Check for typos in any Persian string
    /// </summary>
    //public class SpellChecker
    //{
    //    #region fields
    //    private PersianSpellChecker _spellChecker;
    //    private SpellCheckerInlineVerifier _verifier;
    //    #endregion

    //    #region constructor
    //    public SpellChecker()
    //    {
    //        _spellChecker = new PersianSpellChecker(new PersianSpellCheckerConfig()
    //        {
    //            DicPath = "./data/dic.dat",
    //            StemPath = "./data/stem.dat",
    //            EditDistance = 2,
    //            SuggestionCount = 7
    //        });


    //        _verifier = new SpellCheckerInlineVerifier(true, _spellChecker);
    //    }
    //    #endregion

    //    #region public-methods
    //    /// <summary>
    //    /// Verify a text and return possible errors
    //    /// </summary>
    //    /// <param name="text"></param>
    //    /// <returns></returns>
    //    public IEnumerable<VerificationInstance> Verify(string text) => _verifier.VerifyText(text);

    //    /// <summary>
    //    /// Find typos and fix them
    //    /// </summary>
    //    /// <param name="input"></param>
    //    /// <param name="spellingErrors"></param>
    //    /// <returns></returns>
    //    public string FixString(string input, List<string> spellingErrors = null)
    //    {
    //        var possibleErrors = Verify(input).ToList();
    //        if (possibleErrors.Any(e => e.Suggestions.Length > 0))
    //        {
    //            var fixDict = new Dictionary<string, string>();

    //            foreach (var e in possibleErrors)
    //            {
    //                var wrong = input.Substring(e.Index, e.Length);
    //                if (!fixDict.ContainsKey(wrong) && e.Suggestions.Length > 0)
    //                    fixDict.Add(wrong, e.Suggestions.First());
    //            }

    //            foreach (var key in fixDict.Keys)
    //                input = input.Replace(key, fixDict[key]);

    //            if (spellingErrors != null)
    //                spellingErrors.AddRange(fixDict.Select((item) => $"{item.Key}\t=>\t{item.Value}").ToList());
    //        }

    //        return input;
    //    }

    //    #endregion
    //}
}
