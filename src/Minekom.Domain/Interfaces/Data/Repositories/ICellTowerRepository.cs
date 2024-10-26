using Minekom.Domain.Bo;

namespace Minekom.Domain.Interfaces.Data.Repositories
{
    public interface ICellTowerRepository : IGenericRepository
    {
        Task<IEnumerable<Antenne>> GetAllCellTowers(CancellationToken p_CancellationToken = default);
    }
}
