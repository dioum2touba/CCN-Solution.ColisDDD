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
    [ApiExplorerSettings(GroupName = "Gestion des types d'agences")]
    public class TypeAgencesController : BaseApiController
    {
        private readonly ITypeAgenceService _typeAgenceService;

        public TypeAgencesController(ITypeAgenceService typeAgenceService)
            => (_typeAgenceService) = (typeAgenceService);

        // GET: api/TypeAgences
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TypeAgenceDto>>> GetTypeAgence()
            => await _typeAgenceService.GetAllAsync();

        // GET: api/TypeAgences/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TypeAgenceDto>> GetTypeAgence(int id)
        {
            var TypeAgence = await _typeAgenceService.GetByIdAsync(id);

            if (TypeAgence == null)
            {
                return NotFound();
            }

            return TypeAgence;
        }

        // PUT: api/TypeAgences/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTypeAgence(int id, TypeAgenceDto TypeAgence)
        {
            if (id != TypeAgence.Id)
            {
                return BadRequest();
            }

            try
            {
                await _typeAgenceService.UpdateAsync(TypeAgence);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TypeAgenceExists(id))
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

        // POST: api/TypeAgences
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TypeAgenceDto>> PostTypeAgence(TypeAgenceDto TypeAgence)
        {
            try
            {
                await _typeAgenceService.AddAsync(TypeAgence);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return CreatedAtAction("GetTypeAgence", new { id = TypeAgence.Id }, TypeAgence);
        }

        // DELETE: api/TypeAgences/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TypeAgenceDto>> DeleteTypeAgence(int id)
        {
            var TypeAgence = await _typeAgenceService.GetByIdAsync(id);
            if (TypeAgence == null)
            {
                return NotFound();
            }

            await _typeAgenceService.DeleteAsync(TypeAgence);

            return TypeAgence;
        }

        private bool TypeAgenceExists(int id)
            => _typeAgenceService.IfExists(id).Result;
    }
}
