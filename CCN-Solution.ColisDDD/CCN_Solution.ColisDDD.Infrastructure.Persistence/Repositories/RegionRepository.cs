using CCN_Solution.ColisDDD.Domain.Entities;
using CCN_Solution.ColisDDD.Domain.IRepositories;
using CCN_Solution.ColisDDD.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace CCN_Solution.ColisDDD.Infrastructure.Persistence.Repositories
{
    public class RegionRepository : RepositoryAsync<Region>, IRegionRepository
    {
        private readonly DbSet<Region> _regions;

        public RegionRepository(ApplicationDbContext dbContext) : base(dbContext)
            => _regions = dbContext.Set<Region>();
    }
}