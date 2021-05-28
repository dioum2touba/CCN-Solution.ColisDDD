using System.Collections.Generic;
using System.Threading.Tasks;
using CCN_Solution.ColisDDD.Domain.Entities;

namespace CCN_Solution.ColisDDD.Domain.IRepositories
{
    public interface IColisRepository : IRepositoryAsync<Colis>
    {
        Task<Colis> GetByIdAsyncWithInc(int id);
        Task<List<Colis>> GetColisAllAsyncWithInc();
        Task<Colis> GetReceptionneUnColis(int Id);
    }
}