using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Questionnaire_Backend.Data.Models
{
    [Table("Roles")]
    public class Role
    {
        [Key] public int Id { get; set; }
        [MinLength(3), MaxLength(25), Required] public string RoleName { get; set; }

        public static Role[] Seed = new Role[]
{
         new Role() { Id = 1, RoleName = "Admin"},
         new Role() { Id = 2, RoleName = "User"},
         new Role() { Id = 3, RoleName = "Other" },
};
    }
}