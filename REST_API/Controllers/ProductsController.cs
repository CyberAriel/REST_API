using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNetCore.Mvc;
using REST_API.Models;
using System.Net.Http;

namespace REST_API.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : ApiController
    {

        static readonly IProductRepository repository = new ProductRepository();

        
        [HttpGet]
        public IEnumerable<Product> GetAllProducts()
        {
            return repository.GetAll();
        }

        
        [HttpGet("{id}")]
        public Product GetProduct(int id)
        {
            Product item = repository.Get(id);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return item;
        }

        [HttpGet("{id}")]
        public IEnumerable<Product> GetProductsByCategory(string category)
        {
            return repository.GetAll().Where(
                p => string.Equals(p.Category, category, StringComparison.OrdinalIgnoreCase));
        }

        
        [HttpPost]
        public HttpResponseMessage PostProduct(Product item)
        {
            item = repository.Add(item);
            var response = Request.CreateResponse<Product>(HttpStatusCode.Created, item);

            string uri = Url.Link("DefaultApi", new { id = item.Id });
            response.Headers.Location = new Uri(uri);
            return response;
        }

        
        [HttpPut("{id}")]
        public void PutProduct(int id, Product product)
        {
            product.Id = id;
            if (!repository.Update(product))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void DeleteProduct(int id)
        {
            repository.Remove(id);
        }
    }
}

