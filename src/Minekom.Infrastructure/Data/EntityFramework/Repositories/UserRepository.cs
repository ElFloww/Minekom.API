using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Minekom.Domain.Interfaces.Data.Entities;
using Minekom.Domain.Interfaces.Data.Repositories;
using Minekom.Infrastructure.Data.Mapping;

using Bo = Minekom.Domain.Bo;
using Ef = Minekom.Infrastructure.Data.EntityFramework.Entities;

namespace Minekom.Infrastructure.Data.EntityFramework.Repositories
{
    internal class UserRepository : GenericRepository<Ef.Utilisateur>, IUserRepository
    {
        public UserRepository(DbContext p_DbContext, IMapper p_Mapper, ILogger p_Logger) 
            : base(p_DbContext, p_Mapper, p_Logger)
        {
        }

        public async Task<IMappingAddEntity<Bo.Utilisateur, IEntity>> CreateUserAsync(Bo.Utilisateur p_User, CancellationToken p_CancellationToken = default)
        {
            IMappingAddEntity<Bo.Utilisateur, Ef.Utilisateur> v_Mapping =
                new MappingAddEntity<Bo.Utilisateur, Ef.Utilisateur>(Mapper, p_User);

            await AddAsync(v_Mapping.DtoEntity, p_CancellationToken);
            return v_Mapping;
        }

        public async Task<Bo.Utilisateur> GetUserByEmailAsync(string p_Email, CancellationToken p_CancellationToken = default)
        {
            return Mapper.Map<Bo.Utilisateur>(await FindBy(p_U => p_U.Email == p_Email).SingleOrDefaultAsync(p_CancellationToken));
        }
    }
}
