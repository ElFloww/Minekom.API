using Minekom.Core.Responses.Authentication;
using Minekom.Domain.Bo;
using MediatR;

namespace Minekom.Core.Requests.Authentication
{
    public abstract class ARegistrationRequest : IRequest<RegistrationResponse>
    {
        public Utilisateur User { get; set; }

        protected ARegistrationRequest(Utilisateur p_User)
        {
            User = p_User;
        }
    }
}