
using BookingSystemApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SqlServerContext.ResourceConfiguration;

public class ResourceTypeConfiguration : IEntityTypeConfiguration<ResourceEntity>
{
    public void Configure(EntityTypeBuilder<ResourceEntity> builder)
    {
        //ResourceEntity bliver mappet til tabellen Resource med skemeaet resource
        builder.ToTable("Resource");

        //erklære primærnøglen
        builder.HasKey(x => x.Id);
    }
}
