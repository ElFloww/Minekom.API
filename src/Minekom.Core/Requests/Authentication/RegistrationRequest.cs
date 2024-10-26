using MediatR;
using Minekom.Core.Responses.Authentication;
using Minekom.Domain.Bo;

namespace Minekom.Core.Requests.Authentication;

public class RegistrationRequest : IRequest<RegistrationResponse>
{
    public Utilisateur User { get; }

    public RegistrationRequest(Utilisateur p_User)
    {
        User = p_User;
    }
}