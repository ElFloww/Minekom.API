using Minekom.Domain.Bo;
using Minekom.Domain.Token;

namespace Minekom.Domain.Interfaces.Token;

public interface IJwtFactory
{
    JwtTokenResponse CreateToken(Utilisateur p_UserInfos);
}