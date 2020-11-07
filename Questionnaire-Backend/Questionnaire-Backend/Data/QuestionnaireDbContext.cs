using Microsoft.EntityFrameworkCore;
using Questionnaire_Backend.Data.Models;

namespace Questionnaire_Backend.Data
{
    public class QuestionnaireDbContext : DbContext
    {
        public QuestionnaireDbContext(DbContextOptions<QuestionnaireDbContext> options) : base(options)
        {
        }

        public DbSet<Questionnaire_Backend.Data.Models.Role> Role { get; set; }
        public DbSet<Questionnaire_Backend.Data.Models.User> User { get; set; }
        public DbSet<Questionnaire_Backend.Data.Models.Questionnaire> Questionnaire { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(Questionnaire_Backend.Data.Models.Role.Seed);
            modelBuilder.Entity<QuestionType>().HasData(Questionnaire_Backend.Data.Models.QuestionType.Seed);
        }
    }
}