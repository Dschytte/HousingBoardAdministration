using HousingBoardApi.Application.Commands.Meeting.Create;
using HousingBoardApi.Application.Transaction;
using HousingBoardApi.Application.Transaction.Behaviors;
using MediatR;
using Moq;

namespace HousingBoardApi.Test.UnitOfWork
{
    public class UnitOfWorkBehaviorTests
    {
        [Fact]
        public async Task Handle_UnitOfWorkBehavior_ShouldSaveChanges()
        {
            // Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var handlerMock = new Mock<IRequestHandler<CreateMeetingCommand>>();

            var behavior = new UnitOfWorkBehavior<CreateMeetingCommand, Unit>(unitOfWorkMock.Object);

            var command = new CreateMeetingCommand
            {
                MeetingOwnerId = Guid.NewGuid(),
                MeetingTypeId = Guid.NewGuid(),
                AddressLocation = "Adreese",
                Description = "Description",
                MeetingTime = DateTime.Now,
                Title = "Title"
            };

            // Act
            await behavior.Handle(command, () => (Task<Unit>)handlerMock.Object.Handle(command, CancellationToken.None), CancellationToken.None);

            // Assert
            unitOfWorkMock.Verify(uow => uow.SaveChanges(It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
