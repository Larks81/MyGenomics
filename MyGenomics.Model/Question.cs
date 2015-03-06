﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGenomics.Model
{
    public class Question
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int StepNumber { get; set; }
        public QuestionCategory Category { get; set; }
        public int CategoryId { get; set; } 
        public List<Answer> Anwers { get; set; }
        public bool IsRequired { get; set; }
        
    }
}
