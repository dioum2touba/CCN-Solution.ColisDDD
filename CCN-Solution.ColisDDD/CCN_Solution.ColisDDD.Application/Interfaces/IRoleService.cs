using CCN_Solution.ColisDDD.Application.DTOs;
using System.Threading.Tasks;

namespace CCN_Solution.ColisDDD.Application.Interfaces
{
    public interface IRoleService : IGenericRepositoryAsync<RoleDto>
    {

        Task<RoleDto> GetByIdAsync(string id);
        Task<bool> IfExists(string id);
    }
}