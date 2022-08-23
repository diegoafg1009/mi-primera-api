using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Model;
using ProyectoFinal.Repository;

namespace ProyectoFinal.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SaleController
    {
        [HttpPost]
        public void InsertSale( List <Product> products, int userId)
        {
            SaleHandler.InsertSale(products, userId);

            foreach(Product product in products)
            {
                ProductHandler.InsertProduct(product);
            }
        }
    }
}
