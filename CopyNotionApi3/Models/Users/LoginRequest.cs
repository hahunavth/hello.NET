using System.ComponentModel.DataAnnotations;

namespace CopyNotionApi3.Models.Users;

public class LoginRequest
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    public string Password { get; set; }
}
