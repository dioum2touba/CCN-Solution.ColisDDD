using System.Collections.Generic;
using System.Threading.Tasks;
using CCN_Solution.ColisDDD.Application.DTOs;
using CCNSolution.ColisDDD.Application.DTOs;
using Microsoft.AspNetCore.Identity;

namespace CCN_Solution.ColisDDD.Application.Interfaces
{
    public interface IUserService //: IGenericRepositoryAsync<UserDto>
    {
        bool IsValidUser(string userName, string password);

        List<RoleDto> GeRoleDto();

        UserDto FindUserById(string userId);

        List<UserDto> GetUsers();

        Task<UserDto> AddUsersAsync(UserDto UserDto);

        void DeleteUsers(UserDto UserDto);

        UserDto FindByNameAsync(string roleName);

        int UpdateAsync(UserDto UserDto);

        string GeneratePasswordResetTokenAsync(UserDto user);

        UserDto FindByEmailAsync(string email);

        IdentityResult ResetPasswordAsync(UserDto user, string token, string newPassword);

        UserDto FindByUsername(string username);

        List<string> GetRolesAsync(UserDto user);

        bool IfExists(string id);

        List<UserDto> GetApplicationUsersWithRoles();

        List<UserDto> GetByIdAsyncWithInc(int id);
    }
}

/*
 *bool IsValidUser(string userName, string password);
   
   Task<List<RoleDto>> GeRoleDto();
   
   Task<UserDto> FindUserById(string userId);
   
   Task<List<UserDto>> GetUsers();
   
   Task<UserDto> AddUsers(UserDto UserDto);
   
   void DeleteUsers(UserDto UserDto);
   
   Task<UserDto> FindByNameAsync(string roleName);
   
   Task<int> UpdateAsync(UserDto UserDto);
   
   string GeneratePasswordResetTokenAsync(UserDto user);
   
   Task<UserDto> FindByEmailAsync(string email);
   
   IdentityResult ResetPasswordAsync(UserDto user, string token, string newPassword);
   
   Task<UserDto> FindByUsername(string username);
   
   Task<List<string>> GetRolesAsync(UserDto user);
 *
 */