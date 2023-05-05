using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using repository;
using Repository;

namespace Utimate_Web_API.ContextFactory
{
    public class RepositoryContextFactory  : IDesignTimeDbContextFactory<RepositoryContext>

    {
        public RepositoryContext CreateDbContext(string[] args)
{
var configuration = new ConfigurationBuilder()
.SetBasePath(Directory.GetCurrentDirectory())
.AddJsonFile("appsettings.json")
.Build();
var builder = new DbContextOptionsBuilder<RepositoryContext>().UseSqlServer(configuration.GetConnectionString("sqlConnection"));
return new RepositoryContext(builder.Options);
}
        
    }
}