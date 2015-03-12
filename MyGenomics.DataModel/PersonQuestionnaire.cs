using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGenomics.DataModel
{
    public class PersonQuestionnaire : ModelBase
    {        
        public DateTime CreatedDate { get; set; }
        public Questionnaire Questionnaire { get; set; }
        public int QuestionnaireId { get; set; }
        public List<PersonAnswer> Answers { get; set; }
        public Person Person { get; set; }
        public int PersonId { get; set; }
        public List<QuestionnaireResult> Results { get; set; }
    }
}
