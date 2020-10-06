using System;
using Questionnaire_Backend.Data.Models;

namespace Questionnaire_Backend.DTO
{
    public class UserDTO
    {
        public Guid Id { get; set; } 
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }

        public UserDTO()
        {
        }

        public UserDTO(User user)
        {
            Id = user.Id;
            Email = user.Email;
            Username = user.Username;
            Password = user.Password;
            RoleId = user.RoleId;
        }
    }
}