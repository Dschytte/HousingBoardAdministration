using HousingBoardApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HousingBoardApi.SqlServerContext.Configuration
{

    public class BoardMemberRoleTypeConfiguration : IEntityTypeConfiguration<BoardMemberRoleEntity>
    {
        public void Configure(EntityTypeBuilder<BoardMemberRoleEntity> builder)
        {
            //ResourceEntity bliver mappet til tabellen Resource med skemeaet resource
            builder.ToTable("BoardMemberRole");


            //erklære primærnøglen
            builder.HasKey(x => x.Id);
        }
    }
}
