using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts;
using Entities;
namespace Contracts
{
   public interface ICompanyRepository
 {
    IEnumerable<Company> GetAllCompanies(bool trackChanges);
 }
   public interface IEmployeeRepository
 {
 }
}