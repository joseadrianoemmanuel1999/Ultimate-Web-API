using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Entities;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using Entities.Linkmodels;

namespace Service.Contracts
{
    public interface IEmployeeService
    {
       Task<(LinkResponse linkResponse, MetaData metaData)> GetEmployeesAsync(Guid companyId, 
      LinkParameters linkParameters, bool trackChanges);
        Task<IEnumerable<EmployeeDto>> GetEmployees(Guid companyId, bool trackChanges);
        Task<EmployeeDto> GetEmployee(Guid companyId, Guid id, bool trackChanges);
        Task<EmployeeDto> CreateEmployeeForCompany(Guid companyId, EmployeeForCreationDto
          employeeForCreation, bool trackChanges);
        Task<(EmployeeForUpdateDto employeeToPatch, Employee employeeEntity)>
        GetEmployeeForPatch(Guid companyId, Guid id, bool compTrackChanges, bool empTrackChanges);
        Task DeleteEmployeeForCompany(Guid companyId, Guid id, bool trackChanges);
        void UpdateEmployeeForCompany(Guid companyId, Guid id,
        EmployeeForUpdateDto employeeForUpdate, bool compTrackChanges, bool empTrackChanges);
        void SaveChangesForPatch(EmployeeForUpdateDto employeeToPatch, Employee employeeEntity);

    }
}