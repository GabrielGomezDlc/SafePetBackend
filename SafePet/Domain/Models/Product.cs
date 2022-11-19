namespace SafePetBackend.SafePet.Domain.Models;

public class Product
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Category { get; set; }
    public double Price { get; set; }
    public string Author { get; set; }
    public string Image { get; set; }
}