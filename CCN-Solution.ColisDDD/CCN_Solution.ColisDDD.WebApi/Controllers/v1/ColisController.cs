using System.Collections.Generic;
using System.Linq;
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
    [ApiExplorerSettings(GroupName = "Gestion des colis")]
    public class ColisController : BaseApiController
    {
        public readonly IColisService _colisService;

        public ColisController(IColisService ColisService)
            => _colisService = ColisService;

        // GET: api/Colis
        [HttpGet]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [SwaggerOperation(
            Summary = "Liste de toutes les Colis",
            Description = "Recupérer la liste des Colis"
        )]
        [SwaggerResponse(200, "Successfully found Colis", typeof(List<ColisDto>))]
        [SwaggerResponse(400, "Bad request, error", typeof(List<ColisDto>))]
        public async Task<ActionResult<IEnumerable<ColisDto>>> GetColis()
        {
            var colis = await _colisService.GetAllAsync();
            return colis.OrderByDescending(c => c.Id).ToList();
        }

        // GET: api/Colis/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ColisDto>> GetColis(int id)
        {
            var Colis = await _colisService.GetByIdAsync(id);
            if (Colis == null)
                return NotFound();
            return Colis;
        }

        // GET: api/Colis/5
        [HttpGet("ReceptionneUnColis/{id}")]
        public async Task<ActionResult<string>> GetReceptionneUnColis(int id)
            => Ok(await _colisService.GetReceptionneUnColis(id));

        // PUT: api/Colis/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutColis(int id, ColisDto Colis)
        {
            if (id != Colis.Id)
                return BadRequest();
            try
            {
                await _colisService.UpdateAsync(Colis);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ColisExists(id))
                    return NotFound();
                else
                    throw;
            }
            return NoContent();
        }

        // POST: api/Colis
        /// <summary>
        /// Save new Colis
        /// </summary>
        /// <param name="Colis"></param>
        /// <returns></returns>
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ColisDto>> PostColis(ColisDto Colis)
        {
            Colis = await _colisService.PostSaveColisDto(Colis);

            return CreatedAtAction("GetColis", new { id = Colis.Id }, Colis);
        }

        // DELETE: api/Colis/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ColisDto>> DeleteColis(int id)
        {
            var Colis = await _colisService.GetByIdAsync(id);
            if (Colis == null)
            {
                return NotFound();
            }

            await _colisService.DeleteAsync(Colis);

            return Colis;
        }

        private bool ColisExists(int id)
            => _colisService.IfExists(id).Result;
    }
}
