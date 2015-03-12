using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGenomics.DomainModel
{
    public class Question
    {
        public int Id { get; set; }        
        public string Text { get; set; }        
        public List<Answer> Anwers { get; set; }
        public bool IsRequired { get; set; }
        
    }
}
