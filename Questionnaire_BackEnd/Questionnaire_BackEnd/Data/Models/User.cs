using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Questionnaire_BackEnd.Data.Models
{
    [Table("Users")]
    public class User
    {
        [Key] public Guid Id { get; set; }
        [Required] public string Email { get; set; }
        [StringLength(255), Required] public string Username { get; set; }
        [Required] public string Password { get; set; }
        public Guid RoleId { get; set; }
        [ForeignKey("RoleId"), Required] public virtual Role Role { get; set; }
        //public virtual ICollection<Questionnaire> Questionnaires { get; set; }
    }
}