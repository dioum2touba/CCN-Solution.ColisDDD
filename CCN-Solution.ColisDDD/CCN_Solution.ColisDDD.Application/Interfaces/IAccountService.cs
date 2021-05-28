using System.Threading.Tasks;
using CCN_Solution.ColisDDD.Application.DTOs.Account;
using CCN_Solution.ColisDDD.Application.Wrappers;
using CCNSolution.ColisDDD.Application.DTOs.Account;
using CCNSolution.ColisDDD.Application.Wrappers;

namespace CCN_Solution.ColisDDD.Application.Interfaces
{
    public interface IAccountService
    {
        Task<Response<AuthenticationResponse>> AuthenticateAsync(AuthenticationRequest request, string ipAddress);
        Task<Response<string>> RegisterAsync(RegisterRequest request, string origin);
        Task<Response<string>> ConfirmEmailAsync(string userId, string code);
        Task ForgotPassword(ForgotPasswordRequest model, string origin);
        Task<Response<string>> ResetPassword(ResetPasswordRequest model);
    }
}
