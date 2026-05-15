using Microsoft.EntityFrameworkCore;
using Prenumerantsystem.Models;

namespace Prenumerantsystem.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Subscriber> Subscribers { get; set; }
}