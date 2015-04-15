using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGenomics.DomainModel
{
    public class ImportQuestionnaire
    {
        public string QuestionnaireCode { get; set; }
        public int LanguageCode { get; set; }
        public string QuestionnaireName { get; set; }
        public List<ImportQuestionnaireDetail> Details { get; set; }
    }
}
