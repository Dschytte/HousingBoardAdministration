
using HousingBoardApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HousingBoardApi.SqlServerContext.Configuration;


public class MeetingTypeConfiguration : IEntityTypeConfiguration<MeetingEntity>
{
    public void Configure(EntityTypeBuilder<MeetingEntity> builder)
    {
        //ResourceEntity bliver mappet til tabellen Resource med skemeaet resource
        builder.ToTable("Meeting");

        builder.HasQueryFilter(x => x.IsDeleted == false);

        builder.HasOne(d => d.MeetingOwner)
        .WithMany(m => m.Meetings)
        .OnDelete(DeleteBehavior.Restrict);

        //erklære primærnøglen
        builder.HasKey(x => x.Id);
    }
}
