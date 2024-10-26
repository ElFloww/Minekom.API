namespace Minekom.Core.Responses.Tools;

public class HashResponse : UseCaseResponseMessage<string>
{
    public HashResponse(IEnumerable<ErrorDto> p_Errors, string p_Message = null) : base(p_Errors, p_Message)
    {
    }

    public HashResponse(string p_Value, string p_Message = null) : base(p_Value, p_Message)
    {
    }
}