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
    public class TypeAgenceService : ITypeAgenceService 
    {
        public readonly ITypeAgenceRepository _typeAgenceRepository;
        private readonly IMapper _mapper;

        public TypeAgenceService(ITypeAgenceRepository typeAgenceRepository, IMapper mapper)
            => (_typeAgenceRepository, _mapper) = (typeAgenceRepository, mapper);

        public async Task<TypeAgenceDto> GetByIdAsync(int id)
            => _mapper.Map<TypeAgenceDto>(await _typeAgenceRepository.GetByIdAsync(id));

        public async Task<List<TypeAgenceDto>> GetAllAsync()
            => _mapper.Map<List<TypeAgenceDto>>(await _typeAgenceRepository.GetAllAsync());

        public Task<List<TypeAgenceDto>> GetPagedReponseAsync(int pageNumber, int pageSize)
        {
            throw new System.NotImplementedException();
        }

        public async Task<TypeAgenceDto> AddAsync(TypeAgenceDto entity)
            => _mapper.Map<TypeAgenceDto>(await _typeAgenceRepository.AddAsync(_mapper.Map<TypeAgence>(entity)));

        public async Task UpdateAsync(TypeAgenceDto entity)
            => await _typeAgenceRepository.UpdateAsync(_mapper.Map<TypeAgence>(entity));

        public async Task DeleteAsync(TypeAgenceDto entity)
            => await _typeAgenceRepository.DeleteAsync(_mapper.Map<TypeAgence>(entity));

        public async Task<bool> IfExists(int id)
        {
            var TypeAgences = await _typeAgenceRepository.GetAllAsync();
            return TypeAgences.Any(a => a.Id == id);
        }
    }
}