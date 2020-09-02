using Questionnaire_Backend.Data.Models;

namespace Questionnaire_Backend.DTO
{
    public class RoleDTO
    {
        public string RoleName { get; set; }

        public RoleDTO()
        {
        }

        public RoleDTO(Role role)
        {
            RoleName = role.RoleName;
        }
    }
}