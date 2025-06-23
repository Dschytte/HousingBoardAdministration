
using HousingBoardApi.Application.Queries.MeetingType.Dto;

namespace HousingBoardApi.Infrastructure.Repositories;

public class MeetingTypeRepository : IMeetingTypeRepository
{
    private readonly HousingBoardDbContext _context;

    public MeetingTypeRepository(HousingBoardDbContext context)
    {
        _context = context;
    }

    MeetingTypeGetQueryResultDto IMeetingTypeRepository.Get(Guid id)
    {
        var model = _context.MeetingTypeEntities.AsNoTracking().FirstOrDefault(x => x.Id == id);

        return new MeetingTypeGetQueryResultDto
        {
            Id = model.Id,
            Type = model.Type
        };
    }

    IEnumerable<MeetingTypeGetAllQueryResultDto> IMeetingTypeRepository.GetAll()
    {
        foreach (var model in _context.MeetingTypeEntities.AsNoTracking().ToList())
        {
            yield return new MeetingTypeGetAllQueryResultDto
            {
                Id = model.Id,
                Type = model.Type
            };
        }
    }
}
