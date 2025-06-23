namespace HousingBoardApi.Application.Queries.BoardMember;

public record RoleDto
{
    public Guid Id { get; set; }
    public string RoleName { get; set; }
}
