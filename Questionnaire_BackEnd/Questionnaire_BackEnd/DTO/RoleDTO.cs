using Questionnaire_BackEnd.Data.Models;
using System;
using System.Linq;

namespace Questionnaire_BackEnd.DTO
{
    public class RoleDTO
    {
        public Guid Id { get; set; }
        public string RoleName { get; set; }
        public UserDTO[] Users { get; set; }

        public RoleDTO() {}

        public RoleDTO(Role data)
        {
            Id = data.Id;
            RoleName = data.RoleName;
            Users = data.Users?.Select(x => new UserDTO(x)).ToArray();
        }
    }
}