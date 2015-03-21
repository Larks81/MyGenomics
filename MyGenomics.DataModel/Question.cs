using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyGenomics.Common.enums;

namespace MyGenomics.DataModel
{
    public class Question : ModelBase
    {        
        public string Text { get; set; }
        public int StepNumber { get; set; }
        public QuestionCategory Category { get; set; }
        public int CategoryId { get; set; } 
        public List<Answer> Anwers { get; set; }
        public bool IsRequired { get; set; }
        public QuestionType QuestionType { get; set; }
        
    }
}
