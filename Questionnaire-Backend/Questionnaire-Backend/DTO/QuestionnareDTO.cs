using Questionnaire_Backend.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Questionnaire_Backend.DTO
{
    public class QuestionnareDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsPublic { get; set; }
        public string Link { get; set; }
        public Guid UserId { get; set; }

        public QuestionnareDTO()
        {
        }

        public QuestionnareDTO(Questionnaire questionnaire)
        {
            Id = questionnaire.Id;
            Title = questionnaire.Title;
            Description = questionnaire.Description;
            IsPublic = questionnaire.IsPublic;
            Link = questionnaire.Link;
            UserId = questionnaire.UserId;
        }
    }
}