using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGenomics.DomainModel
{
    public class ContactQuestionnaire
    {
        public int QuestionnaireId { get; set; }
        public string QuestionnaireName { get; set; }
        public List<ContactGivenAnswer> Answers { get; set; }
        public Contact Contact { get; set; }
        public List<QuestionnaireResult> Results { get; set; }
    }
}
