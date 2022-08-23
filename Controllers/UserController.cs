using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Model;
using ProyectoFinal.Repository;

namespace ProyectoFinal.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        [HttpGet(Name = "GetUsers")]
        public List<User> GetUsers()
        {
            return UserHandler.GetUsers();
        }

        [HttpPost]

        public void InsertUser([FromBody] User user)
        {
            UserHandler.InsertUser(user);
        }

        [HttpPut]

        public void UpdateUser([FromBody] User user)
        {
            UserHandler.UpdateUser(user);
        }

        [HttpDelete(Name = "DeleteUser")]

        public void DeleteUser([FromBody] int id)
        {
            UserHandler.DeleteUser(id);
        }

    }
}
