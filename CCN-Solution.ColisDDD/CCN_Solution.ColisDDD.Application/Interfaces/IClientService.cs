using System.Threading.Tasks;
using CCN_Solution.ColisDDD.Application.DTOs;

namespace CCN_Solution.ColisDDD.Application.Interfaces
{
    public interface IClientService : IGenericRepositoryAsync<ClientDto>
    {
        Task<ClientDto> GetClientParTelephone(int telephone);

    }
}