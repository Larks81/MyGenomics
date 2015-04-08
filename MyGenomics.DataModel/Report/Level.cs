﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGenomics.DataModel
{
    public class Level : ModelBase
    {
        public string Name { get; set; }
        public int Value { get; set; }
        public List<LevelTranslation> Translations { get; set; }
    }
}
