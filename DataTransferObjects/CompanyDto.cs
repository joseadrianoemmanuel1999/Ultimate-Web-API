using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Utimate_Web_API.DataTransferObjects
{

        public record CompanyDto(Guid Id, string Name, string FullAddress);
        
    
}