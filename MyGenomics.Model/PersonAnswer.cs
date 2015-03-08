using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGenomics.Model
{
    public class PersonAnswer : ModelBase
    {            
        public Question Question { get; set; }
        public int QuestionId { get; set; }
        public Answer Answer { get; set; }
        public int AnswerId { get; set; }
        public string AdditionalInfo { get; set; }
    }
}
