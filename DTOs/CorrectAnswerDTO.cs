namespace quizweb.DTOs
{
    public class CorrectAnswerDTO
    {
        public int QuestionId { get; set; }
        public List<int> CorrectAnswerIds { get; set; } = [];
    }

}
