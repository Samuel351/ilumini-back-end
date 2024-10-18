using Application.Repositories.Interfaces;
using Application.Services.Interfaces;
using Domain.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Implementations
{
    public class FormInstanceResponseService(IRepositoryBase<FormInstanceResponse> repository, ILogger<IServiceBase<FormInstanceResponse>> logger) : ServiceBase<FormInstanceResponse>(repository, logger), IFormInstanceResponseService
    {
    }
}
