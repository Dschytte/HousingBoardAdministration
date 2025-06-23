using HousingBoardApi.Application.Commands.BoardMemberRole.Create;
using HousingBoardApi.Application.Commands.BoardMemberRole.Delete;

namespace HousingBoardApi.Infrastructure.Repositories
{
    public class BoardMemberRoleRepository : IBoardMemberRoleRepository
    {
        private readonly HousingBoardDbContext _context;

        public BoardMemberRoleRepository(HousingBoardDbContext context)
        {
            _context = context;
        }

        void IBoardMemberRoleRepository.Add(CreateBoardMemberRoleCommand request)
        {
            RoleEntity role = new RoleEntity { Id = request.RoleId };
            BoardMemberEntity boardMember = _context.BoardMemberEntities.Where(x => x.Id == request.BoardMemberId).FirstOrDefault();

            _context.Attach(role);

            var activeRoles = _context.BoardMemberRoleEntities
                .Where(x => x.BoardMember.Id == request.BoardMemberId && x.EndDate == null);

            foreach (var activeRole in activeRoles)
            {
                activeRole.EndDate = DateTime.Now;
            }

            var newModel = new BoardMemberRoleEntity
            {
                Role = role,
                BoardMember = boardMember,
                StartDate = DateTime.Now,
                EndDate = null
            };

            _context.BoardMemberRoleEntities.Add(newModel);
            _context.SaveChanges();
        }

        void IBoardMemberRoleRepository.Delete(DeleteBoardMemberRoleCommand request)
        {
            _context.Remove(_context.BoardMemberRoleEntities.AsNoTracking().FirstOrDefault(x => (x.BoardMember.Id == request.BoardMemberId) && x.Role.Id == request.RoleId));
            _context.SaveChanges();
        }
    }
}
