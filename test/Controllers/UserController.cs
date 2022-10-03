using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using test.Interfaces;
using test.Models;

namespace test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository repository;

        public UserController(IUserRepository repository)
        {
            this.repository = repository;
        }


        [HttpPost]
        public void CreateUser(User user)
        {
            repository.CreateUser(user);
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> GetAllUsers() {
            return repository.GetAllUsers().ToList();
        }

        [HttpPut]
        public void UpdatUser(User user )
        {
            repository.UpdateUser(user);
         }



        [HttpDelete("{id}")]
        public void DeleteUser (int id)
        {
            repository.DeleteUser(id);
        }
    }

}
