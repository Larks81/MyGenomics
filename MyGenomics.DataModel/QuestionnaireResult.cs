﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGenomics.DataModel
{
    public class QuestionnaireResult : ModelBase
    {        
        public int PersonQuestionnaireId { get; set; }
        public ProductCategory ProductCategory { get; set; }
        public int ProductCategoryId { get; set; }
        public double Result { get; set; }
        public int NumberOfAnswer { get; set; }
    }
}