using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGenomics.DomainModel
{
    public class LevelDetail
    {
        public int Id { get; set; }
        public int LanguageId { get; set; }
        public int? TranslationId { get; set; }
        public int Value { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public string ImageUri { get; set; }
    }
}
