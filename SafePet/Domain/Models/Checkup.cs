namespace SafePetBackend.SafePet.Domain.Models;

public class Checkup
{
    public int Id { get; set; }
    public int ClientId { get; set; }
    public string Date { get; set; }
    public string Observation { get; set; }
    public string Prescription { get; set; }
}