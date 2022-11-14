// See https://aka.ms/new-console-template for more information

using EFExercises;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

Console.WriteLine("Init db");

IConfigurationRoot configuration = new ConfigurationBuilder()
    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
    .AddJsonFile("appsettings.json")
    .Build();
string connectionString = configuration.GetConnectionString("SqliteConnection");

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlite(connectionString));
    })
    .Build();

AppDbContext dbContext = host.Services.GetRequiredService<AppDbContext>();
dbContext.Database.EnsureCreated();

dbContext.MyData.Add(new Table()
{
    Name = "name1",
    Description = "description1"
});
dbContext.SaveChanges();
