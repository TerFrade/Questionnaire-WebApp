using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Questionnaire_Backend.Data.Models
{
    public class QuestionType
    {
        [Key] public int Id { get; set; }
        [StringLength(255), Required] public string TypeName { get; set; }
        public virtual ICollection<Question> Questions { get; set; }

        public static QuestionType[] Seed = new QuestionType[]
        {
            new QuestionType() { Id = 1, TypeName = "Mutliple Choice"},
            new QuestionType() { Id = 2, TypeName = "Dropdown"},
            new QuestionType() { Id = 3, TypeName = "Short Input" },
            new QuestionType() { Id = 4, TypeName = "Long Input" },
        };
    }
}