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
    public class TypeDeColisService : ITypeDeColisService
    {
        public readonly ITypeDeColisRepository _typeDeColisRepository;
        private readonly IMapper _mapper;

        public TypeDeColisService(ITypeDeColisRepository typeDeColisRepository, IMapper mapper)
            => (_typeDeColisRepository, _mapper) = (typeDeColisRepository, mapper);

        public async Task<TypeDeColisDto> GetByIdAsync(int id)
            => _mapper.Map<TypeDeColisDto>(await _typeDeColisRepository.GetByIdAsync(id));

        public async Task<List<TypeDeColisDto>> GetAllAsync()
            => _mapper.Map<List<TypeDeColisDto>>(await _typeDeColisRepository.GetAllAsync());

        public Task<List<TypeDeColisDto>> GetPagedReponseAsync(int pageNumber, int pageSize)
        {
            throw new System.NotImplementedException();
        }

        public async Task<TypeDeColisDto> AddAsync(TypeDeColisDto entity)
            => _mapper.Map<TypeDeColisDto>(await _typeDeColisRepository.AddAsync(_mapper.Map<TypeDeColis>(entity)));

        public async Task UpdateAsync(TypeDeColisDto entity)
            => await _typeDeColisRepository.UpdateAsync(_mapper.Map<TypeDeColis>(entity));

        public async Task DeleteAsync(TypeDeColisDto entity)
            => await _typeDeColisRepository.DeleteAsync(_mapper.Map<TypeDeColis>(entity));

        public async Task<bool> IfExists(int id)
        {
            var typeDeColiss = await _typeDeColisRepository.GetAllAsync();
            return typeDeColiss.Any(a => a.Id == id);
        }

        public List<TypeDeColisDto> GetAllTypeDeColissIncRegions()
        {
            var typeDeColiss = _mapper.Map<List<TypeDeColisDto>>(_typeDeColisRepository.GetAllAsync());
            return typeDeColiss;
        }
    }
}