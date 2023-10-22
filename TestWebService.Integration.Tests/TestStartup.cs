using Microsoft.Extensions.DependencyInjection;

namespace TestWebService.Integration.Tests
{
    public class TestStartup : Startup
    {
        public TestStartup() : base()
        {
        }

        public override void ConfigureServices(IServiceCollection services)
        {
            base.ConfigureServices(services);
            services.AddMvc().AddApplicationPart(typeof(Startup).Assembly);
        }
    }
}