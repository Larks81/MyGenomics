using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGenomics.Model
{
    public enum AdditionalInfoType { Text = 1, Numeric=2 }
    public class Answer : ModelBase
    {        
        public string Text { get; set; }
        public bool HasAdditionalInfo { get; set; }
        public AdditionalInfoType AdditionalInfoType { get; set; }
        public List<AnswerWeight> AnswerWeight { get; set; }

        [NotMapped]
        public int? MinValueNumericAdditionalInfo
        {
            get {
                try
                {
                    return AnswerWeight.Min(a => a.FromNumericAdditionalInfo);
                }
                catch { return null; }
            }
        }

        [NotMapped]
        public int? MaxValueNumericAdditionalInfo
        {
            get
            {
                try
                {
                    return AnswerWeight.Max(a => a.ToNumericAdditionalInfo);
                }
                catch { return null; }
            }
        }

    }
}
