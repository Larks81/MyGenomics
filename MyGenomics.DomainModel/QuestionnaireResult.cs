using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGenomics.DomainModel
{
    public class QuestionnaireResult
    {        
        public int ProductCategoryId { get; set; }
        public string ProductCategoryName { get; set; }        
        public double Result { get; set; }
        public int NumberOfAnswer { get; set; }
    }
}
