using CCN_Solution.ColisDDD.Domain.Entities;
using CCN_Solution.ColisDDD.Domain.IRepositories;
using CCN_Solution.ColisDDD.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace CCN_Solution.ColisDDD.Infrastructure.Persistence.Repositories
{
    public class ColisRepository : RepositoryAsync<Colis>, IColisRepository
    {
        private readonly DbSet<Colis> _colis;

        public ColisRepository(ApplicationDbContext dbContext) : base(dbContext)
            => _colis = dbContext.Set<Colis>();
    }
}