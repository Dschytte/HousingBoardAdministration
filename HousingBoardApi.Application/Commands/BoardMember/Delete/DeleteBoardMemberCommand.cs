namespace HousingBoardApi.Application.Commands.BoardMember.Delete
{
    public class DeleteBoardMemberCommand : IRequest
    {
        public Guid Id { get; set; }

    }
}
