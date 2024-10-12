using Application.Models;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface IQuestionService : IServiceBase<Question>
    {

        Task<Result<IEnumerable<Question>>> GetQuestionsByFormId(Guid formId);

    }
}
