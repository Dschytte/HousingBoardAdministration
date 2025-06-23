using BookingSystemApi.Application.IRepositories;

namespace BookingSystemApi.Application.Queris.Resident.GetResident
{
    public class GetResidentQueryHandler : IRequestHandler<GetResidentQuery, GetResidentQueryResult>
    {

        private readonly IResidentRepository _residentRepository;

        public GetResidentQueryHandler(IResidentRepository residentRepository)
        {
            _residentRepository = residentRepository;

        }


        Task<GetResidentQueryResult> IRequestHandler<GetResidentQuery, GetResidentQueryResult>.Handle(GetResidentQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_residentRepository.Get(request));
        }
    }
}
