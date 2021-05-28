using System.Collections.Generic;
using System.Threading.Tasks;
using CCN_Solution.ColisDDD.Domain.Entities;

namespace CCN_Solution.ColisDDD.Domain.IRepositories
{
    public interface IUserRepository : IRepositoryAsync<ApplicationUser>
    {
        List<ApplicationUser> GetApplicationUsersWithRoles();

        ApplicationUser FindByUsername(string username);

        Task<List<ApplicationUser>> GetByIdAsyncWithInc(int id);

        Task<List<Role>> GetRoleByUserIdAsyncWithInc(string userId);
    }
}