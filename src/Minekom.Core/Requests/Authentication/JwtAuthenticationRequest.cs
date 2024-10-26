using Minekom.Core.Responses.Authentication;
using MediatR;

namespace Minekom.Core.Requests.Authentication;

public class JwtAuthenticationRequest : IRequest<JwtAuthenticationResponse>
{
    public string Login { get; }
    public string Password { get; }

    public JwtAuthenticationRequest(string p_Login, string p_Password)
    {
        Login = p_Login;
        Password = p_Password;
    }
}