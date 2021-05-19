using System.Collections.Generic;
using System.Threading.Tasks;
using CCN_Solution.ColisDDD.Application.DTOs;
using CCN_Solution.ColisDDD.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;

namespace CCN_Solution.ColisDDD.WebApi.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "Gestion des agences")]
    public class AgencesController : BaseApiController
    {
        public readonly IAgenceService _agenceService;

        public AgencesController(IAgenceService agenceService)
            => _agenceService = agenceService;

        // GET: api/Agences
        [HttpGet]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [SwaggerOperation(
            Summary = "Liste de toutes les agences",
            Description = "Recupérer la liste des agences"
        )]
        [SwaggerResponse(200, "Successfully found agences", typeof(List<AgenceDto>))]
        [SwaggerResponse(400, "Bad request, error", typeof(List<AgenceDto>))]
        public ActionResult<IEnumerable<AgenceDto>> GetAgence()
            => _agenceService.GetAllAgencesIncRegions();

        // GET: api/Agences/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AgenceDto>> GetAgence(int id)
        {
            var agence = await _agenceService.GetByIdAsync(id);
            if (agence == null)
                return NotFound();
            return agence;
        }

        // PUT: api/Agences/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAgence(int id, AgenceDto agence)
        {
            if (id != agence.Id)
                return BadRequest();
            try
            {
                await _agenceService.UpdateAsync(agence);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AgenceExists(id))
                    return NotFound();
                else
                    throw;
            }
            return NoContent();
        }

        // POST: api/Agences
        /// <summary>
        /// Save new agence
        /// </summary>
        /// <param name="agence"></param>
        /// <returns></returns>
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<AgenceDto>> PostAgence(AgenceDto agence)
        {
            agence = await _agenceService.AddAsync(agence);

            return CreatedAtAction("GetAgence", new { id = agence.Id }, agence);
        }

        // DELETE: api/Agences/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AgenceDto>> DeleteAgence(int id)
        {
            var agence = await _agenceService.GetByIdAsync(id);
            if (agence == null)
            {
                return NotFound();
            }

            await _agenceService.DeleteAsync(agence);

            return agence;
        }

        private bool AgenceExists(int id)
            => _agenceService.IfExists(id).Result;
    }
}
