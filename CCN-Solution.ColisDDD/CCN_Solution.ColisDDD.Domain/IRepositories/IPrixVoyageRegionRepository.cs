using System.Collections.Generic;
using System.Threading.Tasks;
using CCN_Solution.ColisDDD.Domain.Entities;

namespace CCN_Solution.ColisDDD.Domain.IRepositories
{
    public interface IPrixVoyageRegionRepository : IRepositoryAsync<PrixVoyageRegion>
    {
        Task<PrixVoyageRegion> GetByIdAsyncWithInc(int id);
        Task<List<PrixVoyageRegion>> GetPrixVoyageRegionAllAsyncWithInc();
    }
}