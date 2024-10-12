using Ilumini.DTOs;
using System.Net;

namespace Ilumini.Consts
{
    public static class ResponseMap
    {
        public static HashSet<ResponseModel> ResponseMapping { get; } = new HashSet<ResponseModel>(
        [
            new ResponseModel(){ Message = "Entidade já existe", StatusCode = HttpStatusCode.Conflict }
        ]);
    }
}
