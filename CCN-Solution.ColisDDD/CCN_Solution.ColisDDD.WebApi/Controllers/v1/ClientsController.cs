using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CCN_Solution.ColisDDD.Application.DTOs;
using CCN_Solution.ColisDDD.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CCN_Solution.ColisDDD.Domain.Entities;
using CCN_Solution.ColisDDD.Infrastructure.Persistence.Contexts;

namespace CCN_Solution.ColisDDD.WebApi.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "Gestion des clients")]
    public class ClientsController : BaseApiController
    {
        private readonly IClientService _clientService;

        public ClientsController(IClientService clientService)
            => (_clientService) = (clientService);

        // GET: api/Clients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClientDto>>> GetClient()
            => await _clientService.GetAllAsync();

        // GET: api/Clients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClientDto>> GetClient(int id)
        {
            var client = await _clientService.GetByIdAsync(id);

            if (client == null)
            {
                return NotFound();
            }

            return client;
        }

        // GET: api/Clients/5
        [HttpGet("ClientParTelephone/{telephone}")]
        public async Task<ActionResult<ClientDto>> GetClientParTelephone(int telephone)
        {
            var client = await _clientService.GetClientParTelephone(telephone);

            if (client == null)
            {
                return NotFound();
            }

            return client;
        }

        // PUT: api/Clients/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClient(int id, ClientDto client)
        {
            if (id != client.Id)
            {
                return BadRequest();
            }


            try
            {
                await _clientService.UpdateAsync(client);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Clients
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Client>> PostClient(ClientDto client)
        {
            await _clientService.AddAsync(client);

            return CreatedAtAction("GetClient", new { id = client.Id }, client);
        }

        // DELETE: api/Clients/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ClientDto>> DeleteClient(int id)
        {
            var client = await _clientService.GetByIdAsync(id);
            if (client == null)
            {
                return NotFound();
            }

            await _clientService.DeleteAsync(client);

            return client;
        }

        private bool ClientExists(int id)
            => _clientService.IfExists(id).Result;
    }
}
