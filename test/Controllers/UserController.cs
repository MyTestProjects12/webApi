using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
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


        // Post
        [HttpPost]
        public void CreateUser(CreateUserDto userDto)
        {
            var user = new User()
            {

                Name = userDto.Name,
                Email = userDto.Email,
                Password = userDto.Password
            };
            repository.CreateUser(user);
        }

        // Get
        [HttpGet]
        public ActionResult<IEnumerable<UserDto>> GetAllUsers() {

            return repository.GetAllUsers().ToList().Select(user => user.AsDto()).ToList();
        }
        [HttpGet("{id}")]
        public UserDto GetUserById(int id)
        {
            return repository.GetUserById(id).AsDto();
        }

        //Put
        [HttpPut("{userId}")]
        public ActionResult<string> UpdatUser(CreateUserDto userDto, int userId)
        {
            var user = new User()
            {
                Id=userId,
                Name = userDto.Name,
                Email = userDto.Email,
                Password = userDto.Password
            };
            repository.UpdateUser(user);

            return Ok("User Updated Successfully");
         }


        //Delete
        [HttpDelete("{id}")]
        public ActionResult DeleteUser (int id)
        {
            repository.DeleteUser(id);
            return Ok("User Updated Successfully"); ;
        }


    }

}
