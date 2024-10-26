using Minekom.Core.Responses;

namespace Minekom.API.Presenters.Authentication
{
    /// <summary>
    /// Presenter for reset password
    /// </summary>
    public class ResetPasswordPresenter : AResponseMessageJsonPresenter<EmptyResponse>
    {
        /// <inheritdoc />
        protected override object GetSuccessMember(EmptyResponse p_Response)
        {
            return p_Response.Success;
        }
    }
}