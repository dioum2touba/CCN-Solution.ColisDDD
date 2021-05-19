using System.Threading.Tasks;
using CCNSolution.ColisDDD.Application.DTOs.Email;

namespace CCN_Solution.ColisDDD.Application.Interfaces
{
    public interface IEmailService
    {
        Task SendAsync(EmailRequest request);
    }
}
