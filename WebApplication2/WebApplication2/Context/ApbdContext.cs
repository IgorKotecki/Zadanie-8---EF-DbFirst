using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Context;

public class ApbdContext : DbContext
{
    public ApbdContext(DbContextOptions<ApbdContext> options)
    {
        
    }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Trip> Trips { get; set; }
    public DbSet<Client_Trip> ClientTrips { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<Country_Trpi> CountryTrips { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client_Trip>()
            .HasKey(ct => new { ct.IdClient, ct.IdTrip });

        modelBuilder.Entity<Country_Trpi>()
            .HasKey(ct => new { ct.IdCountry, ct.IdTrip });
    }
}