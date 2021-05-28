using System.Threading.Tasks;
using CCN_Solution.ColisDDD.Domain.Entities;

namespace CCN_Solution.ColisDDD.Domain.IRepositories
{
    public interface IRoleRepository : IRepositoryAsync<Role>
    {
        Task<Role> GetByIdAsync(string id);
    }
}