using System.Collections.Generic;
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

        UserDto AddUsers(UserDto UserDto);

        void DeleteUsers(UserDto UserDto);

        UserDto FindByNameAsync(string roleName);

        int UpdateAsync(UserDto UserDto);

        string GeneratePasswordResetTokenAsync(UserDto user);

        UserDto FindByEmailAsync(string email);

        IdentityResult ResetPasswordAsync(UserDto user, string token, string newPassword);

        UserDto FindByUsername(string username);

        List<string> GetRolesAsync(UserDto user);
    }
}