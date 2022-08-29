using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Model;
using ProyectoFinal.Repository;

namespace ProyectoFinal.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        [HttpGet("GetUser")]
        public User GetUser([FromBody] string userName)
        {
            return UserHandler.GetUser(userName);
        }

        [HttpGet("GetUsers")]
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

        [HttpGet("Login")]

        public User Login([FromBody] string userName, string pass)
        {
            return UserHandler.Login(userName, pass);
        }

    }
}
