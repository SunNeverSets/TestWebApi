using TestWebService.Database.DataModels;
using TestWebService.TestData;

namespace TestWebService.Integration.Tests
{
    public class BaseIntegrationTest : IDisposable
    {
        private TestFixture _fixture { get; set; }

        public BaseIntegrationTest(TestFixture testFixture)
        {
            _fixture = testFixture;
        }

        public void Dispose()
        {
            LoginFailures.LoginFailuresData = new()
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
            };
        }
    }
}
