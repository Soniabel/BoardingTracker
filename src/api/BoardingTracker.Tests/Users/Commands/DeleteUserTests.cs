using BoardingTracker.Application.Users.Commands.DeleteUser;
using BoardingTracker.Tests.Helpers;
using FluentAssertions;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace BoardingTracker.Tests.Users.Commands
{
    public abstract class DeleteUserTests
    {
        public abstract class DeleteUserTest : BaseTest
        {
            protected readonly DeleteUserRequest _userRequest;

            protected readonly DeleteUserHandler _userHandler;

            protected DeleteUserTest()
            {
                _userRequest = new DeleteUserRequest()
                {
                    Id = 2
                };

                _userHandler = new DeleteUserHandler(_dbContext);
            }
        }

        public class Handle : DeleteUserTest
        {
            [Fact]
            public async Task Deleted_Id_is_returned_when_request_is_valid()
            {
                var expectedId = 2;

                var result = await _userHandler.Handle(_userRequest, new CancellationToken());

                result.Should().Be(expectedId);
            }

            [Fact]
            public async Task Bad_request_is_returned_when_request_is_invalid()
            {
                _userRequest.Id = 0;

                var result = _userHandler.Handle(_userRequest, new CancellationToken());

                result.Exception.Should().NotBeNull();
            }
        }
    }
}
