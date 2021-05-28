using System.Collections.Generic;
using System.Threading.Tasks;
using CCN_Solution.ColisDDD.Domain.Entities;

namespace CCN_Solution.ColisDDD.Domain.IRepositories
{
    public interface ILivraisonRepository : IRepositoryAsync<Livraison>
    {
        Task<List<Livraison>> GetLivraisonsAllAsyncWithInc();
    }
}