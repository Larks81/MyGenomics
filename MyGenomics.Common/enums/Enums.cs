using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGenomics.Common.enums
{
    public enum Enums { Male = 1, Female = 2 }
    public enum AdditionalInfoType { Text = 1, Numeric = 2 }
    public enum QuestionType { MultipleExclusive = 1, MultipleNotExclusive = 2, ValueOnly=3 }
    public enum ContentType { Text = 1, Html = 2, PdfFile = 3, ImageUri = 4 }
}
