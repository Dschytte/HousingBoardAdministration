using BookingSystemApi.Application.IRepositories;

namespace BookingSystemApi.Application.Commands.Resource.Edit
{
    public class EditResourceCommandHandler : IRequestHandler<EditResourceCommand>
    {
        private readonly IResourceRepository _resourceRepository;

        public EditResourceCommandHandler(IResourceRepository resourceRepository)
        {
            _resourceRepository = resourceRepository;
        }
        Task IRequestHandler<EditResourceCommand>.Handle(EditResourceCommand request, CancellationToken cancellationToken)
        {
            //read
            var model = _resourceRepository.Load(request.Id);
            //doit
            model.Edit(request.Specification, request.Description, request.Price, request.RowVersion);
            //save
            _resourceRepository.Update(model);

            return Task.CompletedTask;

        }
    }
}
