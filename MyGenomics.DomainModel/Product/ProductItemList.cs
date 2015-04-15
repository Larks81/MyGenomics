﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGenomics.DomainModel
{
    public class ProductItemList
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string UrlDetail { get; set; }
        public decimal Price { get; set; }        
    }
}
