using Questionnaire_Backend.Data.Models;
using System;

namespace Questionnaire_Backend.DTO
{
    public class QuestionDTO
    {
        public Guid Id { get; set; }
        public string QuestionText { get; set; }
        public byte[] Picture { get; set; }
        public bool IsRequired { get; set; }
        public Guid QuestionnaireId { get; set; }
        public int QuestionTypeId { get; set; }
        public string AvailableAnswers { get; set; }
        public string Responses { get; set; }

        public QuestionDTO()
        {
        }

        public QuestionDTO(Question question)
        {
            Id = question.Id;
            QuestionText = question.QuestionText;
            Picture = question.Picture;
            IsRequired = question.IsRequired;
            QuestionnaireId = question.QuestionnaireId;
            QuestionTypeId = question.QuestionTypeId;
            AvailableAnswers = question.AvailableAnswers;
            Responses = question.Responses;
        }
    }
}