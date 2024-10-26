using Minekom.Domain.Bo;

namespace Minekom.Core.Responses.Authentication;

public class RegistrationResponse : UseCaseResponseMessage<Utilisateur>
{
    public RegistrationResponse(IEnumerable<ErrorDto> p_Errors, string p_Message = null) : base(p_Errors, p_Message)
    {
    }

    public RegistrationResponse(Utilisateur p_Value, string p_Message = null) : base(p_Value, p_Message)
    {
    }
}