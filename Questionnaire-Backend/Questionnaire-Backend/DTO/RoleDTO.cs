using Questionnaire_Backend.Data.Models;

namespace Questionnaire_Backend.DTO
{
    public class RoleDTO
    {
        public int Id { get; set; }
        public string RoleName { get; set; }

        public RoleDTO()
        {
        }

        public RoleDTO(Role role)
        {
            Id = role.Id;
            RoleName = role.RoleName;
        }
    }
}