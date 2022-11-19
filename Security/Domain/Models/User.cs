using System.Text.Json.Serialization;

namespace SafePetBackend.Security.Domain.Models;

public abstract class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Birthday { get; set; }
    public string Email { get; set; }
    public int AppointmentsQuantity { get; set; }
    public int Score { get; set; }
    public string Phone { get; set; }
    
    public string PhotoUrl { get; set; }
    public string Password { get; set; }
    
    public string Role { get; set; }

}
