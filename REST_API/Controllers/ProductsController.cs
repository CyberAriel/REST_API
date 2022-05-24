using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Web.Http;
using REST_API.Models;

namespace REST_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
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

        [HttpPost]
        public void PostProduct(Product item)
       {

             item = repository.Add(item);
   
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


        [HttpDelete("{id}")]
        public void DeleteProduct(int id)
        {
            repository.Remove(id);
        }
    }
}
