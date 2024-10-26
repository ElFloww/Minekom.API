using Minekom.Domain.Bo;
using Minekom.Domain.Interfaces.Data.Entities;

namespace Minekom.Domain.Interfaces.Data.Repositories;

public interface IUserRepository : IGenericRepository
{
    Task<Utilisateur> GetUserByEmailAsync(string p_Email, CancellationToken p_CancellationToken = default);

    Task<IMappingAddEntity<Utilisateur, IEntity>> CreateUserAsync(Utilisateur p_User, CancellationToken p_CancellationToken = default);
}