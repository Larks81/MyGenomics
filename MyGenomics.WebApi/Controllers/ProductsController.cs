using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MyGenomics.DomainModel;
using MyGenomics.Services.Services;

namespace MyGenomics.Controllers
{
    public class ProductsController : ApiController
    {
        private ProductsService _productsService = new ProductsService();

        public SearchList<ProductItemList> Get(int languageId, string filter, int page = 1)
        {
            return _productsService.GetProducts(languageId, filter, page);
        }

        // GET api/products/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/products
        public void Post([FromBody]string value)
        {
        }

        // PUT api/products/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/products/5
        public void Delete(int id)
        {
        }
    }
}
