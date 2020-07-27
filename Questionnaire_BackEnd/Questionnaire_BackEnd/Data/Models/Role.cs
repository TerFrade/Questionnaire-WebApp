using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Questionnaire_BackEnd.Data.Models
{
    [Table("Roles")]
    public class Role
    {
        [Key] public Guid Id { get; set; }
        [StringLength(255), Required] public string RoleName { get; set; }
        public ICollection<User> Users { get; set; }
    }
}