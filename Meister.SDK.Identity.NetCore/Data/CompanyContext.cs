using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Meister.SDK.Identity.NetCore.Data
{
    public class CompanyContext : DbContext
    {
        public CompanyContext(DbContextOptions<CompanyContext> options)
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                base.OnConfiguring(optionsBuilder);
                var builder = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                IConfigurationRoot config = builder.Build();
                optionsBuilder.UseSqlServer(config.GetConnectionString("Meister.SDK.IdentityDB"));
            }
        }
        public DbSet<Meister.SDK.Identity.NetCore.Models.Company> Company { get; set; }

        public DbSet<Meister.SDK.Identity.NetCore.Models.User> User { get; set; }

        public DbSet<Meister.SDK.Identity.NetCore.Models.MeisterConnection> MeisterConnection { get; set; }
    }
}
