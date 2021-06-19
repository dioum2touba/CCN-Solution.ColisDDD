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
    [ApiExplorerSettings(GroupName = "Gestion des utilisateurs")]
    public class UsersController : ControllerBase
    {
        public readonly IUserService _userService;

        public UsersController(IUserService userService)
            => _userService = userService;

        // GET: api/Users
        [HttpGet]
        public ActionResult<IEnumerable<UserDto>> GetUsers()
            => _userService.GetApplicationUsersWithRoles();

        // GET: api/Users/5
        [HttpGet("{id}")]
        public ActionResult<UserDto> GetUsers(string id)
        {
            var Users = _userService.FindUserById(id);
            if (Users == null)
                return NotFound();
            return Users;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsers(string id, UserDto Users)
        {
            if (id != Users.Id)
                return BadRequest();

            try
            {
                _userService.UpdateAsync(Users);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsersExists(id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        // POST: api/Users
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<UserDto>> PostUsers(UserDto Users)
        {
            Users = await _userService.AddUsersAsync(Users);

            return CreatedAtAction("GetUsers", new { id = Users.Id }, Users);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public ActionResult<UserDto> DeleteUsers(string id)
        {
            var Users = _userService.FindUserById(id);
            if (Users == null)
            {
                return NotFound();
            }

            _userService.DeleteUsers(Users);
            return Users;
        }

        private bool UsersExists(string id)
            => _userService.IfExists(id);
    }
}
