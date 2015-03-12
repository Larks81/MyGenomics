using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGenomics.DomainModel
{
    public class Questionnaire
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<QuestionCategory> QuestionsCategories { get; set; }
    }
}
