using AFI_Lab1.Models;
using Microsoft.EntityFrameworkCore;

namespace AFI_Lab1.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Advertiser> Advertisers { get; set; }
    public DbSet<Ad> Ads { get; set; }
}