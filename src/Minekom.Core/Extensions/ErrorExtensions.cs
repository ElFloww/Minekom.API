using BetD.Transverse.API.ErrorCodes;
using Minekom.Core.Responses;

namespace Minekom.Core.Extensions;

public static class ErrorExtensions
{
    public static ErrorDto ToError(this Exception p_Ex)
    {
        return new ErrorDto(CommonErrors.UnknowError, p_Ex.Message, p_Ex);
    }

    public static ErrorDto ToError(this Exception p_Ex, string p_ErrorCode)
    {
        return new ErrorDto(p_ErrorCode, p_Ex.Message, p_Ex);
    }
}