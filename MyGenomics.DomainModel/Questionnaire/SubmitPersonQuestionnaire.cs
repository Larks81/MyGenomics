using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGenomics.DomainModel
{
    public class SubmitContactQuestionnaire
    {                
        public int QuestionnaireId { get; set; }
        public List<ContactGivenAnswer> GivenAnswers { get; set; }
        public Contact Contact { get; set; }
        public int ContactId { get; set; }      
    }
    
}
