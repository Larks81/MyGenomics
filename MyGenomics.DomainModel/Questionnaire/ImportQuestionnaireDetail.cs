using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyGenomics.Common.enums;

namespace MyGenomics.DomainModel
{
    public class ImportQuestionnaireDetail
    {
        public int RowNumber { get; set; }
        public string QuestionCategory { get; set; }	
        public string QuestionText { get; set; }
        public bool Required { get; set; }
        public QuestionType QuestionType { get; set; }
        public string AnswerText { get; set; }
        public AdditionalInfoType? AnswerType { get; set; }
        public string ContactTypeCode { get; set; }
        public string ProductCode { get; set; }
        public int? FromValue { get; set; }
        public int? ToValue { get; set; }
        public int? Weight { get; set; }
        public int? QuestionCategoryId { get; set; }
        public int? QuestionId { get; set; }
        public int? AnswerId { get; set; }
        public int? AnswerWeightId { get; set; }
    }
}
