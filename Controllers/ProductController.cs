using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Model;
using ProyectoFinal.Repository;

namespace ProyectoFinal.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController
    {
        [HttpGet]

        public List<Product> GetProducts([FromBody] int id)
        {
            return ProductHandler.GetProducts(id);
        }

        [HttpPost]
        public void InsertProduct([FromBody] Product product)
        {
            ProductHandler.InsertProduct(product);
        }

        [HttpPut]

        public void UpdateProduct([FromBody] Product product)
        {
            ProductHandler.UpdateProduct(product);
        }

        [HttpDelete]

        public void DeleteProduct([FromBody] int id)
        {
            ProductHandler.DeleteProduct(id);
        }
    }
}
