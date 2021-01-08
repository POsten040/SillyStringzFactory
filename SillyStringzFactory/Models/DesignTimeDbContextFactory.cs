using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace SillyStringzFactory.Models
{
  public class SillyStringzFactoryContextFactory : IDesignTimeDbContextFactory<SillyStringzFactoryContext>
  {

    SillyStringzFactoryContext IDesignTimeDbContextFactory<SillyStringzFactoryContext>.CreateDbContext(string[] args)
    {
      IConfigurationRoot configuration = new ConfigurationBuilder()
          .SetBasePath(Directory.GetCurrentDirectory())
          .AddJsonFile("appsettings.json")
          .Build();

      var builder = new DbContextOptionsBuilder<SillyStringzFactoryContext>();
      var connectionString = configuration.GetConnectionString("DefaultConnection");

      builder.UseMySql(connectionString);

      return new SillyStringzFactoryContext(builder.Options);
    }
  }
}