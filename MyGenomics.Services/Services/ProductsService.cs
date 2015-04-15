using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MyGenomics.Data.Context;
using MyGenomics.DomainModel;

namespace MyGenomics.Services.Services
{
    public class ProductsService
    {
        private const int maxItemInPage = 10;

        public SearchList<DomainModel.ProductItemList> GetProducts(int languageId, string name = "", int page = 1)
        {
            var result = new SearchList<DomainModel.ProductItemList>();
            if (name == null)
            {
                name = "";
            }
            using (var context = new MyGenomicsContext())
            {                                    
                result.TotRec = context
                    .Products.Count(p => p.Name.Contains(name));

                result.CurrentPage = page;
                result.TotPag = (int)Math.Ceiling((decimal)result.TotRec / (decimal)maxItemInPage);
                    
                var res = context.Products                        
                    .OrderBy(p => p.Id)
                    .Skip(maxItemInPage * (page - 1)).Take(maxItemInPage)
                    .Where(p => p.Name.Contains(name))                        
                    .ToList();

                if (res.Any())
                {
                    result.Results = Mapper.Map<List<DataModel.Product>, List<DomainModel.ProductItemList>>(res);
                }                
            }

            return result;
        }

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
