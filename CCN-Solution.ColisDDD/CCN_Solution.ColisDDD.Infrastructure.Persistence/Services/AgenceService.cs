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
    public class AgenceService : IAgenceService
    {
        public readonly IAgenceRepository _agenceRepository;
        private readonly IMapper _mapper;

        public AgenceService(IAgenceRepository agenceRepository, IMapper mapper)
            => (_agenceRepository, _mapper) = (agenceRepository, mapper);

        public async Task<AgenceDto> GetByIdAsync(int id)
            => _mapper.Map<AgenceDto>(await _agenceRepository.GetByIdAsync(id));

        public async Task<List<AgenceDto>> GetAllAsync()
        {
            var agences = _mapper.Map<List<AgenceDto>>(_agenceRepository.GetAllAgencesIncRegions());
            agences.ForEach(elt =>
            {
                if (elt.TypeAgence == null)
                    elt.NomAgence = elt.NomAgence + " - DEM DIKK";
                else
                    elt.NomAgence = elt.NomAgence + " - Partenaire";
            });
            return agences; 
        }

        public Task<List<AgenceDto>> GetPagedReponseAsync(int pageNumber, int pageSize)
        {
            throw new System.NotImplementedException();
        }

        public async Task<AgenceDto> AddAsync(AgenceDto entity)
            => _mapper.Map<AgenceDto>(await _agenceRepository.AddAsync(_mapper.Map<Agence>(entity)));

        public async Task UpdateAsync(AgenceDto entity)
            => await _agenceRepository.UpdateAsync(_mapper.Map<Agence>(entity));

        public async Task DeleteAsync(AgenceDto entity)
            => await _agenceRepository.DeleteAsync(_mapper.Map<Agence>(entity));

        public async Task<bool> IfExists(int id)
        {
            var agences = await _agenceRepository.GetAllAsync();
            return agences.Any(a => a.Id == id);
        }

        public List<AgenceDto> GetAllAgencesIncRegions()
        {
            var agences = _mapper.Map<List<AgenceDto>>(_agenceRepository.GetAllAgencesIncRegions());
            return agences;
        }
    }
}