using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Resolvit___Exam.Classes
{
    [DataContract]
    public class WordItem
    {
        public WordItem(string word, int totalOcurrences, int sentenceIndex)
        {
            Word = word;
            TotalOcurrences = totalOcurrences;
            SentenceIndexes = new List<int>() { sentenceIndex };
        }

        [DataMember]
        internal string Word;

        [DataMember]
        internal int TotalOcurrences;

        [DataMember]
        internal List<int> SentenceIndexes;
    }
}
