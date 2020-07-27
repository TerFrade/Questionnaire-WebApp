using Microsoft.EntityFrameworkCore;
using Questionnaire_BackEnd.Data.Models;

namespace Questionnaire_BackEnd.Data
{
    public class QuestionnaireContext : DbContext
    {
        public QuestionnaireContext(DbContextOptions<QuestionnaireContext> options) : base(options)
        {
        }

        public DbSet<Role> Role { get; set; }
        public DbSet<User> User { get; set; }
    }
}