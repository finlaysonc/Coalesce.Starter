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
            builder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=Coalesce.TaskListSampleDb;Trusted_Connection=True;MultipleActiveResultSets=True;");
            return new AppDbContext(builder.Options);
        }
    }
}
