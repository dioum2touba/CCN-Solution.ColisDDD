using System.Threading.Tasks;
using CCN_Solution.ColisDDD.Domain.Entities;

namespace CCN_Solution.ColisDDD.Domain.IRepositories
{
    public interface IClientRepository : IRepositoryAsync<Client>
    {
        Task<Client> GetClientParTelephone(int telephone);
    }
}