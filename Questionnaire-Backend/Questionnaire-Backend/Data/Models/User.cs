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
        public int RoleId { get; set; }
        [Required, ForeignKey("RoleId")] public Role Role { get; set; }

        public static User[] Seed = new User[]
        {
            new User() {Id=Guid.NewGuid(), Email="TerenceFrade@gmail.com", Username="zENJA", Password="asdasd1", RoleId=1}
        };
    }
}