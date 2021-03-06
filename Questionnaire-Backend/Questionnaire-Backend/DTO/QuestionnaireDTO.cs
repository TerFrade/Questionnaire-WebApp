﻿using Questionnaire_Backend.Data.Models;
using System;
using System.Linq;

namespace Questionnaire_Backend.DTO
{
    public class QuestionnaireDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsPublic { get; set; }
        public string Link { get; set; }
        public Guid UserId { get; set; }
        public QuestionDTO[] Questions { get; set; }

        public QuestionnaireDTO()
        {
        }

        public QuestionnaireDTO(Questionnaire questionnaire)
        {
            Id = questionnaire.Id;
            Title = questionnaire.Title;
            Description = questionnaire.Description;
            IsPublic = questionnaire.IsPublic;
            Link = questionnaire.Link;
            UserId = questionnaire.UserId;
            if (questionnaire.Questions != null)
                Questions = questionnaire.Questions.Select(x => new QuestionDTO(x)).ToArray();
        }
    }
}