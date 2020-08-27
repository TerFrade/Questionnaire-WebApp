using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Questionnaire_Backend.Data;
using Questionnaire_Backend.DTO;

namespace Questionnaire_Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RolesController : ControllerBase
    {
        private readonly QuestionnaireDbContext db;

        public RolesController(QuestionnaireDbContext db) { this.db = db; }

        // GET: /Roles
        [HttpGet]
        [Produces(typeof(RoleDTO))]
        public async Task<IActionResult> GetRole()
        {
            try
            {
                return Ok(await db.Role.ToListAsync());
            }
            catch (Exception error)
            {
                return StatusCode(500, error.Message);
            }
        }

        // GET: /Roles/1
        [HttpGet("{id}")]
        [Produces(typeof(RoleDTO))]
        public async Task<IActionResult> GetRole(int id)
        {
            try
            {
                var role = await db.Role.FirstOrDefaultAsync(x => x.Id == id);
                if (role == null) { return NotFound(); }
                return Ok(new RoleDTO(role));
            }
            catch (Exception error)
            {
                return StatusCode(500, error.Message);
            }
        }

        // PUT: /Roles/5
        [HttpPut("{id}")]
        [Produces(typeof(RoleDTO))]
        public async Task<IActionResult> Put(int id, [FromBody] RoleDTO data)
        {
            try
            {
                var role = await db.Role.FirstOrDefaultAsync(x => x.Id == id);
                if (role == null) { return NotFound(); }

                return await GetRole(role.Id);
            }
            catch (Exception error)
            {
                return StatusCode(500, error.Message);
            }
        }
    }
}