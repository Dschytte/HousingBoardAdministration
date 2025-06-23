using HousingBoardApi.Application.Commands.Meeting.Delete;
using HousingBoardApi.Application.IRepositories;
using Moq;

namespace HousingBoardApi.Test.Meeting.Commands
{
    public class DeleteMeetingCommandHandlerTests
    {
        private readonly Mock<IMeetingRepository> _meetingRepositoryMock;

        public DeleteMeetingCommandHandlerTests()
        {
            _meetingRepositoryMock = new();
        }

        [Fact]
        public async Task Handler_Should_Fail_If_Meeting_has_Documents()
        {
            //arrange
            var command = new DeleteMeetingCommand
            {
                Id = Guid.NewGuid(),
            };

            _meetingRepositoryMock.Setup(repo => repo.Delete(It.IsAny<DeleteMeetingCommand>())).Throws(new Exception("Der var et dokument under mødet"));

            var handler = new DeleteMeetingCommandHandler(_meetingRepositoryMock.Object);

            //act

            //Assert
            var exeption = await Assert.ThrowsAsync<Exception>(() => handler.Handle(command, default));

            _meetingRepositoryMock.Verify(repo => repo.Delete(It.IsAny<DeleteMeetingCommand>()), Times.Once());

        }
    }
}
