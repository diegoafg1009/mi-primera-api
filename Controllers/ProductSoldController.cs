using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Model;
using ProyectoFinal.Repository;

namespace ProyectoFinal.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductSoldController
    {
        [HttpGet]

        public List<ProductSold> GetProducts([FromBody] int userId)
        {
            return ProductSoldHandler.GetProducts(userId);
        }
    }
}
