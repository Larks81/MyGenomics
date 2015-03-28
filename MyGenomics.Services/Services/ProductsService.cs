using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MyGenomics.Data.Context;

namespace MyGenomics.Services.Services
{
    public class ProductsService
    {        
        public List<DomainModel.Product> GetAll()
        {
            List<DataModel.Product> products;
            using (var context = new MyGenomicsContext())
            {
                products = context.Products.ToList();
            }
            if (products != null && products.Any())
            {
                return Mapper.Map<List<DataModel.Product>, List<DomainModel.Product>>(products);
            }

            return null;
        }
    }
}
