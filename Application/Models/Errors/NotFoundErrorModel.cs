using Application.Enums;

namespace Application.Models.Errors;

public class NotFoundErrorModel() : ErrorModel("Usuário não encontrado", "Verifique os dados e tente novamente", errorType: ErrorType.CONFLICT)
{
}
