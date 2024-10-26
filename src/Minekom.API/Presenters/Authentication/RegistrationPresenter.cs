using Minekom.Core.Responses.Authentication;

namespace Minekom.API.Presenters.Authentication
{
    /// <summary>
    /// Presenter for registration request
    /// </summary>
    public class RegistrationPresenter : AResponseMessageJsonPresenter<RegistrationResponse>
    {
        /// <inheritdoc />
        protected override object GetSuccessMember(RegistrationResponse p_Response)
        {
            return p_Response.Value;
        }
    }
}