using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGenomics.DataModel
{
    public class ContactQuestionnaire : ModelBase
    {        
        public DateTime CreatedDate { get; set; }
        public Questionnaire Questionnaire { get; set; }
        public int QuestionnaireId { get; set; }
        public List<ContactAnswer> Answers { get; set; }
        public Contact Contact { get; set; }
        public int ContactId { get; set; }
        public List<QuestionnaireResult> Results { get; set; }
    }
}
