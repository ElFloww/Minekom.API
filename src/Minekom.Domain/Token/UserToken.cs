using Minekom.Domain.Bo;

namespace Minekom.Domain.Token;

public record UserToken
{
    public Utilisateur User { get; init; }

    public JwtTokenResponse Token { get; init; }
}