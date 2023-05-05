using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;
using Contracts;

namespace Repository
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
 
{
 public EmployeeRepository(RepositoryContext repositoryContext)
 : base(repositoryContext)
 {
 }
}
}