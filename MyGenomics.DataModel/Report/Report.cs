﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGenomics.DataModel
{
    public class Report : ModelBase
    {
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public string Version { get; set; }
        public List<ReportsChapters> Chapters { get; set; }
        public List<ReportTranslation> Translations { get; set; }
    }
}
