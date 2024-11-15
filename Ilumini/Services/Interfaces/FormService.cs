using Ilumini.Data;
using Ilumini.Presentation.DTOs.Request;
using Ilumini.Presentation.DTOs.Response;
using Ilumini.Services.Implementations;
using Ilumini.Services.Models;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Ilumini.Services.Interfaces
{
    public class FormService(AppDbContext appDbContext) : IFormService
    {

        private readonly AppDbContext _appDbContext = appDbContext;

        public Result CreateForm(CreateFormRequest request)
        {
            var form = request.ToEntity();

            _appDbContext.Forms.Add(form);
            _appDbContext.SaveChanges();

            return new Result(new ResponseModel("Formulário criado!", HttpStatusCode.OK));
        }

        public Result<FormResponse> GetFormById(Guid formId)
        {
            var form = _appDbContext.Forms.Include(x => x.Questions).ThenInclude(x => x.Options).FirstOrDefault(x => x.Id == formId);

            if (form == null) return new Result<FormResponse>(new ResponseModel("Formulário não encontrado!", HttpStatusCode.OK));

            return new Result<FormResponse>(new FormResponse(form));
        }
    }
}
