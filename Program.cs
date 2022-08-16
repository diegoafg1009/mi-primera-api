namespace ProyectoFinal
{
    public class ProbarObjetos
    {
        static void Main(string[] args)
        {

            User user = new User();

            user.UserName = "eperez";

            user = UserHandler.GetUsuarios(user.UserName);

            List<Product> products = new List<Product>();

            products = ProductHandler.GetProducts(1);

            ProductSoldHandler.GetProducts(1);

            user = UserHandler.Login("eperez", "soyErnestoPerez");

        }
    }
}