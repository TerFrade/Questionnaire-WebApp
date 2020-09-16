using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Questionnaire_Backend.Data;
using Questionnaire_Backend.Data.Models;
using Questionnaire_Backend.DTO;


namespace Questionnaire_Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly QuestionnaireDbContext db;

        public UserController(QuestionnaireDbContext db)
        {
            this.db = db;
        }

        // GET: /Users
        [HttpGet]
        [Produces(typeof(UserDTO))]
        public async Task<IActionResult> GetUser()
        {
            try
            {
                ICollection<User> users = await db.User.Include(x => x.Role).ToArrayAsync();
                return Ok(users.Select(x => new UserDTO(x)));
            }
            catch (Exception error)
            {
                return StatusCode(500, error.Message);
            }
        }

        // GET: /Users/[Guid]
        [HttpGet("{id}")]
        [Produces(typeof(UserDTO))]
        public async Task<IActionResult> GetUser(Guid id)
        {
            try
            {
                var user = await db.User.Include(x => x.Role).FirstOrDefaultAsync(x => x.Id == id);
                if (user == null) { return NotFound(); }
                return Ok(new UserDTO(user));
            }
            catch (Exception error)
            {
                return StatusCode(500, error.Message);
            }
        }

        // PUT: /Users/[Guid]
        [HttpPut("{id}")]
        [Produces(typeof(UserDTO))]
        public async Task<IActionResult> Put(Guid id, [FromBody] UserDTO data)
        {
            try
            {
                var user = await db.User.FirstOrDefaultAsync(x => x.Id == id);
                if (user == null) { return NotFound(); }

                return await GetUser(data.Id);
            }
            catch (Exception error)
            {
                return StatusCode(500, error.Message);
            }
        }

        [HttpPost]
        [Produces(typeof(UserDTO))]
        public async Task<IActionResult> Post([FromBody] UserDTO data)
        {
            try
            {
                if (await db.User.FirstOrDefaultAsync(x => x.Email == data.Email) != null) { return StatusCode(409, "Email already exists!"); }
                var user = new User() { 
                    Id = Guid.NewGuid(), 
                    Email = data.Email,  
                    Username = data.Username, 
                    Password = data.Password, 
                    RoleId = data.Role.Id 
                };
                db.User.Add(user);
                await db.SaveChangesAsync();
                return await GetUser(user.Id);
            }
            catch (Exception error)
            {
                return StatusCode(500, error.Message);
            }
        }

        [HttpDelete("{id}")]
        [Produces(typeof(UserDTO))]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var user = await db.User.FirstOrDefaultAsync(x => x.Id == id);
                if (user == null) { return NotFound(); }
                db.User.Remove(user);
                await db.SaveChangesAsync();
                return Ok(new UserDTO(user));
            }
            catch (Exception error)
            {
                return StatusCode(500, error.Message);
            }
        }
    }
}