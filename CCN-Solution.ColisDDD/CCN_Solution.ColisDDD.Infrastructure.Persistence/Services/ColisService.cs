﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CCN_Solution.ColisDDD.Application.DTOs;
using CCN_Solution.ColisDDD.Application.Interfaces;
using CCN_Solution.ColisDDD.Application.Wrappers;
using CCN_Solution.ColisDDD.Domain.Entities;
using CCN_Solution.ColisDDD.Domain.IRepositories;

namespace CCN_Solution.ColisDDD.Infrastructure.Persistence.Services
{
    public class ColisService : IColisService
    {
        public readonly IColisRepository _colisRepository;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public ColisService(IColisRepository colisRepository, IMapper mapper, IUserService userService)
            => (_colisRepository, _mapper, _userService) = (colisRepository, mapper, userService);

        public async Task<ColisDto> GetByIdAsync(int id)
            => _mapper.Map<ColisDto>(await _colisRepository.GetByIdAsyncWithInc(id));

        public async Task<List<ColisDto>> GetAllAsync()
            => _mapper.Map<List<ColisDto>>(await _colisRepository.GetColisAllAsyncWithInc());

        public Task<List<ColisDto>> GetPagedReponseAsync(int pageNumber, int pageSize)
        {
            throw new System.NotImplementedException();
        }

        public async Task<ColisDto> AddAsync(ColisDto entity)
        {
            var colis = _mapper.Map<Colis>(entity);
            //colis.DateEnvoie = DateTime.Parse(entity.DateEnvoie);
            return _mapper.Map<ColisDto>(await _colisRepository.AddAsync(colis));
        }

        public async Task UpdateAsync(ColisDto entity)
            => await _colisRepository.UpdateAsync(_mapper.Map<Colis>(entity));

        public async Task DeleteAsync(ColisDto entity)
            => await _colisRepository.DeleteAsync(_mapper.Map<Colis>(entity));

        public async Task<bool> IfExists(int id)
        {
            var colis = await _colisRepository.GetAllAsync();
            return colis.Any(a => a.Id == id);
        }

        public async Task<ColisDto> PostSaveColisDto(ColisDto colis)
        {
            var user = _userService.FindUserById(colis.CreatedBy);
            colis.RegionDepartId = user.RegionId;
            colis.AgenceDepartId = user.AgenceId;
            colis.CreatedBy = user.Id;
            colis.Created = DateTime.Now;
            try
            {
                return await AddAsync(colis);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
                return colis;
            }
        }

        public async Task<Response<ColisDto>> GetReceptionneUnColis(int Id)
        {
            var result = await _colisRepository.GetReceptionneUnColis(Id);
            return result.ReceptionAgence ? new Response<ColisDto> { Data = _mapper.Map<ColisDto>(result), Message = "Colis réceptionné avec succès", Succeeded = true } 
                                    : new Response<ColisDto> { Data = _mapper.Map<ColisDto>(result), Message = "Echec de la réception du colis" };
        }

        public List<ColisDto> GetAllColissIncRegions()
        {
            var colis = _mapper.Map<List<ColisDto>>(_colisRepository.GetAllAsync());
            return colis;
        }
    }
}