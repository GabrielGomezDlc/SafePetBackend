
namespace SafePetBackend.SafePet.Domain.Models;

public class Vet
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Birthday { get; set; }
    public string Email { get; set; }
    public int AppointmentsQuantity { get; set; }
    public int Score { get; set; }
    public string Phone { get; set; }
    public string PhotoUrl { get; set; }
}