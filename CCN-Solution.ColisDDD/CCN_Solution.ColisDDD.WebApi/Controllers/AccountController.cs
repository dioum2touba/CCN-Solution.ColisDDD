using CCN_Solution.ColisDDD.Application.DTOs.Account;
using CCN_Solution.ColisDDD.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CCNSolution.ColisDDD.Application.DTOs.Account;
using Swashbuckle.AspNetCore.Annotations;

namespace CCN_Solution.ColisDDD.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "Gestion des comptes, authentification et autorisation")]
    //[ApiVersion("1.0")]
    //[ApiExplorerSettings(IgnoreApi = false, GroupName = "v1")]
    //[Route("api/[controller]", Name = "Gestion des comptes, authentification et autorisation", Order = 1)]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
            => _accountService = accountService;

        [HttpPost("authenticate")]
        [SwaggerOperation(
            Summary = "Authentification de l'utilisateur depuis Web/Mobile",
            Description = "Pour pouvoir utiliser notre service web, l'utilisateur doit s'authentifier pour pouvoir envoyer des requêtes"
        )]
        public async Task<IActionResult> AuthenticateAsync(AuthenticationRequest request)
            => Ok(await _accountService.AuthenticateAsync(request, GenerateIPAddress()));
         
        [HttpPost("register")]
        [SwaggerOperation(
            Summary = "Inscription de l'utilisateur depuis Web/Mobile",
            Description = "Pour pouvoir utiliser notre service web, l'utilisateur doit d'abord s'inscrire puis s'authentifier pour pouvoir envoyer des requêtes"
        )]
        public async Task<IActionResult> RegisterAsync(RegisterRequest request)
        {
            var origin = Request.Headers["origin"];
            return Ok(await _accountService.RegisterAsync(request, origin));
        }

        [HttpGet("confirm-email")]
        [SwaggerOperation(
            Summary = "Vérification d'une adresse e-mail utilisateur",
            Description = "Donner la possibilité aux usagers de vérifier les adresses e-mails"
        )]
        public async Task<IActionResult> ConfirmEmailAsync([FromQuery] string userId, [FromQuery] string code)
        {
            var origin = Request.Headers["origin"];
            return Ok(await _accountService.ConfirmEmailAsync(userId, code));
        }

        [HttpPost("forgot-password")]
        [SwaggerOperation(
            Summary = "Demande de réinitialisation d'un mot de passe d'utilisateur",
            Description = "Cette méthode permet à un utilisateur de demander une réinitialisation du mot de passe "
        )]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordRequest model)
        {
            await _accountService.ForgotPassword(model, Request.Headers["origin"]);
            return Ok();
        }

        [HttpPost("reset-password")]
        [SwaggerOperation(
            Summary = "Réinitialiser un mot de passe d'utilisateur",
            Description = "Cette méthode permet de réinitialiser un mot de passe utilisateur"
        )]
        public async Task<IActionResult> ResetPassword(ResetPasswordRequest model)
        {

            return Ok(await _accountService.ResetPassword(model));
        }

        private string GenerateIPAddress()
        {
            if (Request.Headers.ContainsKey("X-Forwarded-For"))
                return Request.Headers["X-Forwarded-For"];
            else
                return HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
        }
    }
}