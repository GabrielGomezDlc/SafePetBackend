using Microsoft.EntityFrameworkCore;
using SafePetBackend.SafePet.Domain.Models;
using SafePetBackend.Security.Domain.Models;
using SafePetBackend.Shared.Extensions;


namespace SafePetBackend.Shared.Persistence.Contexts;

public class AppDbContext: DbContext
{
    
    public DbSet<User> Users { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    
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
        builder.Entity<User>().Property(p => p.Name).IsRequired();
        builder.Entity<User>().Property(p => p.Birthday).IsRequired();
        builder.Entity<User>().Property(p => p.Email).IsRequired().HasMaxLength(100);
        builder.Entity<User>().Property(p => p.Phone).IsRequired();
        builder.Entity<User>().Property(p => p.Score);
        builder.Entity<User>().Property(p => p.AppointmentsQuantity);
        builder.Entity<User>().Property(p => p.Role).IsRequired();
        
 
        
        //Appointments
        builder.Entity<Appointment>().ToTable("Appointments");
        builder.Entity<Appointment>().HasKey(p => p.Id);
        builder.Entity<Appointment>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Appointment>().Property(p => p.Date).IsRequired();
        builder.Entity<Appointment>().Property(p => p.VeterinarianId).IsRequired();
        builder.Entity<Appointment>().Property(p => p.VeterinarianName).IsRequired();
        builder.Entity<Appointment>().Property(p => p.PetOwnerId).IsRequired();
        builder.Entity<Appointment>().Property(p => p.PetOwnerName).IsRequired();
        builder.Entity<Appointment>().Property(p => p.Image).IsRequired();

        builder.UseSnakeCaseNamingConvention();
    }
}