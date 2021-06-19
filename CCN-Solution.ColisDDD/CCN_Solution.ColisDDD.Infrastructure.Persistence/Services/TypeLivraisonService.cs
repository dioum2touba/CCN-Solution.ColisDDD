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
    public class TypeLivraisonService : ITypeLivraisonService 
    {
        public readonly ITypeLivraisonRepository _typeLivraisonRepository;
        private readonly IMapper _mapper;

        public TypeLivraisonService(ITypeLivraisonRepository typeLivraisonRepository, IMapper mapper)
            => (_typeLivraisonRepository, _mapper) = (typeLivraisonRepository, mapper);

        public async Task<TypeLivraisonDto> GetByIdAsync(int id)
            => _mapper.Map<TypeLivraisonDto>(await _typeLivraisonRepository.GetByIdAsync(id));

        public async Task<List<TypeLivraisonDto>> GetAllAsync()
            => _mapper.Map<List<TypeLivraisonDto>>(await _typeLivraisonRepository.GetAllAsync());

        public Task<List<TypeLivraisonDto>> GetPagedReponseAsync(int pageNumber, int pageSize)
        {
            throw new System.NotImplementedException();
        }

        public async Task<TypeLivraisonDto> AddAsync(TypeLivraisonDto entity)
            => _mapper.Map<TypeLivraisonDto>(await _typeLivraisonRepository.AddAsync(_mapper.Map<TypeLivraison>(entity)));

        public async Task UpdateAsync(TypeLivraisonDto entity)
            => await _typeLivraisonRepository.UpdateAsync(_mapper.Map<TypeLivraison>(entity));

        public async Task DeleteAsync(TypeLivraisonDto entity)
            => await _typeLivraisonRepository.DeleteAsync(_mapper.Map<TypeLivraison>(entity));

        public async Task<bool> IfExists(int id)
        {
            var TypeLivraisons = await _typeLivraisonRepository.GetAllAsync();
            return TypeLivraisons.Any(a => a.Id == id);
        }
    }
}