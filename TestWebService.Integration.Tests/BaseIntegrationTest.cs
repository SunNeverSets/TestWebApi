namespace TestWebService.Integration.Tests
{
    public class BaseIntegrationTest
    {
        private TestFixture _fixture { get; set; }

        public BaseIntegrationTest(TestFixture testFixture)
        {
            _fixture = testFixture;
        }
    }
}
