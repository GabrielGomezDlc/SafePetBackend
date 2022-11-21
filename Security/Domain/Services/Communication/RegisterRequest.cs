using System.ComponentModel.DataAnnotations;

namespace SafePetBackend.Security.Domain.Services.Communication;

public class RegisterRequest
{
    [Required]  public string Name { get; set; }
    [Required]  public string Birthday { get; set; }
    [Required]  public string Email { get; set; }
    [Required]  public string Phone { get; set; }
                 public string PhotoUrl { get; set; }
                 public int Score { get; set; }
          public int AppointmentsQuantity { get; set; }
    [Required]  public string Role { get; set; }
    [Required] public string Username { get; set; }
    [Required] public string Password { get; set; }
}