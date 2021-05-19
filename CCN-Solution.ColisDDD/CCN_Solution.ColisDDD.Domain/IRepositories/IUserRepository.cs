using System.Collections.Generic;
using CCN_Solution.ColisDDD.Domain.Entities;

namespace CCN_Solution.ColisDDD.Domain.IRepositories
{
    public interface IUserRepository : IRepositoryAsync<ApplicationUser>
    {
        List<ApplicationUser> GetApplicationUsersWithRoles();

        ApplicationUser FindByUsername(string username);
    }
}