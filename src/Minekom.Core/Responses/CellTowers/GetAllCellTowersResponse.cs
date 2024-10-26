using Minekom.Domain.Bo;

namespace Minekom.Core.Responses.CellTowers
{
    public class GetAllCellTowersResponse : UseCaseResponseMessage<IEnumerable<Antenne>>
    {
        public GetAllCellTowersResponse(IEnumerable<ErrorDto> p_Errors, string p_Message = null) : base(p_Errors, p_Message)
        {
        }

        public GetAllCellTowersResponse(IEnumerable<Antenne> p_Value, string p_Message = null) : base(p_Value, p_Message)
        {
        }
    }
}
