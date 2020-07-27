using Questionnaire_BackEnd.Data.Models;
using System;

namespace Questionnaire_BackEnd.DTO
{
    public class UserDTO
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Guid RoleId { get; set; }

        public UserDTO() {}

        public UserDTO(User data)
        {
            Id = data.Id;
            Email = data.Email;
            Username = data.Username;
            Password = data.Password;
            RoleId = data.RoleId;
        }
    }
}