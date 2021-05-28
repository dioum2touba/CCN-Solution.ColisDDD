using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CCN_Solution.ColisDDD.Application.DTOs;
using CCN_Solution.ColisDDD.Application.Interfaces;
using CCN_Solution.ColisDDD.Domain.Entities;
using CCN_Solution.ColisDDD.Domain.IRepositories;
using Microsoft.AspNetCore.Identity;

namespace CCN_Solution.ColisDDD.Infrastructure.Persistence.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IAgenceService _agenceService;
        private readonly RoleManager<Role> _roleManager;

        public UserService(UserManager<ApplicationUser> userManager, IUserRepository userRepository, IMapper mapper,
            IRoleRepository roleRepository, RoleManager<Role> roleManager, IAgenceService agenceService)
        {
            _userManager = userManager;
            _mapper = mapper;
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _roleManager = roleManager;
            _agenceService = agenceService;
        }


        public UserDto FindUserById(string userId)
        {
            var user = _userManager.FindByIdAsync(userId).Result;
            var userDto = _mapper.Map<UserDto>(user);
            // userDto.Agence = 
            return userDto;
            // return new UserDto()
            // {
            //     Email = user.Email,
            //     UserName = user.UserName,
            //     AccessFailedCount = user.AccessFailedCount,
            //     FirstName = user.FirstName,
            //     Id = user.Id,
            //     LastName = user.LastName,
            //     PhoneNumber = user.PhoneNumber,
            //     SecurityStamp = user.SecurityStamp,
            // };
        }

        public List<UserDto> GetUsers()
            => _mapper.Map<List<UserDto>>(_userRepository.GetApplicationUsersWithRoles());

        public List<RoleDto> GeRoleDto()
        {
            var role = _roleRepository.GetAllAsync().Result;
            return _mapper.Map<List<RoleDto>>(role);
        }

        public UserDto AddUsers(UserDto entity)
        {
            var user = _userRepository.AddAsync(_mapper.Map<ApplicationUser>(entity)).Result;
            return _mapper.Map<UserDto>(user);
        }

        public void DeleteUsers(UserDto UserDto)
            => _userManager.DeleteAsync(_mapper.Map<ApplicationUser>(UserDto));

        public UserDto FindByNameAsync(string userName)
            => _mapper.Map<UserDto>(_userManager.FindByNameAsync(userName).Result);

        public int UpdateAsync(UserDto UserDto)
        {
            var user = _userManager.FindByIdAsync(UserDto.Id).Result;
            user.FirstName = UserDto.FirstName;
            user.LastName = UserDto.LastName;
            user.PhoneNumber = UserDto.PhoneNumber;
            var result = _userManager.UpdateAsync(user).Result;
            return result.Succeeded ? 1 : 0;
        }

        public string GeneratePasswordResetTokenAsync(UserDto user)
            => _userManager.GeneratePasswordResetTokenAsync(_mapper.Map<ApplicationUser>(user)).Result;

        public IdentityResult ResetPasswordAsync(UserDto user, string token, string newPassword)
            => _userManager.ResetPasswordAsync(_mapper.Map<ApplicationUser>(user), token, newPassword).Result;

        public UserDto FindByEmailAsync(string email)
            => _mapper.Map<UserDto>(_userManager.FindByEmailAsync(email).Result);

        public UserDto FindByUsername(string username)
        {
            var user = _mapper.Map<UserDto>(_userRepository.FindByUsername(username));
            var rolesname = GetRolesAsync(user);
            rolesname.ForEach(elt =>
            {
                var role = _roleManager.FindByNameAsync(elt).Result;
                user.Roles.Add(new RoleDto { Id = role.Id, Name = role.Name, ConcurrencyStamp = role.ConcurrencyStamp, NormalizedName = role.NormalizedName });
            });
            return user;
        }

        public List<string> GetRolesAsync(UserDto user)
        {
            var roles = new List<string>();
            var res = _userManager.GetRolesAsync(_mapper.Map<ApplicationUser>(user)).Result;
            roles.AddRange(res);
            return roles;
        }

        public bool IfExists(string id)
        {
            var users = _userRepository.GetAllAsync().Result;
            return users.Any(a => a.Id == id);
        }

        public List<UserDto> GetApplicationUsersWithRoles()
        {
            var users = _mapper.Map<List<UserDto>>(_userRepository.GetApplicationUsersWithRoles());
            users.ForEach(elt => elt.Roles.AddRange(_mapper.Map<List<RoleDto>>(_userRepository.GetRoleByUserIdAsyncWithInc(elt.Id).Result)));
            return users;
        }

        public List<UserDto> GetByIdAsyncWithInc(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool IsValidUser(string userName, string password)
        {
            //_logger.LogInformation($"Validating user [{userName}]");
            if (string.IsNullOrWhiteSpace(userName))
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                return false;
            }
            return true;
        }

        #region Old methods
        //public Task<UserDto> GetByIdAsync(int id)
        //{
        //    throw new System.NotImplementedException();
        //}

        //public Task<IReadOnlyList<UserDto>> GetAllAsync()
        //{
        //    throw new System.NotImplementedException();
        //}

        //public Task<IReadOnlyList<UserDto>> GetPagedReponseAsync(int pageNumber, int pageSize)
        //{
        //    throw new System.NotImplementedException();
        //}

        //public Task<UserDto> AddAsync(UserDto entity)
        //{
        //    throw new System.NotImplementedException();
        //}

        //public Task UpdateAsync(UserDto entity)
        //{
        //    throw new System.NotImplementedException();
        //}

        //public Task DeleteAsync(UserDto entity)
        //{
        //    throw new System.NotImplementedException();
        //}
        #endregion

        //public bool IsValidUser(string userName, string password)
        //{
        //    //_logger.LogInformation($"Validating user [{userName}]");
        //    if (string.IsNullOrWhiteSpace(userName))
        //    {
        //        return false;
        //    }

        //    if (string.IsNullOrWhiteSpace(password))
        //    {
        //        return false;
        //    }
        //    return true;
        //}

        //public List<RoleDto> GeRoleDto()
        //{
        //    throw new System.NotImplementedException();
        //}

        //public UserDto FindUserById(string userId)
        //{
        //    throw new System.NotImplementedException();
        //}

        //public List<UserDto> GetUsers()
        //{
        //    throw new System.NotImplementedException();
        //}

        //public UserDto AddUsers(UserDto UserDto)
        //{
        //    throw new System.NotImplementedException();
        //}

        //public void DeleteUsers(UserDto UserDto)
        //{
        //    throw new System.NotImplementedException();
        //}

        //public UserDto FindByNameAsync(string roleName)
        //{
        //    throw new System.NotImplementedException();
        //}

        //public int UpdateAsync(UserDto UserDto)
        //{
        //    throw new System.NotImplementedException();
        //}

        //public string GeneratePasswordResetTokenAsync(UserDto user)
        //{
        //    throw new System.NotImplementedException();
        //}

        //public UserDto FindByEmailAsync(string email)
        //{
        //    throw new System.NotImplementedException();
        //}

        //public IdentityResult ResetPasswordAsync(UserDto user, string token, string newPassword)
        //{
        //    throw new System.NotImplementedException();
        //}

        //public UserDto FindByUsername(string username)
        //{
        //    throw new System.NotImplementedException();
        //}

        //public List<string> GetRolesAsync(UserDto user)
        //{
        //    throw new System.NotImplementedException();
        //}
    }
}