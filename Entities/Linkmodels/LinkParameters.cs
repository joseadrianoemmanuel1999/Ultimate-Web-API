using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shared.RequestFeatures;
using Microsoft.Net.Http.Headers;

namespace Entities.Linkmodels
{
  public record LinkParameters(EmployeeParameters EmployeeParameters, Microsoft.AspNetCore.Http.HttpContext Context);
}