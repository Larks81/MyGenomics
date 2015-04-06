using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGenomics.DataModel
{
    public class QuestionnaireResult : ModelBase
    {        
        public int ContactQuestionnaireId { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public double Result { get; set; }
        public int WorseCaseTotal { get; set; }
        public int ContactTotal { get; set; }
        public int NumberOfAnswer { get; set; }
    }
}
