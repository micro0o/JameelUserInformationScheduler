using JUIS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace JUIS.Infrastructure
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<UserDbContext>
    {
        public UserDbContext CreateDbContext(string[] args)
        {
            IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json").Build();

            var builder = new DbContextOptionsBuilder<UserDbContext>();
            var connectionString =
                configuration.GetConnectionString("DefaultConnection");
            builder.UseSqlServer(connectionString);

            return new UserDbContext(builder.Options);
        }
    }
}
