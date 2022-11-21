namespace SafePetBackend.Security.Domain.Services.Communication;

public class UpdateRequest
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhotoUrl { get; set; }
    public int Score { get; set; }
    public int AppointmentsQuantity { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
}