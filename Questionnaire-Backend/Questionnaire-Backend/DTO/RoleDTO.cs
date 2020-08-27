using Questionnaire_Backend.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Questionnaire_Backend.DTO
{
    public class RoleDTO
    {
        public string RoleName { get; set; }

        public RoleDTO() { }

        public RoleDTO(Role role)
        {
            RoleName = role.RoleName;
        }
    }
}
