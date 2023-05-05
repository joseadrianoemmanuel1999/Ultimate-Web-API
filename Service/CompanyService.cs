using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts;
using Contratcs;
using Service.Contracts;
namespace Service
{
    internal sealed class CompanyService : ICompanyService
    {
private readonly IRepositoryManager _repository;
private readonly ILoggerManager _logger;
public CompanyService(IRepositoryManager repository, ILoggerManager logger)
{
_repository = repository;
_logger = logger;
}
}

        
    }