using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Questionnaire_BackEnd.Data;
using Questionnaire_BackEnd.Data.Models;
using Questionnaire_BackEnd.DTO;

namespace Questionnaire_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly QuestionnaireContext dbContext;

        public RolesController(QuestionnaireContext context) {this.dbContext = context;}

        [HttpGet]
        public ActionResult<IEnumerable<RoleDTO>> GetRole()
        {
            return dbContext.Role.ToArray().Select(x => new RoleDTO(x)).ToArray();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Role>> GetRole(Guid id)
        {
            var item = await dbContext.Role.FirstOrDefaultAsync(x => x.Id == id);
            if (item == null) { return NotFound(); }
            return Ok(item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutRole(Guid id, RoleDTO role)
        {
            var item = await dbContext.Role.FirstOrDefaultAsync(x => x.Id == id);
            if (item == null) { return NotFound(); }
            item.RoleName = role.RoleName;
            await dbContext.SaveChangesAsync();
            return Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<Role>> PostRole(Role role)
        {
            dbContext.Role.Add(role);
            await dbContext.SaveChangesAsync();

            return CreatedAtAction("GetRole", new { id = role.Id }, role);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Role>> DeleteRole(Guid id)
        {
            var role = await dbContext.Role.FindAsync(id);
            if (role == null)
            {
                return NotFound();
            }

            dbContext.Role.Remove(role);
            await dbContext.SaveChangesAsync();

            return role;
        }

        private bool RoleExists(Guid id)
        {
            return dbContext.Role.Any(e => e.Id == id);
        }
    }
}
