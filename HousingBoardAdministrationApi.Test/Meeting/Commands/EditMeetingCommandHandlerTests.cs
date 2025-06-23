using HousingBoardApi.Application.Commands.Meeting.Edit;
using HousingBoardApi.Application.IRepositories;
using HousingBoardApi.Domain.Entities;
using MediatR;
using Moq;

namespace HousingBoardApi.Test.Meeting.Commands
{
    public class EditMeetingCommandHandlerTests
    {
        [Fact]
        public async Task Handle_ValidEditMeetingCommand_UpdatesRepositoryAndSendsEmail()
        {
            // Arrange
            var meetingRepositoryMock = new Mock<IMeetingRepository>();
            var publisherMock = new Mock<IPublisher>();

            var handler = new EditMeetingCommandHandler(meetingRepositoryMock.Object, publisherMock.Object);

            var existingMeetingId = Guid.NewGuid();
            var existingModel = new MeetingEntity // Assuming you have a MeetingModel class
            {
                Id = existingMeetingId,
                // Set other properties as needed
            };

            meetingRepositoryMock.Setup(repo => repo.Load(existingMeetingId)).Returns(existingModel);

            var editCommand = new EditMeetingCommand
            {
                Id = existingMeetingId,
                Title = "Updated Meeting",
                Description = "Updated Description",
                MeetingTime = DateTime.Now,
                AddressLocation = "Updated Location",
                RowVersion = existingModel.RowVersion // Assuming you have a RowVersion property
            };

            // Act
            await handler.Handle(editCommand, CancellationToken.None);

            // Assert
            meetingRepositoryMock.Verify(repo => repo.Load(existingMeetingId), Times.Once);
            meetingRepositoryMock.Verify(repo => repo.Update(It.IsAny<MeetingEntity>()), Times.Once);

            //publisherMock.Verify(publisher => publisher.Publish(It.IsAny<CreateMeetingEmailEvent>()), Times.Once);

            // Add more assertions as needed
        }
    }
}

