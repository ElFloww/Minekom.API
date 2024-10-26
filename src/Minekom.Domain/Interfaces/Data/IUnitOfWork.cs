using Minekom.Domain.Interfaces.Data.Repositories;

namespace Minekom.Domain.Interfaces.Data;

public interface IUnitOfWork : IDisposable
{
    ICellTowerRepository CellTowerRepository { get; }
    IUserRepository UserRepository { get; }

    int Save();

    void BeginTransaction();

    void CommitTransaction();

    void RollbackTransaction();
}