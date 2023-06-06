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
IEnumerable<Company> GetByIds(IEnumerable<Guid> ids, bool trackChanges) ;
 Company GetCompany(Guid companyId, bool trackChanges);
 void CreateCompany(Company company);
       IEnumerable<Company> GetAllCompanies(bool trackChanges);
        void DeleteCompany(Company company);

        
    }
   public interface IEmployeeRepository
 {
    IEnumerable<Employee> GetEmployees(Guid companyId, bool trackChanges);
    Employee GetEmployee(Guid companyId, Guid id, bool trackChanges);
    void CreateEmployeeForCompany(Guid companyId, Employee employee);
    void DeleteEmployee(Employee employee);
 }
}