using System.ComponentModel.DataAnnotations;

namespace crito.Models;

public class ContactForm
{
    [Required]
    public required string Name { get; set; }

    [Required]
    [EmailAddress]
    public required string Email { get; set; }

    [Required]
    public required string Message { get; set; }

    public string RedirectUrI { get; set; } = "/contacts";
}
