namespace HousingBoardApi.Application.Queries.Role.Dto
{
    public class RoleGetQueryResultDto
    {
        public Guid Id { get; set; }

        //[Timestamp]
        //public byte[] RowVersion { get; set; }
        //public bool IsDeleted { get; set; }
        public string RoleName { get; set; }
    }
}
