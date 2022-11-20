using Microsoft.AspNetCore.Authentication.JwtBearer;
using SafePetBackend.SafePet.Domain.Repositories;
using SafePetBackend.SafePet.Domain.Services;
using SafePetBackend.SafePet.Persistent.Repositories;
using SafePetBackend.SafePet.Services;
using SafePetBackend.Security.Authorization.Handlers.Implementations;
using SafePetBackend.Security.Authorization.Handlers.Interfaces;
using SafePetBackend.Security.Authorization.Middleware;
using SafePetBackend.Security.Authorization.Settings;
using SafePetBackend.Security.Domain.Repositories;
using SafePetBackend.Security.Domain.Services;
using SafePetBackend.Security.Persistence.Repositories;
using SafePetBackend.Security.Services;
using SafePetBackend.Shared.Domain.Repositories;
using SafePetBackend.Shared.Persistence.Contexts;
using SafePetBackend.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;


var builder = WebApplication.CreateBuilder(args);

// Add CORS

builder.Services.AddCors();
// AppSettings Configuration
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    // Add API Documentation Information

    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "CoolSolutions SafePet API",
        Description = "CoolSolutions SafePet RESTful API",
        TermsOfService = new Uri("https://coolsolutions-safepet.com/tos"),
        Contact = new OpenApiContact
        {
            Name = "CoolSolutions.studio",
            Url = new Uri("https://coolsolutions.studio")
        },
        License = new OpenApiLicense
        {
            Name = "CoolSolutions SafePet Resources License",
            Url = new Uri("https://coolsolutions-safepet.com/license")
        }
        
    });
    
    options.EnableAnnotations();
    options.AddSecurityDefinition("bearerAuth", new OpenApiSecurityScheme
    {
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        Description = "JWR Authorization header using Bearer scheme"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "bearerAuth" }
            },
            Array.Empty<string>()
        }
    });
});

// Add Database Connection

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(
    options => options.UseMySQL(connectionString)
        .LogTo(Console.WriteLine, LogLevel.Information)
        .EnableSensitiveDataLogging()
        .EnableDetailedErrors());

// Add lowercase routes

builder.Services.AddRouting(options => options.LowercaseUrls = true);

// Dependency Injection Configuration

// Shared Injection Configuration

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();


// Learning Injection Configuration

builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();
builder.Services.AddScoped<IAppointmentService, AppointmentService>();

builder.Services.AddScoped<ICheckupRepository, CheckupRepository>();
builder.Services.AddScoped<ICheckupService, CheckupService>();

builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IClientService, ClientService>();

builder.Services.AddScoped<IMostPurchasedProductRepository, MostPurchasedProductRepository>();
builder.Services.AddScoped<IMostPurchasedProductService, MostPurchasedProductService>();

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddScoped<IProfileRepository, ProfileRepository>();
builder.Services.AddScoped<IProfileService, ProfileService>();

builder.Services.AddScoped<IReviewRepository, ReviewRepository>();
builder.Services.AddScoped<IReviewService, ReviewService>();

builder.Services.AddScoped<IVetRepository, VetRepository>();
builder.Services.AddScoped<IVetService, VetService>();

builder.Services.AddScoped<IVeterinarianNearYouRepository, VeterinarianNearYouRepository>();
builder.Services.AddScoped<IVeterinarianNearYouService, VeterinarianNearYouService>();



// Security Injection Configuration

builder.Services.AddScoped<IJwtHandler, JwtHandler>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

// AutoMapper Configuration

builder.Services.AddAutoMapper(
    typeof(SafePetBackend.SafePet.Mapping.ModelToResourceProfile),
    typeof(SafePetBackend.Security.Mapping.ModelToResourceProfile),
    typeof(SafePetBackend.SafePet.Mapping.ResourceToModelProfile),
    typeof(SafePetBackend.Security.Mapping.ResourceToModelProfile));



var app = builder.Build();

// Validation for ensuring Database Objects are created

using (var scope = app.Services.CreateScope())
using (var context = scope.ServiceProvider.GetService<AppDbContext>())
{
    context.Database.EnsureCreated();
}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("v1/swagger.json", "v1");
        options.RoutePrefix = "swagger";
    });
}
// Configure CORS 

    app.UseCors(x => x
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());

    // Configure Error Handler Middleware

    app.UseMiddleware<ErrorHandlerMiddleware>();

    app.UseMiddleware<JwtMiddleware>();

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
