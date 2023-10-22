using FluentAssertions;
using TestWebService.Database.DataModels;
using TestWebService.DataModels;
using TestWebService.Integration.Tests.ApiFacade.Endpoints;
using Xunit;

namespace TestWebService.Integration.Tests.Scenarios
{
    [Collection("Test collection")]
    public class GetLoginFailuresTests : BaseIntegrationTest
    {
        public GetLoginFailuresTests(TestFixture fixture) : base(fixture)
        {
        }

        [Theory, MemberData(nameof(ExpectedData))]
        public void Should_Filter_By_Request_Parameters(string? userName, int? failCount, int? fetchLimit, List<LoginFailureDm> expectedResult)
        {
            var parameters = new LoginFailParametersDto
            {
                UserName = userName,
                FailCount = failCount,
                FetchLimit = fetchLimit
            };

            var actualResult = LoginFailRequests.GetLoginFailRecords(parameters).Content<List<LoginFailureDm>>();

            actualResult.Should().BeEquivalentTo(expectedResult);
        }

        public static IEnumerable<object[]> ExpectedData =
            new List<object[]>
            {
                    // [InlineData(null, null, null)] //request without parameters
                new object[] { null, null, null, new List<LoginFailureDm>
                {
                    new LoginFailureDm
                    {
                        UserName = "Shulha Volodymyr",
                        FailureCount = 5,
                        Id = 1
                    },
                    new LoginFailureDm
                    {
                        UserName = "Avril Lavigne",
                        FailureCount = 2,
                        Id = 2
                    },
                    new LoginFailureDm
                    {
                        UserName = "Post Malone",
                        FailureCount = 1,
                        Id = 3
                    }
                }},
                    // [InlineData("Shulha Volodymyr", null, null)] //request with provided existing userName ONLY
                new object[] { "Shulha Volodymyr", null, null, new List<LoginFailureDm>
                {
                    new LoginFailureDm
                    {
                        UserName = "Shulha Volodymyr",
                        FailureCount = 5,
                        Id = 1
                    }
                }},
                    // [InlineData("Shulha Volodymyr", 5, 2)] //request with all provided parameters
                new object[] { "Shulha Volodymyr", 5, 2, new List<LoginFailureDm>
                {
                    new LoginFailureDm
                    {
                        UserName = "Shulha Volodymyr",
                        FailureCount = 5,
                        Id = 1
                    }
                }},
                    // [InlineData("Volodymyr Shulha", 5, 2)] //request with provided non-existing userName
                new object[] { "Volodymyr Shulha", 5, 2, new List<LoginFailureDm>
                {
                }},
                    // [InlineData(null, 2, null)] //request with provided failCount ONLY
                new object[] { null, 2, null, new List<LoginFailureDm>
                {
                    new LoginFailureDm
                    {
                        UserName = "Avril Lavigne",
                        FailureCount = 2,
                        Id = 2
                    },
                }},
                    // [InlineData(null, null, 2)] //request with provided fetchLimit ONLY
                new object[] { null, null, 2, new List<LoginFailureDm>
                {
                    new LoginFailureDm
                    {
                        UserName = "Shulha Volodymyr",
                        FailureCount = 5,
                        Id = 1
                    },
                    new LoginFailureDm
                    {
                        UserName = "Avril Lavigne",
                        FailureCount = 2,
                        Id = 2
                    },
                }},
            };
    }
}
