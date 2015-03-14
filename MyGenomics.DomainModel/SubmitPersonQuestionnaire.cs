using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGenomics.DomainModel
{
    public class SubmitPersonQuestionnaire
    {                
        public int QuestionnaireId { get; set; }
        public List<PersonGivenAnswer> GivenAnswers { get; set; }
        public Person Person { get; set; }
        public int PersonId { get; set; }      
    }
    
}
