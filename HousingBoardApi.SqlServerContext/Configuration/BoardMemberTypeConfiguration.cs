

using HousingBoardApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HousingBoardApi.SqlServerContext.Configuration;

public class BoardMemberTypeConfiguration : IEntityTypeConfiguration<BoardMemberEntity>
{
    public void Configure(EntityTypeBuilder<BoardMemberEntity> builder)
    {
        //ResourceEntity bliver mappet til tabellen Resource med skemeaet resource
        builder.ToTable("BoardMember");


        //erklære primærnøglen
        builder.HasKey(x => x.Id);
        //builder.HasOne(b => b.Role).WithOne(r=>r.BoardMember).HasForeignKey<BoardMemberRoleEntity>(r=>r.BoardMember.Id);
    }
}
