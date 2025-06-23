using BookingSystemApi.Application.IRepositories;

namespace BookingSystemApi.Application.Commands.Resident.Edit
{
    public class EditResidentCommandHandler : IRequestHandler<EditResidentCommand>
    {
        private readonly IResidentRepository _residentRepository;
        public EditResidentCommandHandler(IResidentRepository residentRepository)
        {
            _residentRepository = residentRepository;
        }
        Task IRequestHandler<EditResidentCommand>.Handle(EditResidentCommand request, CancellationToken cancellationToken)
        {
            //read
            var model = _residentRepository.Load(request.Id);
            //doit
            model.Edit(request.FirstName, request.LastName, request.UserName, request.ResidentAddress);
            //save
            _residentRepository.Update(model);

            return Task.CompletedTask;

        }
    }
}
