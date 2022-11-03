using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace test_4.Models;

public class ApplicationUser : IdentityUser
{
    [Required]
    public string? Nickname { get; set; } = String.Empty;
    
    public int Age { get; set; }
}