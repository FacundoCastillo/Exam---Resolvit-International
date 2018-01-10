using Iveonik.Stemmers;
using OpenNLP.Tools.SentenceDetect;
using Resolvit___Exam.Classes;
using Resolvit___Exam.Helpers;
using Resolvit___Exam.Helpers.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resolvit___Exam.ParagraphProcessing
{
    public class ParagraphProcessor
    {
        public string GetUniqueWords(string paragraph)
        {
            string modelPath = "Models/EnglishSD.nbin";

            EnglishMaximumEntropySentenceDetector sentencedetector = new EnglishMaximumEntropySentenceDetector(modelPath);

            //Split the paragraph into sentences
            string[] sentences = sentencedetector.SentenceDetect(paragraph);

            //Get words from every sentence.
            OutputWords words = GetWordsFromSentences(sentences);

            JsonHelper<OutputWords> jsonOutputHelper = new JsonHelper<OutputWords>();

            //Serialize our Output object to Json.
            string jsonWords = jsonOutputHelper.IndentedJsonSerializer(words);

            return jsonWords;
        }

        //This Method receives an array of strings (sentences) and gets all the words from it.
        private OutputWords GetWordsFromSentences(string[] sentences)
        {
            //For this case, we initialize an English Stemmer, but there are other languages stemmers too.
            EnglishStemmer stemmer = new EnglishStemmer();

            OutputWords SampleOutput = new OutputWords();

            SampleOutput.Results = new List<WordItem>();

            foreach (string sentence in sentences)
            {
                int index = Array.IndexOf(sentences, sentence);

                //Get all the words from the sentence, deleting punctuation marks.
                var punctuation = sentence.Where(Char.IsPunctuation).Distinct().ToArray();
                var words = sentence.Split().Select(x => x.Trim(punctuation));

                foreach (string word in words)
                {
                    string stemmedWord = stemmer.Stem(word);

                    //Check if the word is one of the words we don't want to include in the analysis or the result set.
                    if (!StopWordsHelper.isStopword(word) && !String.IsNullOrWhiteSpace(word))
                    {
                        //Check if we have evaluated the Unique word.
                        if (SampleOutput.Results.Any(x => stemmer.Stem(x.Word) == stemmedWord))
                        {
                            //Increments the TotalOcurrences value of the word Item by 1 and adds the sentence index value to the SentenceIndexes list if it hasn't already been added.
                            SampleOutput.Results.Where(x => stemmer.Stem(x.Word) == stemmedWord).ToList()
                                            .ForEach(x =>
                                            {
                                                x.TotalOcurrences++; if (x.SentenceIndexes.LastOrDefault() != index)
                                                {
                                                    x.SentenceIndexes.Add(index);
                                                }
                                            });
                        }
                        else
                        {
                            //Create a new word Item.
                            WordItem item = new WordItem(word, 1, index);

                            //Adds the item to the results list.
                            SampleOutput.Results.Add(item);
                        }
                    }
                }
            };

            //Orders alphabetically the results list word items.
            SampleOutput.Results = SampleOutput.Results.OrderBy(x => x.Word.ToLower()).ToList();

            return SampleOutput;
        }
    }
}
