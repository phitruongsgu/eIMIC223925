using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace eIMIC223925.DATA.EF
{
    public class EIMIC223925DbContextFactory : IDesignTimeDbContextFactory<EIMIC223925DbContext>
    {
        public EIMIC223925DbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()) // đọc thư mục hiện tại trong project DATA
                .AddJsonFile("appsettings.json") // phải cài nuget Configuration.FileExtensions và Configuration.Json để nó đọc file appsetting.json 
                .Build();

            var connectionString = configuration.GetConnectionString("eIMIC223925Db");
            var optionsBuilder = new DbContextOptionsBuilder<EIMIC223925DbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new EIMIC223925DbContext(optionsBuilder.Options);
        }
    }
}
