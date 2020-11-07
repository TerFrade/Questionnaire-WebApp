using Questionnaire_Backend.Data.Models;
using System;
using System.Linq;

namespace Questionnaire_Backend.DTO
{
    public class UserDTO
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public RoleDTO Role { get; set; }
        public QuestionnaireDTO[] Questionnaires { get; set; }

        public UserDTO()
        {
        }

        public UserDTO(User user)
        {
            Id = user.Id;
            Email = user.Email;
            Username = user.Username;
            Password = user.Password;
            if (user.Role != null)
                Role = new RoleDTO(user.Role);

            if (user.Questionnaires != null)
                Questionnaires = user.Questionnaires.Select(x => new QuestionnaireDTO(x)).ToArray();
        }
    }
}