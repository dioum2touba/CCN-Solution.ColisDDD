using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CCN_Solution.ColisDDD.Application.DTOs;
using CCN_Solution.ColisDDD.Application.Interfaces;
using CCN_Solution.ColisDDD.Domain.Entities;
using CCN_Solution.ColisDDD.Domain.IRepositories;

namespace CCN_Solution.ColisDDD.Infrastructure.Persistence.Services
{
    public class RoleService : IRoleService
    {
        public readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;

        public RoleService(IRoleRepository roleRepository, IMapper mapper)
            => (_roleRepository, _mapper) = (roleRepository, mapper);

        public async Task<RoleDto> GetByIdAsync(string id)
            => _mapper.Map<RoleDto>(await _roleRepository.GetByIdAsync(id));

        public async Task<RoleDto> GetByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<RoleDto>> GetAllAsync()
            => _mapper.Map<List<RoleDto>>(await _roleRepository.GetAllAsync());

        public Task<List<RoleDto>> GetPagedReponseAsync(int pageNumber, int pageSize)
        {
            throw new System.NotImplementedException();
        }

        public async Task<RoleDto> AddAsync(RoleDto entity)
            => _mapper.Map<RoleDto>(await _roleRepository.AddAsync(_mapper.Map<Role>(entity)));

        public async Task UpdateAsync(RoleDto entity)
            => await _roleRepository.UpdateAsync(_mapper.Map<Role>(entity));

        public async Task DeleteAsync(RoleDto entity)
            => await _roleRepository.DeleteAsync(_mapper.Map<Role>(entity));

        public async Task<bool> IfExists(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> IfExists(string id)
        {
            var Roles = await _roleRepository.GetAllAsync();
            return Roles.Any(a => a.Id == id);
        }
    }
}