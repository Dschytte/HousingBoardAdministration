using HousingBoardApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HousingBoardApi.SqlServerContext.Configuration;

public class DocumentTypeConfiguration : IEntityTypeConfiguration<DocumentEntity>
{
    public void Configure(EntityTypeBuilder<DocumentEntity> builder)
    {
        //ResourceEntity bliver mappet til tabellen Resource med skemeaet resource
        builder.ToTable("Document");

        builder.HasOne(d => d.Meeting)
        .WithMany(m => m.Documents)
        .OnDelete(DeleteBehavior.Restrict);

        builder.HasQueryFilter(x => x.IsDeleted == false);


        //erklære primærnøglen
        builder.HasKey(x => x.Id);
    }
}
