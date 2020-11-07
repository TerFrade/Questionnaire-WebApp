using Questionnaire_Backend.Data.Models;

namespace Questionnaire_Backend.DTO
{
    public class QuestionTypeDTO
    {
        public int Id { get; set; }
        public string TypeName { get; set; }

        public QuestionTypeDTO()
        {
        }

        public QuestionTypeDTO(QuestionType questionType)
        {
            Id = questionType.Id;
            TypeName = questionType.TypeName;
        }
    }
}