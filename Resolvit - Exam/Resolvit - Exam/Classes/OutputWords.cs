using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Resolvit___Exam.Classes
{
    [DataContract]
    public class OutputWords
    {
        [DataMember]
        public List<WordItem> Results;
    }
}
