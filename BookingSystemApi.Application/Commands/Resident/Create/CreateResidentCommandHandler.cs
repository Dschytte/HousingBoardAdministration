using BookingSystemApi.Application.IRepositories;

namespace BookingSystemApi.Application.Commands.Resident.Create
{
    public class CreateResidentCommandHandler : IRequestHandler<CreateResidentCommand>
    {
        private readonly IResidentRepository _residentRepository;

        public CreateResidentCommandHandler(IResidentRepository residentRepository)
        {
            _residentRepository = residentRepository;
        }


        public Task Handle(CreateResidentCommand request, CancellationToken cancellationToken)
        {
            _residentRepository.Create(request);
            return Task.CompletedTask;
        }
    }
}
