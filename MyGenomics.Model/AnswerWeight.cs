using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGenomics.Model
{
    public class AnswerWeight
    {
        public int Id { get; set; }
        public PersonType PersonType { get; set; }
        public int PersonTypeId { get; set; }
        public ProductCategory ProductCategory { get; set; }
        public int ProductCategoryId { get; set; }
        public int FromNumericAdditionalInfo { get; set; }
        public int ToNumericAdditionalInfo { get; set; }
        public int Value { get; set; }
    }
}
