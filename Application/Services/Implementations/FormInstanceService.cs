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
    public class FormInstanceService(IRepositoryBase<FormInstance> repository, ILogger<IServiceBase<FormInstance>> logger) : ServiceBase<FormInstance>(repository, logger), IFormInstanceService
    {
    }
}
