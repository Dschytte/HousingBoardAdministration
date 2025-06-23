

using BookingSystemApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookingSystemApi.SqlServerContext.Configuration;

public class ResidentTypeConfiguration : IEntityTypeConfiguration<ResidentEntity>
{
    public void Configure(EntityTypeBuilder<ResidentEntity> builder)
    {
        //ResourceEntity bliver mappet til tabellen Resource med skemeaet resource
        builder.ToTable("Resident");

        //erklære primærnøglen
        builder.HasKey(x => x.Id);
    }
}
