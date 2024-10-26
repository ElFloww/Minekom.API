using MediatR;
using Minekom.Core.Responses.CellTowers;

namespace Minekom.Core.Requests.CellTowers
{
    public class GetAllCellTowersRequest : IRequest<GetAllCellTowersResponse>
    {
        public GetAllCellTowersRequest()
        {

        }
    }
}
