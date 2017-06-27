using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coalesce.TaskListSample.Data
{
    public class DevelopmentAppDbContextFactory : IDbContextFactory<AppDbContext>
    {
        public AppDbContext Create(DbContextFactoryOptions options)
        {
            // This is only used when adding migrations and updating the database from the cmd line.
            // It shouldn't ever be used in code where it might end up running in production.
            var builder = new DbContextOptionsBuilder<AppDbContext>();
            builder.UseSqlServer("Server=(local);Database=Coalesce.TaskListSampleDb;Trusted_Connection=True;MultipleActiveResultSets=True;");
            return new AppDbContext(builder.Options);
        }
    }
}

// public class DevelopmentAppDbContextFactory : IDbContextFactory<SchoolContext> { public
// SchoolContext Create() { var environmentName = Environment.GetEnvironmentVariable( "Hosting:Environment");

// var basePath = AppContext.BaseDirectory;

// return Create(basePath, environmentName); }

// public SchoolContext Create(DbContextFactoryOptions options) { return Create(
// options.ContentRootPath, options.EnvironmentName); }

// private SchoolContext Create(string basePath, string environmentName) { var builder = new
// Microsoft.Extensions.Configuration.ConfigurationBuilder() .SetBasePath(basePath)
// .AddJsonFile("appsettings.json") .AddJsonFile($"appsettings.{environmentName}.json", true) .AddEnvironmentVariables();

// var config = builder.Build();

// var connstr = config.GetConnectionString("(default)");

// if (String.IsNullOrWhiteSpace(connstr) == true) { throw new InvalidOperationException( "Could not
// find a connection string named '(default)'."); } else { return Create(connstr); } }

// private SchoolContext Create(string connectionString) { if
// (string.IsNullOrEmpty(connectionString)) throw new ArgumentException( $"{nameof(connectionString)}
// is null or empty.", nameof(connectionString));

// var optionsBuilder = new DbContextOptionsBuilder<SchoolContext>();

// optionsBuilder.UseSqlServer(connectionString);

//            return new SchoolContext(optionsBuilder.Options);
//        }
//    }
//}