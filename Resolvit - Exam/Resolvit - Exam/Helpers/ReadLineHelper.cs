using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resolvit___Exam.Helpers
{
    static class ReadLineHelper
    {
        /// <summary>
        /// Sets the limit of characters of the Console.ReadLine command.
        /// </summary>
        public static void SetReadCharacterLimit(int limit)
        {
            Stream inputStream = Console.OpenStandardInput(limit);
            Console.SetIn(new StreamReader(inputStream, Encoding.Default, false, limit));
        }
    }
}
