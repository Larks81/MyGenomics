using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGenomics.DataModel
{
    public class Questionnaire : ModelBase
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public List<Question> Questions { get; set; }
        public Language Language { get; set; }
        public int LanguageId { get; set; }

    }
}
