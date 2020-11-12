using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Questionnaire_Backend.Data;
using Questionnaire_Backend.Data.Models;
using Questionnaire_Backend.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Questionnaire_Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QuestionController : ControllerBase
    {
        private readonly QuestionnaireDbContext db;

        public QuestionController(QuestionnaireDbContext db)
        {
            this.db = db;
        }

        // GET: /Question
        [HttpGet]
        [Produces(typeof(QuestionDTO))]
        public async Task<IActionResult> GetQuestion()
        {
            try
            {
                return Ok(await db.Question.ToListAsync());
            }
            catch (Exception error)
            {
                return StatusCode(500, error.Message);
            }
        }

        // GET: /Question/[Guid]
        [HttpGet("{id}")]
        [Produces(typeof(QuestionDTO))]
        public async Task<IActionResult> GetQuestion(Guid id)
        {
            try
            {
                var question = await db.Question.FirstOrDefaultAsync(x => x.Id == id);
                if (question == null) { return NotFound(); }
                return Ok(new QuestionDTO(question));
            }
            catch (Exception error)
            {
                return StatusCode(500, error.Message);
            }
        }

        // PUT: /Question/[Guid]
        [HttpPut("{id}")]
        [Produces(typeof(QuestionDTO))]
        public async Task<IActionResult> Put(Guid id, [FromBody] QuestionDTO data)
        {
            try
            {
                var question = await db.Question.FirstOrDefaultAsync(x => x.Id == id);

                if (question == null) { return NotFound(); }

                question.QuestionText = data.QuestionText;
                question.QuestionTypeId = data.QuestionTypeId;
                question.AvailableAnswers = data.AvailableAnswers;
                question.Responses = data.Responses;
                question.Picture = data.Picture;

                await db.SaveChangesAsync();

                return await GetQuestion(question.Id);
            }
            catch (Exception error)
            {
                return StatusCode(500, error.Message);
            }
        }

        [HttpPost]
        [Produces(typeof(QuestionDTO))]
        public async Task<IActionResult> Post([FromBody] QuestionDTO data)
        {
            try
            {
                var question = new Question()
                {
                    Id = Guid.NewGuid(),
                    AvailableAnswers = data.AvailableAnswers,
                    IsRequired = data.IsRequired,
                    Picture = data.Picture,
                    QuestionnaireId = data.QuestionnaireId,
                    QuestionText = data.QuestionText,
                    QuestionTypeId = data.QuestionTypeId
                };
                db.Question.Add(question);
                await db.SaveChangesAsync();
                return await GetQuestion(question.Id);
            }
            catch (Exception error)
            {
                return StatusCode(500, error.Message);
            }
        }

        [HttpDelete("{id}")]
        [Produces(typeof(QuestionDTO))]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var question = await db.Question.FirstOrDefaultAsync(x => x.Id == id);
                if (question == null) { return NotFound(); }
                db.Question.Remove(question);
                await db.SaveChangesAsync();
                return Ok(new QuestionDTO(question));
            }
            catch (Exception error)
            {
                return StatusCode(500, error.Message);
            }
        }
    }
}