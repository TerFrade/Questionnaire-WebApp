using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Questionnaire_Backend.Data.Models
{
    [Table("Users")]
    public class User
    {
        [Key] public Guid Id { get; set; }
        [Required] public string Email { get; set; }
        [MinLength(3), MaxLength(25), Required] public string Username { get; set; }
        [Required] public string Password { get; set; }
        [Required] public Role Role { get; set; }
    }
}