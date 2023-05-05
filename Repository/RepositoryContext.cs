using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.OAuth;
using Entities;
using Repository.Configuration;

namespace Repository
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options) : base(options)
 {

 }
 protected override void OnModelCreating(ModelBuilder modelBuilder)
 {
 modelBuilder.ApplyConfiguration(new CompanyConfiguration());
 modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
 }
 public DbSet<Company>? Companies { get; set; }
 public DbSet<Employee>? Employees { get; set; }

        
    }
}