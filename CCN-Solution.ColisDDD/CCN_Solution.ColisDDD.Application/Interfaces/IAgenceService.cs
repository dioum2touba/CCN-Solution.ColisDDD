using System.Collections.Generic;
using CCN_Solution.ColisDDD.Application.DTOs;

namespace CCN_Solution.ColisDDD.Application.Interfaces
{
    public interface IAgenceService : IGenericRepositoryAsync<AgenceDto>
    {

        List<AgenceDto> GetAllAgencesIncRegions();
    }
}