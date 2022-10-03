using test.Models;

namespace test
{
    public static class Extensions
    {
        public static UserDto AsDto(this User user)
        {
            return new UserDto
            {
                Name = user.Name,
                Email = user.Email,
            };
        }
    }
}