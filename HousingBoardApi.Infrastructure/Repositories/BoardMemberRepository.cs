using HousingBoardApi.Application.Commands.BoardMember.Create;
using HousingBoardApi.Application.Commands.BoardMember.Delete;
using HousingBoardApi.Application.Queries.BoardMember;
using HousingBoardApi.Application.Queries.BoardMember.GetAllBoardMembersWithRoles;
using HousingBoardApi.Application.Queries.BoardMember.GetBoardMemberWithRole;

namespace HousingBoardApi.Infrastructure.Repositories
{
    public class BoardMemberRepository : IBoardMemberRepository
    {
        private readonly HousingBoardDbContext _context;

        public BoardMemberRepository(HousingBoardDbContext context)
        {
            this._context = context;
        }

        Guid IBoardMemberRepository.Create(CreateBoardMemberCommand request)
        {
            var model = new BoardMemberEntity
            {
                Id = request.UserId,
                UserName = request.UserName,
                FirstName = request.FirstName,
                LastName = request.LastName,
                ResidentAddress = request.ResidentAddress,
                IsDeleted = false
            };

            _context.BoardMemberEntities.Add(model);
            _context.SaveChanges();

            return model.Id;
        }

        void IBoardMemberRepository.Delete(DeleteBoardMemberCommand request)
        {
            _context.Remove(_context.BoardMemberEntities.AsNoTracking().FirstOrDefault(x => x.Id == request.Id));
            _context.SaveChanges();
        }

        GetBoardMemberWithRoleQueryResult IBoardMemberRepository.Get(GetBoardMemberWithRoleQuery request)
        {
            var boardMemberModel = _context.BoardMemberEntities
                .Include(type => type.Roles).ThenInclude(role => role.Role)
                .AsNoTracking().FirstOrDefault(x => x.Id == request.Id);


            if (boardMemberModel == null) throw new Exception("No boardmember found");

            if (request.IncludeOldRoles == true)
            {

                return new GetBoardMemberWithRoleQueryResult
                {
                    Id = boardMemberModel.Id,
                    UserName = boardMemberModel.UserName,
                    FirstName = boardMemberModel.FirstName,
                    LastName = boardMemberModel.LastName,
                    ResidentAddress = boardMemberModel.ResidentAddress,
                    RowVersion = boardMemberModel.RowVersion,
                    BoardMemberRoles = boardMemberModel.Roles.Select(x => new BoardMemberRoleDto
                    {
                        StartDate = x.StartDate,
                        EndDate = x.EndDate,
                        Role = new RoleDto
                        {
                            Id = x.Role.Id,
                            RoleName = x.Role.RoleName
                        }
                    }).ToList()
                };
            }
            else
            {
                var role = boardMemberModel.Roles.Where(x => x.EndDate == null).FirstOrDefault();

                return new GetBoardMemberWithRoleQueryResult
                {
                    Id = boardMemberModel.Id,
                    UserName = boardMemberModel.UserName,
                    FirstName = boardMemberModel.FirstName,
                    LastName = boardMemberModel.LastName,
                    ResidentAddress = boardMemberModel.ResidentAddress,
                    RowVersion = boardMemberModel.RowVersion,
                    BoardMemberRoles = boardMemberModel.Roles.Where(y => y.EndDate == null).Select(x => new BoardMemberRoleDto
                    {
                        StartDate = x.StartDate,
                        EndDate = x.EndDate,
                        Role = new RoleDto
                        {
                            Id = x.Role.Id,
                            RoleName = x.Role.RoleName
                        }
                    }).ToList()
                };
            }

        }




        IEnumerable<GetAllBoardMembersWithRolesQueryResult> IBoardMemberRepository.GetAll()
        {

            var boardMemberModels = _context.BoardMemberEntities
                .Include(type => type.Roles).ThenInclude(role => role.Role)
                .AsNoTracking();


            foreach (var model in boardMemberModels)
            {
                var currentRole = model.Roles.Where(x => x.EndDate == null).FirstOrDefault();

                var role = new RoleDto
                {
                    Id = currentRole.Role.Id,
                    RoleName = currentRole.Role.RoleName
                };

                yield return new GetAllBoardMembersWithRolesQueryResult
                {
                    Id = model.Id,
                    UserName = model.UserName,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    ResidentAddress = model.ResidentAddress,
                    BoardMemberCurrentRole = new BoardMemberRoleDto { StartDate = currentRole.StartDate, EndDate = currentRole.EndDate, Role = role }
                };
            }
        }

        BoardMemberEntity IBoardMemberRepository.Load(Guid id)
        {
            var model = _context.BoardMemberEntities.FirstOrDefault(x => x.Id == id);

            return model == null ? throw new Exception("intet Bestyrelsesmedlem fundet i databasen") : model;
        }

        void IBoardMemberRepository.Update(BoardMemberEntity request)
        {
            _context.Update(request);
            _context.SaveChanges();
        }
    }
}
