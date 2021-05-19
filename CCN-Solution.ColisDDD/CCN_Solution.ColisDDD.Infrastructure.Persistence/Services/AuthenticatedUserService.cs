using System.Security.Claims;
using CCN_Solution.ColisDDD.Application.Interfaces;
using Microsoft.AspNetCore.Http;

namespace CCN_Solution.ColisDDD.Infrastructure.Persistence.Services
{
    public class AuthenticatedUserService : IAuthenticatedUserService
    {
        public AuthenticatedUserService(IHttpContextAccessor httpContextAccessor)
        {
            UserId = httpContextAccessor.HttpContext?.User?.FindFirstValue("uid");
        }

        public string UserId { get; }
    }
}