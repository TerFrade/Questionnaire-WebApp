using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Questionnaire_Backend.Data.Models
{
    public class QuestionType
    {
        [Key] public int Id { get; set; }
        [StringLength(255), Required] public string TypeName { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
    }
}