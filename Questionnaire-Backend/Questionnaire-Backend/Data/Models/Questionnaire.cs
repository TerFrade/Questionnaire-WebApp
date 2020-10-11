using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Questionnaire_Backend.Data.Models
{
    [Table("Questionnaires")]
    public class Questionnaire
    {
        [Key] public Guid Id { get; set; }
        [MinLength(15), MaxLength(255), Required] public string Title { get; set; }
        [MinLength(15), MaxLength(255), Required] public string Description { get; set; }
        [Required] public bool IsPublic { get; set; }
        public string Link { get; set; }
        public Guid UserId { get; set; }
        [ForeignKey("UserId"), Required] public virtual User User { get; set; }
    }
}