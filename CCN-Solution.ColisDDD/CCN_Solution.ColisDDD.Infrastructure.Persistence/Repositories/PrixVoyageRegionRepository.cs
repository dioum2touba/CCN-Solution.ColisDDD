using System.Collections.Generic;
using System.Threading.Tasks;
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

        public async Task<PrixVoyageRegion> GetByIdAsyncWithInc(int id)
            => await _prixVoyageRegion.Include(p => p.RegionDepart)
                .Include(p => p.RegionArrivee).FirstOrDefaultAsync(p => p.Id == id);

        public async Task<List<PrixVoyageRegion>> GetPrixVoyageRegionAllAsyncWithInc()
            => await _prixVoyageRegion.Include(p => p.RegionDepart)
                .Include(p => p.RegionArrivee).ToListAsync();
    }
}