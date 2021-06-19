using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CCN_Solution.ColisDDD.Application.DTOs;
using CCN_Solution.ColisDDD.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CCN_Solution.ColisDDD.WebApi.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "Gestion des moyens de transport")]
    public class MoyenTransportsController : BaseApiController
    {
        private readonly IMoyenTransportService _moyenTransportService;

        public MoyenTransportsController(IMoyenTransportService moyenTransportService)
            => (_moyenTransportService) = (moyenTransportService);

        // GET: api/MoyenTransports
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MoyenTransportDto>>> GetMoyenTransport()
            => await _moyenTransportService.GetAllAsync();

        // GET: api/MoyenTransports/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MoyenTransportDto>> GetMoyenTransport(int id)
        {
            var MoyenTransport = await _moyenTransportService.GetByIdAsync(id);

            if (MoyenTransport == null)
            {
                return NotFound();
            }

            return MoyenTransport;
        }

        // PUT: api/MoyenTransports/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMoyenTransport(int id, MoyenTransportDto MoyenTransport)
        {
            if (id != MoyenTransport.Id)
            {
                return BadRequest();
            }

            try
            {
                await _moyenTransportService.UpdateAsync(MoyenTransport);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MoyenTransportExists(id))
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

        // POST: api/MoyenTransports
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<MoyenTransportDto>> PostMoyenTransport(MoyenTransportDto MoyenTransport)
        {
            try
            {
                await _moyenTransportService.AddAsync(MoyenTransport);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return CreatedAtAction("GetMoyenTransport", new { id = MoyenTransport.Id }, MoyenTransport);
        }

        // DELETE: api/MoyenTransports/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MoyenTransportDto>> DeleteMoyenTransport(int id)
        {
            var MoyenTransport = await _moyenTransportService.GetByIdAsync(id);
            if (MoyenTransport == null)
            {
                return NotFound();
            }

            await _moyenTransportService.DeleteAsync(MoyenTransport);

            return MoyenTransport;
        }

        private bool MoyenTransportExists(int id)
            => _moyenTransportService.IfExists(id).Result;
    }
}
