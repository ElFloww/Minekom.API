using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Minekom.Domain.Interfaces.Data.Repositories;
using Bo = Minekom.Domain.Bo;
using Ef = Minekom.Infrastructure.Data.EntityFramework.Entities;


namespace Minekom.Infrastructure.Data.EntityFramework.Repositories
{
    internal class CellTowerRepository : GenericRepository<Ef.Antenne>, ICellTowerRepository
    {
        public CellTowerRepository(DbContext p_DbContext, IMapper p_Mapper, ILogger p_Logger) : base(p_DbContext, p_Mapper, p_Logger)
        {

        }

        public async Task<IEnumerable<Bo.Antenne>> GetAllCellTowers(CancellationToken p_CancellationToken = default)
        {
            return Mapper.Map<IEnumerable<Bo.Antenne>>(await GetAllAsync(p_CancellationToken: p_CancellationToken));
        }
    }
}
