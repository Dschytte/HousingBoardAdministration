using BookingSystemApi.Domain.Entities;
using BookingSystemApi.SqlServerContext.Configuration;
using Microsoft.EntityFrameworkCore;
using SqlServerContext.Configuration;
using SqlServerContext.ResourceConfiguration;


namespace BookingSystemApi.SqlServerContext;

public class BookingSystemDbContext : DbContext
{
    public BookingSystemDbContext(DbContextOptions<BookingSystemDbContext> options) : base(options)
    {
    }

    public DbSet<ResourceEntity> ResourceEntities { get; set; }
    public DbSet<BookingEntity> BookingEntities { get; set; }
    public DbSet<ResidentEntity> ResidentEntities { get; set; }



    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new ResourceTypeConfiguration());
        builder.ApplyConfiguration(new BookingTypeConfiguration());
        builder.ApplyConfiguration(new ResidentTypeConfiguration());

    }
}
