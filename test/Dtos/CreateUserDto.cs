using System;
using System.ComponentModel.DataAnnotations;

public class CreateUserDto
{   public string? Name { get; set; }
    [Required]
    public string? Email { get; set; }
    public string? Password { get; set; }
}
