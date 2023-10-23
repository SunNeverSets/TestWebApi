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
            _fixture.Dispose();
        }
    }
}
