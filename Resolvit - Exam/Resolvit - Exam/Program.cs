using Resolvit___Exam.Helpers;
using Resolvit___Exam.ParagraphProcessing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resolvit___Exam
{
    class Program
    {
        static void Main(string[] args)
        {
            //example paragraph
            string paragraph = "Take this paragraph of text and return an alphabetized list of ALL unique words.  A unique word is any form of a word often communicated with essentially the same meaning. For example, fish and fishes could be defined as a unique word by using their stem fish. For each unique word found in this entire paragraph, determine the how many times the word appears in total. Also, provide an analysis of what unique sentence index position or positions the word is found. The following words should not be included in your analysis or result set: \"a\", \"the\", \"and\", \"of\", \"in\", \"be\", \"also\" and \"as\".  Your final result MUST be displayed in a readable console output in the same format as the JSON sample object shown below.";
            Console.WriteLine(paragraph);

            //Console.WriteLine("Please, write your paragraph.");
            Console.WriteLine("");

            ParagraphProcessor processor = new ParagraphProcessor();

            //Get Unique Words in json format from the paragraph.
            string words = processor.GetUniqueWords(paragraph);

            Console.WriteLine("Sample Output: ");
            //Shows our output in a Json Format.
            Console.WriteLine(words);

            Console.WriteLine("");
            Console.Write("Press any key to close the application");
            Console.ReadLine();
        }
    }
}
