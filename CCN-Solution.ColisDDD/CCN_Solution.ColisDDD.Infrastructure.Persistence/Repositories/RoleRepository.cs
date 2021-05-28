using System.Threading.Tasks;
using CCN_Solution.ColisDDD.Domain.Entities;
using CCN_Solution.ColisDDD.Domain.IRepositories;
using CCN_Solution.ColisDDD.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace CCN_Solution.ColisDDD.Infrastructure.Persistence.Repositories
{
    public class RoleRepository : RepositoryAsync<Role>, IRoleRepository
    {
        private readonly DbSet<Role> _roles;

        public RoleRepository(ApplicationDbContext dbContext) : base(dbContext)
            => _roles = dbContext.Set<Role>();

        public async Task<Role> GetByIdAsync(string id)
            => await _roles.FirstOrDefaultAsync(r => r.Id == id);
    }
}