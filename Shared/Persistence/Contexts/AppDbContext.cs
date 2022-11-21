using SafePetBackend.Security.Domain.Models;
using Microsoft.EntityFrameworkCore;
using SafePetBackend.SafePet.Domain.Models;
using SafePetBackend.Shared.Extensions;


namespace SafePetBackend.Shared.Persistence.Contexts;

public class AppDbContext: DbContext
{
    
    public DbSet<User> Users { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    
    public DbSet<Checkup> Checkups { get; set; }
    
    public DbSet<Client> Clients { get; set; }
    
    public DbSet<MostPurchasedProduct> MostPurchasedProducts { get; set; }
    
    public DbSet<Product> Products { get; set; }
    
    public DbSet<Profile> Profiles { get; set; }
    
    public DbSet<Review> Reviews { get; set; }
    
    public DbSet<Vet> Vets { get; set; }
    
    public DbSet<VeterinarianNearYou> VeterinariansNearYou { get; set; }
    
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
    
        
        base.OnModelCreating(builder);
        
        // Users

        // Constraints
        builder.Entity<User>().ToTable("Users");
        builder.Entity<User>().HasKey(p => p.Id);
        builder.Entity<User>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<User>().Property(p => p.Username).IsRequired().HasMaxLength(30);
        builder.Entity<User>().Property(p => p.Name).IsRequired();
        builder.Entity<User>().Property(p => p.Birthday).IsRequired();
        builder.Entity<User>().Property(p => p.Email).IsRequired().HasMaxLength(100);
        builder.Entity<User>().Property(p => p.Phone).IsRequired();
        builder.Entity<User>().Property(p => p.PhotoUrl);
        builder.Entity<User>().Property(p => p.Score);
        builder.Entity<User>().Property(p => p.AppointmentsQuantity);
        builder.Entity<User>().Property(p => p.Role).IsRequired();
        
 
        
        //Appointments
        builder.Entity<Appointment>().ToTable("Appointments");
        builder.Entity<Appointment>().HasKey(p => p.Id);
        builder.Entity<Appointment>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Appointment>().Property(p => p.Date).IsRequired();
        builder.Entity<Appointment>().Property(p => p.VeterinarianId).IsRequired();
        builder.Entity<Appointment>().Property(p => p.VeterinarianName).IsRequired().HasMaxLength(100);
        builder.Entity<Appointment>().Property(p => p.PetOwnerId).IsRequired();
        builder.Entity<Appointment>().Property(p => p.PetOwnerName).IsRequired().HasMaxLength(100);
        builder.Entity<Appointment>().Property(p => p.Image);
        
        //Checkups
        builder.Entity<Checkup>().ToTable("Checkups");
        builder.Entity<Checkup>().HasKey(p => p.Id);
        builder.Entity<Checkup>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Checkup>().Property(p => p.ClientId).IsRequired();
        builder.Entity<Checkup>().Property(p => p.Date).IsRequired();
        builder.Entity<Checkup>().Property(p => p.Observation);
        builder.Entity<Checkup>().Property(p => p.Prescription);
        
        //Clients
        builder.Entity<Client>().ToTable("Clients");
        builder.Entity<Client>().HasKey(p => p.Id);
        builder.Entity<Client>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Client>().Property(p => p.VetId).IsRequired();
        builder.Entity<Client>().Property(p => p.Name).IsRequired().HasMaxLength(100);
        builder.Entity<Client>().Property(p => p.PetName).IsRequired().HasMaxLength(100);
        builder.Entity<Client>().Property(p => p.PhotoUrl);
        
        
        //MostPurchasedProducts
        builder.Entity<MostPurchasedProduct>().ToTable("MostPurchasedProducts");
        builder.Entity<MostPurchasedProduct>().HasKey(p => p.Id);
        builder.Entity<MostPurchasedProduct>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<MostPurchasedProduct>().Property(p => p.ProductId).IsRequired();
        builder.Entity<MostPurchasedProduct>().Property(p => p.Name).IsRequired().HasMaxLength(100);
        builder.Entity<MostPurchasedProduct>().Property(p => p.Description).IsRequired().HasMaxLength(300);
        builder.Entity<MostPurchasedProduct>().Property(p => p.Category).IsRequired().HasMaxLength(100);
        builder.Entity<MostPurchasedProduct>().Property(p => p.Price).IsRequired();
        builder.Entity<MostPurchasedProduct>().Property(p => p.Image);
        
        //Products
        builder.Entity<Product>().ToTable("Products");
        builder.Entity<Product>().HasKey(p => p.Id);
        builder.Entity<Product>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Product>().Property(p => p.Title).IsRequired().HasMaxLength(100);
        builder.Entity<Product>().Property(p => p.Category).IsRequired().HasMaxLength(100);
        builder.Entity<Product>().Property(p => p.Author).IsRequired().HasMaxLength(100);
        builder.Entity<Product>().Property(p => p.Price).IsRequired();
        builder.Entity<Product>().Property(p => p.Image);
        
        //Profiles
        builder.Entity<Profile>().ToTable("Profiles");
        builder.Entity<Profile>().HasKey(p => p.Id);
        builder.Entity<Profile>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Profile>().Property(p => p.Name).IsRequired().HasMaxLength(100);
        builder.Entity<Profile>().Property(p => p.Birthday).IsRequired();
        builder.Entity<Profile>().Property(p => p.Email).IsRequired().HasMaxLength(100);
        builder.Entity<Profile>().Property(p => p.Phone);
        builder.Entity<Profile>().Property(p => p.PhotoUrl);
        
        //Reviews
        builder.Entity<Review>().ToTable("Reviews");
        builder.Entity<Review>().HasKey(p => p.Id);
        builder.Entity<Review>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Review>().Property(p => p.PetOwnerId).IsRequired();
        builder.Entity<Review>().Property(p => p.PetOwnerName).IsRequired().HasMaxLength(100);
        builder.Entity<Review>().Property(p => p.VeterinarianId).IsRequired();
        builder.Entity<Review>().Property(p => p.VeterinarianName).IsRequired().HasMaxLength(100);
        builder.Entity<Review>().Property(p => p.Comment).IsRequired().HasMaxLength(300);
        builder.Entity<Review>().Property(p => p.Stars).IsRequired();
        
        //Vets
        builder.Entity<Vet>().ToTable("Vets");
        builder.Entity<Vet>().HasKey(p => p.Id);
        builder.Entity<Vet>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Vet>().Property(p => p.Name).IsRequired().HasMaxLength(100);
        builder.Entity<Vet>().Property(p => p.Birthday).IsRequired();
        builder.Entity<Vet>().Property(p => p.Email).IsRequired().HasMaxLength(100);
        builder.Entity<Vet>().Property(p => p.AppointmentsQuantity);
        builder.Entity<Vet>().Property(p => p.Score);
        builder.Entity<Vet>().Property(p => p.Phone);
        builder.Entity<Vet>().Property(p => p.PhotoUrl);
        
        //VeterinariansNearYou
        builder.Entity<VeterinarianNearYou>().ToTable("VeterinariansNearYou");
        builder.Entity<VeterinarianNearYou>().HasKey(p => p.Id);
        builder.Entity<VeterinarianNearYou>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<VeterinarianNearYou>().Property(p => p.Name).IsRequired().HasMaxLength(100);
        builder.Entity<VeterinarianNearYou>().Property(p => p.Location).IsRequired().HasMaxLength(100);
        builder.Entity<VeterinarianNearYou>().Property(p => p.Score);
        builder.Entity<VeterinarianNearYou>().Property(p => p.Image);
        
        builder.UseSnakeCaseNamingConvention();
    }
}