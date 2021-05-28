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
    public class LivraisonService : ILivraisonService
    {
        public readonly ILivraisonRepository _livraisonRepository;
        private readonly IMapper _mapper;

        public LivraisonService(ILivraisonRepository livraisonRepository, IMapper mapper)
            => (_livraisonRepository, _mapper) = (livraisonRepository, mapper);

        public async Task<LivraisonDto> GetByIdAsync(int id)
            => _mapper.Map<LivraisonDto>(await _livraisonRepository.GetByIdAsync(id));

        public async Task<List<LivraisonDto>> GetAllAsync()
            => _mapper.Map<List<LivraisonDto>>(await _livraisonRepository.GetLivraisonsAllAsyncWithInc());

        public Task<List<LivraisonDto>> GetPagedReponseAsync(int pageNumber, int pageSize)
        {
            throw new System.NotImplementedException();
        }

        public async Task<LivraisonDto> AddAsync(LivraisonDto entity)
            => _mapper.Map<LivraisonDto>(await _livraisonRepository.AddAsync(_mapper.Map<Livraison>(entity)));

        public async Task UpdateAsync(LivraisonDto entity)
            => await _livraisonRepository.UpdateAsync(_mapper.Map<Livraison>(entity));

        public async Task DeleteAsync(LivraisonDto entity)
            => await _livraisonRepository.DeleteAsync(_mapper.Map<Livraison>(entity));

        public async Task<bool> IfExists(int id)
        {
            var livraison = await _livraisonRepository.GetAllAsync();
            return livraison.Any(a => a.Id == id);
        }

        public List<LivraisonDto> GetAllLivraisonsIncRegions()
        {
            var livraison = _mapper.Map<List<LivraisonDto>>(_livraisonRepository.GetAllAsync());
            return livraison;
        }
    }
}