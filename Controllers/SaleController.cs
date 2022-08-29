using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Controllers.DTOS;
using ProyectoFinal.Model;
using ProyectoFinal.Repository;

namespace ProyectoFinal.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SaleController
    {
        [HttpGet]

        public List<Sale> GetSales([FromBody] int userId)
        {
            return SaleHandler.GetSales(userId);
        }

        [HttpPost]
        public void InsertSale([FromBody]  List<PostSale> postSales, int userId)
        {
            int saleId = 0;
            SaleHandler.InsertSale(userId, ref saleId);

            foreach(PostSale postSale in postSales)
            {
                ProductSoldHandler.InsertProductSold(postSale.Stock, postSale.productId, saleId);
                ProductHandler.UpdateStock(postSale.productId, postSale.Stock);
            }
        }
    }
}
