using BookingSystemApi.Application.IRepositories;

namespace BookingSystemApi.Application.Queris.Resident.GetAllResident;

public class GetAllResidentQueryHandler : IRequestHandler<GetAllResidentQuery, List<GetAllResidentQueryResult>>
{
    private readonly IResidentRepository _ResidentRepository;

    public GetAllResidentQueryHandler(IResidentRepository residentRepository)
    {
        _ResidentRepository = residentRepository;
    }

    Task<List<GetAllResidentQueryResult>> IRequestHandler<GetAllResidentQuery, List<GetAllResidentQueryResult>>.Handle(GetAllResidentQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(_ResidentRepository.GetAll(request.Id).ToList());
    }
}
