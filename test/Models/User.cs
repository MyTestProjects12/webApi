using System.ComponentModel.DataAnnotations;

namespace test.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        [Required]
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
