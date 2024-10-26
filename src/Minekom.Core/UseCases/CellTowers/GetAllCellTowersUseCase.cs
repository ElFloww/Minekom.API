using MediatR;
using Microsoft.Extensions.Logging;
using Minekom.Core.Requests.CellTowers;
using Minekom.Core.Responses.CellTowers;
using Minekom.Domain.Bo;
using Minekom.Domain.Interfaces.Data;

namespace Minekom.Core.UseCases.CellTowers
{
    internal class GetAllCellTowersUseCase : AUseCase, IRequestHandler<GetAllCellTowersRequest, GetAllCellTowersResponse>
    {
        public GetAllCellTowersUseCase(IUnitOfWork p_UnitOfWork, ILogger<GetAllCellTowersUseCase> p_Logger) 
            : base(p_UnitOfWork, p_Logger)
        {
        }

        public async Task<GetAllCellTowersResponse> Handle(GetAllCellTowersRequest request, CancellationToken cancellationToken)
        {
            try
            {
                IEnumerable<Antenne> v_CellTowers = await m_UnitOfWork.CellTowerRepository.GetAllCellTowers(cancellationToken);

                return new GetAllCellTowersResponse(v_CellTowers);
            }
            catch(Exception v_Ex)
            {
                m_Logger.LogError(v_Ex, "An error was thrown");
                return new GetAllCellTowersResponse(new[] { v_Ex.ToError() });
            }
        }
    }
}
