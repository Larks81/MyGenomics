using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyGenomics.Common.enums;

namespace MyGenomics.DataModel
{    
    public class Answer : ModelBase
    {        
        public string Text { get; set; }
        public bool HasAdditionalInfo { get; set; }
        public AdditionalInfoType AdditionalInfoType { get; set; }
        public List<AnswerWeight> AnswerWeight { get; set; }        

    }
}
