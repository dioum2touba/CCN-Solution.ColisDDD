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
    [ApiExplorerSettings(GroupName = "Gestion des types de colis par région")]
    public class TypeDeColisController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public readonly ITypeDeColisService _typeDeColisService;

        public TypeDeColisController(ITypeDeColisService typeDeColisService)
            => _typeDeColisService = typeDeColisService;

        // GET: api/TypeDeColis
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TypeDeColisDto>>> GetTypeDeColis()
            => await _typeDeColisService.GetAllAsync();

        // GET: api/TypeDeColis/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TypeDeColisDto>> GetTypeDeColis(int id)
        {
            var typeDeColis = await _typeDeColisService.GetByIdAsync(id);
            if (typeDeColis == null)
                return NotFound();
            return typeDeColis;
        }

        // PUT: api/TypeDeColis/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTypeDeColis(int id, TypeDeColisDto typeDeColis)
        {
            if (id != typeDeColis.Id)
                return BadRequest();

            try
            {
                await _typeDeColisService.UpdateAsync(typeDeColis);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TypeDeColisExists(id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        // POST: api/TypeDeColis
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TypeDeColisDto>> PostTypeDeColis(TypeDeColisDto typeDeColis)
        {
            typeDeColis = await _typeDeColisService.AddAsync(typeDeColis);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTypeDeColis", new { id = typeDeColis.Id }, typeDeColis);
        }

        // DELETE: api/TypeDeColis/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TypeDeColisDto>> DeleteTypeDeColis(int id)
        {
            var typeDeColis = await _typeDeColisService.GetByIdAsync(id);
            if (typeDeColis == null)
            {
                return NotFound();
            }

            await _typeDeColisService.DeleteAsync(typeDeColis);
            return typeDeColis;
        }

        private bool TypeDeColisExists(int id)
            => _typeDeColisService.IfExists(id).Result;
    }
}
