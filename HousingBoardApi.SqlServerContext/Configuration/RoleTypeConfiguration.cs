using HousingBoardApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HousingBoardApi.SqlServerContext.Configuration;

public class RoleTypeConfiguration : IEntityTypeConfiguration<RoleEntity>
{
    public void Configure(EntityTypeBuilder<RoleEntity> builder)
    {
        //ResourceEntity bliver mappet til tabellen Resource med skemeaet resource
        builder.ToTable("Role");

        //erklære primærnøglen
        builder.HasKey(x => x.Id);
    }
}
