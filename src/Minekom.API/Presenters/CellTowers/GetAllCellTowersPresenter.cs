using Minekom.Core.Responses.CellTowers;

namespace Minekom.API.Presenters.CellTowers
{
    public class GetAllCellTowersPresenter : AResponseMessageJsonPresenter<GetAllCellTowersResponse>
    {
        protected override object GetSuccessMember(GetAllCellTowersResponse p_Response)
        {
            return p_Response.Value;
        }
    }
}
