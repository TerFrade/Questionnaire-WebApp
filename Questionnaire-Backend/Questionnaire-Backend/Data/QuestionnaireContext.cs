using Microsoft.EntityFrameworkCore;
using Questionnaire_Backend.Data.Models;

namespace Questionnaire_Backend.Data
{
    public class QuestionnaireContext : DbContext
    {
        public QuestionnaireContext(DbContextOptions<QuestionnaireContext> options) : base(options)
        {
        }

        public DbSet<Questionnaire_Backend.Data.Models.Role> Role { get; set; }
        public DbSet<Questionnaire_Backend.Data.Models.User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(Questionnaire_Backend.Data.Models.Role.Seed);
        }
    }
}