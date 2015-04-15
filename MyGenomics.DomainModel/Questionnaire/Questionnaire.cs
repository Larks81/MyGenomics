using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGenomics.DomainModel
{
    public class Questionnaire
    {
        public string Code { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public List<QuestionCategory> QuestionsCategories { get; set; }

        public override string ToString()
        {
            return Code;
        }
    }
}
