using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGenomics.DomainModel
{
    public class PersonGivenAnswer
    {
        public int QuestionId { get; set; }
        public string QuestionText { get; set; }
        public int AnswerId { get; set; }
        public string AnswerText { get; set; }
        public string AdditionalInfo { get; set; }
    }
}
