using Vijuge.Common.Enums;

namespace Vijuge.Data.Models.DTOs
{
    public class QuestionDTO
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public QuestionType Type { get; set; }

        public AnswerDTO? Answer { get; set; }

        public int Points { get; set; }
    }
}
