using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Questionnaire_Backend.Data.Models
{
    public class Question
    {
        [Key] public Guid Id { get; set; }
        public string QuestionText { get; set; }
        public byte[] Picture { get; set; }
        public bool IsRequired { get; set; }
        public Guid QuestionnaireId { get; set; }
        [ForeignKey("QuestionnaireId"), Required] public virtual Questionnaire Questionnaire { get; set; }
        public int QuestionTypeId { get; set; }
        [ForeignKey("QuestionTypeId"), Required] public virtual QuestionType QuestionType { get; set; }
        public string AvailableAnswers { get; set; }
        public string Responses { get; set; }
    }
}