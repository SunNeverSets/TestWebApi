using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using TestWebService.Database.DataModels;

namespace TestWebService.Database
{
    public class MyDbContext : DbContext
    {
        private readonly string? ConnectionString;

        public MyDbContext(IOptions<ConnectionStringConfiguration> connectionStringOption, DbContextOptions<MyDbContext> options) : base(options) 
        {
            ConnectionString = connectionStringOption.Value.ConnectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseNpgsql(ConnectionString);
        }

        public DbSet<LoginFailureDm> LoginFailures { get; set; }
    }
}
