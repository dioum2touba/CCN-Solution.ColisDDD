using CCN_Solution.ColisDDD.Domain.Entities;
using CCN_Solution.ColisDDD.Domain.IRepositories;
using CCN_Solution.ColisDDD.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace CCN_Solution.ColisDDD.Infrastructure.Persistence.Repositories
{
    public class PrixVoyageRegionRepository : RepositoryAsync<PrixVoyageRegion>, IPrixVoyageRegionRepository
    {
        private readonly DbSet<PrixVoyageRegion> _prixVoyageRegion;

        public PrixVoyageRegionRepository(ApplicationDbContext dbContext) : base(dbContext)
            => _prixVoyageRegion = dbContext.Set<PrixVoyageRegion>();
    }
}