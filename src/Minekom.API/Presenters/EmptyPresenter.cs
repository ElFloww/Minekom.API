using Minekom.Core.Responses;

namespace Minekom.API.Presenters
{
    /// <summary>
    ///
    /// </summary>
    public class EmptyPresenter : AResponseMessageJsonPresenter<UseCaseResponseMessage>
    {
        /// <inheritdoc />
        protected override object GetSuccessMember(UseCaseResponseMessage p_Response)
        {
            return p_Response.Success;
        }
    }
}