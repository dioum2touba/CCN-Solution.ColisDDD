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
    public class MoyenTransportService : IMoyenTransportService 
    {
        public readonly IMoyenTransportRepository _moyenTransportRepository;
        private readonly IMapper _mapper;

        public MoyenTransportService(IMoyenTransportRepository moyenTransportRepository, IMapper mapper)
            => (_moyenTransportRepository, _mapper) = (moyenTransportRepository, mapper);

        public async Task<MoyenTransportDto> GetByIdAsync(int id)
            => _mapper.Map<MoyenTransportDto>(await _moyenTransportRepository.GetByIdAsync(id));

        public async Task<List<MoyenTransportDto>> GetAllAsync()
            => _mapper.Map<List<MoyenTransportDto>>(await _moyenTransportRepository.GetAllAsync());

        public Task<List<MoyenTransportDto>> GetPagedReponseAsync(int pageNumber, int pageSize)
        {
            throw new System.NotImplementedException();
        }

        public async Task<MoyenTransportDto> AddAsync(MoyenTransportDto entity)
            => _mapper.Map<MoyenTransportDto>(await _moyenTransportRepository.AddAsync(_mapper.Map<MoyenTransport>(entity)));

        public async Task UpdateAsync(MoyenTransportDto entity)
            => await _moyenTransportRepository.UpdateAsync(_mapper.Map<MoyenTransport>(entity));

        public async Task DeleteAsync(MoyenTransportDto entity)
            => await _moyenTransportRepository.DeleteAsync(_mapper.Map<MoyenTransport>(entity));

        public async Task<bool> IfExists(int id)
        {
            var MoyenTransports = await _moyenTransportRepository.GetAllAsync();
            return MoyenTransports.Any(a => a.Id == id);
        }
    }
}