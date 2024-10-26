using Minekom.Core.Responses.Authentication;

namespace Minekom.API.Presenters.Authentication
{
    /// <summary>
    /// Presenter for jwtauthentication requests
    /// </summary>
    public class JwtAuthenticationPresenter : AResponseMessageJsonPresenter<JwtAuthenticationResponse>
    {
        /// <inheritdoc />
        protected override object GetSuccessMember(JwtAuthenticationResponse p_Response)
        {
            return p_Response.Value;
        }
    }
}