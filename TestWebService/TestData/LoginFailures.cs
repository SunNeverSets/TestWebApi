using TestWebService.Database.DataModels;

namespace TestWebService.TestData
{
    public static class LoginFailures
    {
        public static List<LoginFailureDm> LoginFailuresData = new()
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
