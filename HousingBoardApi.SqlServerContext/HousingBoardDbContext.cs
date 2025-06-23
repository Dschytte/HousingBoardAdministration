using HousingBoardApi.Domain.Entities;
using HousingBoardApi.SqlServerContext.Configuration;
using HousingBoardApi.SqlServerContext.Interceptors;
using Microsoft.EntityFrameworkCore;

namespace HousingBoardApi.SqlServerContext;

public class HousingBoardDbContext : DbContext
{
    public HousingBoardDbContext(DbContextOptions<HousingBoardDbContext> options) : base(options)
    {
    }

    public DbSet<BoardMemberEntity> BoardMemberEntities { get; set; }
    public DbSet<BoardMemberRoleEntity> BoardMemberRoleEntities { get; set; }
    public DbSet<DocumentEntity> DocumentEntities { get; set; }
    public DbSet<DocumentTypeEntity> DocumentTypeEntities { get; set; }
    public DbSet<MeetingEntity> MeetingEntities { get; set; }
    public DbSet<MeetingTypeEntity> MeetingTypeEntities { get; set; }
    public DbSet<RoleEntity> RoleEntities { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(new SoftDeleteInterceptor());
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new BoardMemberTypeConfiguration());
        builder.ApplyConfiguration(new BoardMemberRoleTypeConfiguration());
        builder.ApplyConfiguration(new DocumentTypeConfiguration());
        builder.ApplyConfiguration(new DocumentTypeTypeConfiguration());
        builder.ApplyConfiguration(new MeetingTypeConfiguration());
        builder.ApplyConfiguration(new MeetingTypeTypeConfiguration());
        builder.ApplyConfiguration(new RoleTypeConfiguration());
    }
}
