using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Enums
{
    public enum ErrorType
    {
        NOT_FOUND = 404,
        ALREADY_EXISTS = 403,
        EXCEPTION = 500,
        CONFLICT = 409,
        NO_CONTENT = 204
    }
}
