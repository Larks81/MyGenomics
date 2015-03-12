using MyGenomics.Common.enums;

namespace MyGenomics.DomainModel
{    
    public class Answer
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public bool HasAdditionalInfo { get; set; }
        public AdditionalInfoType AdditionalInfoType { get; set; }
        
        public int? MinValueNumericAdditionalInfo { get; set; }
        public int? MaxValueNumericAdditionalInfo { get; set; }        

    }
}
