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
    public class ClientService : IClientService
    {
        public readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;

        public ClientService(IClientRepository clientRepository, IMapper mapper)
            => (_clientRepository, _mapper) = (clientRepository, mapper);

        public async Task<ClientDto> GetByIdAsync(int id)
            => _mapper.Map<ClientDto>(await _clientRepository.GetByIdAsync(id));

        public async Task<List<ClientDto>> GetAllAsync()
            => _mapper.Map<List<ClientDto>>(await _clientRepository.GetAllAsync());

        public Task<List<ClientDto>> GetPagedReponseAsync(int pageNumber, int pageSize)
        {
            throw new System.NotImplementedException();
        }

        public async Task<ClientDto> AddAsync(ClientDto entity)
            => _mapper.Map<ClientDto>(await _clientRepository.AddAsync(_mapper.Map<Client>(entity)));

        public async Task UpdateAsync(ClientDto entity)
            => await _clientRepository.UpdateAsync(_mapper.Map<Client>(entity));

        public async Task DeleteAsync(ClientDto entity)
            => await _clientRepository.DeleteAsync(_mapper.Map<Client>(entity));

        public async Task<bool> IfExists(int id)
        {
            var clients = await _clientRepository.GetAllAsync();
            return clients.Any(a => a.Id == id);
        }

        public async Task<ClientDto> GetClientParTelephone(int telephone)
            => _mapper.Map<ClientDto>(await _clientRepository.GetClientParTelephone(telephone));
    }
}