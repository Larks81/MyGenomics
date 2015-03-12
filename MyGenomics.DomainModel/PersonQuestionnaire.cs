using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGenomics.DomainModel
{
    public class PersonQuestionnaire
    {
        public int QuestionnaireId { get; set; }
        public string QuestionnaireName { get; set; }
        public List<PersonGivenAnswer> Answers { get; set; }
        public Person Person { get; set; }
        public List<QuestionnaireResult> Results { get; set; }
    }
}
