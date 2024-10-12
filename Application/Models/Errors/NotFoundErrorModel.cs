using Application.Enums;

namespace Application.Models.Errors;

public class NotFoundErrorModel() : ErrorModel("Entidade não encontrada", "Verifique os dados e tente novamente", errorType: ErrorType.NOT_FOUND)
{
}
