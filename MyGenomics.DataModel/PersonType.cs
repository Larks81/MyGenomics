using MyGenomics.Common.enums;

namespace MyGenomics.DataModel
{    
    public class PersonType : ModelBase
    {
        public string Code { get; set; }
        public Enums Gender { get; set; }
        public int AgeFrom { get; set; }
        public int AgeTo { get; set; }
        public string Description { get; set; }
    }
}
