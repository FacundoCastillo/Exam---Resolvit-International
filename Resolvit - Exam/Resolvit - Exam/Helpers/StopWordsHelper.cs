using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resolvit___Exam.Helpers
{
    static class StopWordsHelper
    {
        /// <summary>
        /// Words we want to remove, it takes specific words, not unique.
        /// </summary>
        static Dictionary<string, bool> _stops = new Dictionary<string, bool>
        {

        { "a", true },
        { "the", true },
        { "and", true },
        { "of", true },
        { "in", true },
        { "be", true },
        { "also", true },
        { "as", true }

        };

        /// <summary>
        /// Check if the word is one of the words we want to remove from the analysis or the result set.
        /// </summary>
        public static bool isStopword(string word)
        {
            return _stops.ContainsKey(word.ToLower());
        }
    }
}
