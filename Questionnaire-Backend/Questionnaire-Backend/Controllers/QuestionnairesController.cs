using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Questionnaire_Backend.Data;
using Questionnaire_Backend.Data.Models;
using Questionnaire_Backend.DTO;

namespace Questionnaire_Backend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class QuestionnairesController : ControllerBase
    {
        private readonly QuestionnaireDbContext db;

        public QuestionnairesController(QuestionnaireDbContext db)
        {
            this.db = db;
        }

        // GET: /Questionnaires
        [HttpGet]
        [Produces(typeof(QuestionnareDTO))]
        public async Task<IActionResult> GetQuestionnaire()
        {
            try
            {
                ICollection<Questionnaire> questionnaires = await db.Questionnaire.Include(x => x.User).ToArrayAsync();
                return Ok(questionnaires.Select(x => new QuestionnareDTO(x)));
            }
            catch (Exception error)
            {
                return StatusCode(500, error.Message);
            }
        }

        // GET: /Questionnaires/[Guid]
        [HttpGet("{id}")]
        [Produces(typeof(QuestionnareDTO))]
        public async Task<IActionResult> GetQuestionnaire(Guid id)
        {
            try
            {
                var questionnaire = await db.Questionnaire.Include(x => x.User).FirstOrDefaultAsync(x => x.Id == id);
                if (questionnaire == null) { return NotFound(); }
                return Ok(new QuestionnareDTO(questionnaire));
            }
            catch (Exception error)
            {
                return StatusCode(500, error.Message);
            }
        }

        // PUT: /Questionnaires/[Guid]
        [HttpPut("{id}")]
        [Produces(typeof(QuestionnareDTO))]
        public async Task<IActionResult> Put(Guid id, [FromBody] QuestionnareDTO data)
        {
            try
            {
                var questionnaire = await db.Questionnaire.FirstOrDefaultAsync(x => x.Id == id);

                if (questionnaire == null) { return NotFound(); }

                questionnaire.Title = data.Title;
                questionnaire.Description = data.Description;
                questionnaire.IsPublic = data.IsPublic;

                await db.SaveChangesAsync();

                return await GetQuestionnaire(questionnaire.Id);
            }
            catch (Exception error)
            {
                return StatusCode(500, error.Message);
            }
        }

        [HttpPost]
        [Produces(typeof(QuestionnareDTO))]
        public async Task<IActionResult> Post([FromBody] QuestionnareDTO data)
        {
            try
            {
                if (await db.Questionnaire.FirstOrDefaultAsync(x => x.Id == data.Id) != null) { return StatusCode(409, "Questionnaire already exists!"); }
                var questionnaire = new Questionnaire()
                {
                    Id = Guid.NewGuid(),
                    Title = data.Title,
                    Description = data.Description,
                    IsPublic = data.IsPublic,
                    Link = data.Link,
                    UserId = data.UserId,
                    User = await db.User.FirstAsync(x => x.Id == data.UserId)
                };
                db.Questionnaire.Add(questionnaire);
                await db.SaveChangesAsync();
                return await GetQuestionnaire(questionnaire.Id);
            }
            catch (Exception error)
            {
                return StatusCode(500, error.Message);
            }
        }

        [HttpDelete("{id}")]
        [Produces(typeof(QuestionnareDTO))]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var questionnaire = await db.Questionnaire.FirstOrDefaultAsync(x => x.Id == id);
                if (questionnaire == null) { return NotFound(); }
                db.Questionnaire.Remove(questionnaire);
                await db.SaveChangesAsync();
                return Ok(new QuestionnareDTO(questionnaire));
            }
            catch (Exception error)
            {
                return StatusCode(500, error.Message);
            }
        }
    }
}