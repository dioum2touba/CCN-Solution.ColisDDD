using System.Threading.Tasks;
using CCN_Solution.ColisDDD.Application.DTOs;
using CCN_Solution.ColisDDD.Application.Wrappers;

namespace CCN_Solution.ColisDDD.Application.Interfaces
{
    public interface IColisService : IGenericRepositoryAsync<ColisDto>
    {
        Task<ColisDto> PostSaveColisDto(ColisDto colis);
        Task<Response<ColisDto>> GetReceptionneUnColis(int Id);

    }
}