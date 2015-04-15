using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGenomics.DomainModel
{
    public class QuestionCategory
    {        
        public string Name { get; set; }
        public List<Question> Questions { get; set; }
    }
}
