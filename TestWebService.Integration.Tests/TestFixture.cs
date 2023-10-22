using TestWebService.Integration.Tests.ApiFacade;
using Xunit;

namespace TestWebService.Integration.Tests
{
    public class TestFixture : IDisposable
    {
        public TestFixture()
        {
            WebTestServer.StartTestServer();
            WebApi.SetHttpClient(WebTestServer.TestServer.CreateClient());
        }

        public void Dispose()
        {
            WebTestServer.StopTestServer();
        }
    }

    [CollectionDefinition("Test collection")]
    public class TestCollection : ICollectionFixture<TestFixture>
    {
    }
}
