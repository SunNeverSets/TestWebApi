using TestWebService;

Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>()).Build().Run();


/*
builder.Services.AddDbContext<MyDbContext>();
builder.Configuration.SetBasePath(Directory.GetCurrentDirectory())
                     .AddJsonFile("appsettings.json");

builder.Services.Configure<ConnectionStringConfiguration>(opt => builder.Configuration.GetSection("ConnectionStringConfiguration"));
*/


