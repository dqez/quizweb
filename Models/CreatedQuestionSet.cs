namespace quizweb.Models
{
    public class CreatedQuestionSet
    {
        public string UserName { get; set; } = null!;
        public int QSetId { get; set; }
        public DateTime CreatedTime { get; set; } = DateTime.Now;

        // Navigation properties
        public ApplicationUser User { get; set; } = null!;
        public QuestionSet QuestionSet { get; set; } = null!;
    }
}
