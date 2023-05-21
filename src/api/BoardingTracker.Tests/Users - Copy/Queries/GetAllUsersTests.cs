using BoardingTracker.Application.Users.Queries.GetAllUsers;
using BoardingTracker.Tests.Helpers;
using FluentAssertions;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using static BoardingTracker.Application.Users.Queries.GetAllUsers.GetUsers;

namespace BoardingTracker.Tests.Users.Queries
{
    public abstract class GetAllUsersTests
    {
        public abstract class GetAllUsersTest : BaseTest
        {
            protected readonly GetUsers _userRequest;

            protected readonly GetUsersHandler _userHandler;

            protected GetAllUsersTest()
            {
                _userRequest = new GetUsers();

                _userHandler = new GetUsersHandler(_dbContext, _mapper);
            }
        }

        public class Handle : GetAllUsersTest
        {
            [Fact]
            public async Task UserList_is_returned_when_request_is_valid()
            {
                var result = await _userHandler.Handle(_userRequest, new CancellationToken());

                result.Items.Should().HaveCount(x => x >= 1);
            }
        }
    }
}
