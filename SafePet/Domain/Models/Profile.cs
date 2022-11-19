namespace SafePetBackend.SafePet.Domain.Models;

public class Profile
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Birthday { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string PhotoUrl { get; set; }
}