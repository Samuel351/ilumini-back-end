using Ilumini.Data;
using Ilumini.Domain.Entities;
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

        public Result<List<FormResponse>> GetAll()
        {
            return new Result<List<FormResponse>>(_appDbContext.Forms.ToList().Select(x => new FormResponse(x)).ToList());
        }

        public Result<FormResponse> GetFormById(Guid formId)
        {
            var form = _appDbContext.Forms.Include(x => x.Questions).ThenInclude(x => x.Options).FirstOrDefault(x => x.Id == formId);

            if (form == null) return new Result<FormResponse>(new ResponseModel("Formulário não encontrado!", HttpStatusCode.OK));

            return new Result<FormResponse>(new FormResponse(form));
        }

        public Result<FormResponse> GetFormByInstance(Guid instanceId)
        {
            var formInstance = _appDbContext.FormInstances.FirstOrDefault(x => x.Id == instanceId);

            if (formInstance == null) return new Result<FormResponse>(new ResponseModel("Formulário não encontrado!", HttpStatusCode.OK));

            return GetFormById(formInstance.FormId);    
        }

        public Result<FormInstanceResponse> LauchForm(Guid formId)
        {
            var form = _appDbContext.Forms.FirstOrDefault(x => x.Id == formId);

            if (form == null) return new Result<FormInstanceResponse>(new ResponseModel("Formulário não encontrado!", HttpStatusCode.OK));

            var formInstance = new FormInstance(formId);

            _appDbContext.FormInstances.Add(formInstance);
            _appDbContext.SaveChanges();

            return new Result<FormInstanceResponse>(new FormInstanceResponse(formInstance.Id.ToString()));
        }

        public Result SetResponse(List<FormAnswerRequest> responses)
        {
            var formInstance = _appDbContext.FormInstances.FirstOrDefault(x => x.Id == responses[0].FormInstanceId);

            if (formInstance == null) return new Result<FormResponse>(new ResponseModel("Formulário não encontrado!", HttpStatusCode.OK));

            _appDbContext.Responses.AddRange(responses.Select(x => x.ToEntity()));
            _appDbContext.SaveChanges();

            return new Result<FormResponse>(new ResponseModel("Formulário respondido", HttpStatusCode.OK));
        }
    }
}
