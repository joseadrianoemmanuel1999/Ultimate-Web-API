using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;
using Contratcs;
using Contracts;

namespace Repository
{
    public class CompanyRepository : RepositoryBase<Company>,ICompanyRepository
    {
        public CompanyRepository(RepositoryContext repositoryContext): base(repositoryContext)
        {
            
        }

public IEnumerable<Company> GetByIds(IEnumerable<Guid> ids, bool trackChanges) =>
 FindByCondition(x => ids.Contains(x.Id), trackChanges)
 .ToList();
         public Company GetCompany(Guid companyId, bool trackChanges) => 
    FindByCondition(c => c.Id.Equals(companyId), trackChanges) 
    .SingleOrDefault();
public void CreateCompany(Company company) => Create(company);

        public object GetAllCompanies(bool trackChanges)
        {
            throw new NotImplementedException();
        }
    }
}
