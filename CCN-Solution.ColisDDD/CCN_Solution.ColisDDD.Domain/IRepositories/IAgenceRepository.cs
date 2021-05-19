using System.Collections.Generic;
using CCN_Solution.ColisDDD.Domain.Entities;

namespace CCN_Solution.ColisDDD.Domain.IRepositories
{
    public interface IAgenceRepository : IRepositoryAsync<Agence>
    {
        List<Agence> GetAllAgencesIncRegions();
    }
}