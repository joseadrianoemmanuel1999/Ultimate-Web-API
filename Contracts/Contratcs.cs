using Entities;
using Shared.RequestFeatures;
using Shared.DataTransferObjects;
using Microsoft.AspNetCore.Http;

namespace Contracts
{
    public interface ICompanyRepository
    {
        Task<IEnumerable<Company>> GetAllCompaniesAsync(bool trackChanges);
        Task<Company> GetCompanyAsync(Guid companyId, bool trackChanges);
        void CreateCompany(Company company);
        Task<IEnumerable<Company>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges);
        void DeleteCompany(Company company);


    }
    public interface IEmployeeRepository
    {
        Task<PagedList<Employee>> GetEmployeesAsync(Guid companyId,
EmployeeParameters employeeParameters, bool trackChanges);
        Task<IEnumerable<Employee>> GetEmployees(Guid companyId, bool trackChanges);
        Task<Employee> GetEmployee(Guid companyId, Guid id, bool trackChanges);
        void CreateEmployeeForCompany(Guid companyId, Employee employee);
        void DeleteEmployee(Employee employee);
     }
     public interface IDataShaper<T>
{
IEnumerable<ShapedEntity> ShapeData(IEnumerable<T> entities, string
fieldsString);
ShapedEntity ShapeData(T entity, string fieldsString);
}
     public interface IEmployeeLinks
{
LinkResponse TryGenerateLinks(IEnumerable<EmployeeDto> employeesDto,
string fields, Guid companyId, HttpContext httpContext);
}
}