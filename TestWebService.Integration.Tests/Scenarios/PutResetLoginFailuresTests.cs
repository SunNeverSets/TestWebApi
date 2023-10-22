using FluentAssertions;
using System.Net;
using TestWebService.DataModels;
using TestWebService.Integration.Tests.ApiFacade.Endpoints;
using Xunit;

namespace TestWebService.Integration.Tests.Scenarios
{
    [Collection("Test collection")]
    public class PutResetLoginFailuresTests : BaseIntegrationTest
    {
        public PutResetLoginFailuresTests(TestFixture fixture) : base(fixture)
        {
        }

        [Fact]
        public void Should_Reset_Login_Fail_Count_For_User()
        {
            var userName = "Shulha Volodymyr";
            var expectedResult = $"Login failures for {userName} have been reset.";

            var response = LoginFailRequests.PutLoginFailRecord(new ResetLoginFailParametersDto { UserName = userName });
            response.EnsureSuccessful();
            var actualResult = response.ContentAsString;
            actualResult.Should().Be(expectedResult);
        }

        [Fact]
        public void Should_Not_Reset_Login_Fail_Count_For_User___User_Not_Found()
        {
            var userName = "Vova";
            var expectedResult = $"User {userName} not found in login failures.";

            var response = LoginFailRequests.PutLoginFailRecord(new ResetLoginFailParametersDto { UserName = userName });
            response.Ensure(HttpStatusCode.NotFound);
            var actualResult = response.ContentAsString;
            actualResult.Should().Be(expectedResult);
        }


        [Fact]
        public void Should_Not_Reset_Login_Fail_Count_For_User___User_Is_Not_Provided()
        {
            string userName = null;
            var expectedResult = "Username parameter is required.";

            var response = LoginFailRequests.PutLoginFailRecord(new ResetLoginFailParametersDto { UserName = userName });
            response.Ensure(HttpStatusCode.BadRequest);
            var actualResult = response.ContentAsString;
            actualResult.Should().Be(expectedResult);
        }
    }
}
