using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;

namespace TestWebService.Integration.Tests
{
    public class WebTestServer
    {
        private static TestServer _testServer;

        public static TestServer TestServer => _testServer;

        public static void StartTestServer()
        {
            if (_testServer == null)
            {
                _testServer = CreateTestServer();
            }
        }

        public static void StopTestServer()
        {
            if (_testServer != null)
            {
                _testServer.Dispose();
                _testServer = null;
            }
        }

        public static TestServer CreateTestServer()
        {
            var builder = Host.CreateDefaultBuilder()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<TestStartup>();
                    webBuilder.UseTestServer();
                });

            var webServer = builder.Start();
            return webServer.GetTestServer();
        }
    }
}
