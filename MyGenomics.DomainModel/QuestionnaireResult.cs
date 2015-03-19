using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGenomics.DomainModel
{
    public class QuestionnaireResult
    {        
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductUrl { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductShortDescription { get; set; }
        public string ProductDescription { get; set; }
        public double Result { get; set; }
        public int NumberOfAnswer { get; set; }
    }
}
