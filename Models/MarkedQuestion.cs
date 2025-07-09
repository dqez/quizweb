namespace quizweb.Models
{
    public class MarkedQuestion
    {
        public string UserName { get; set; } = null!;
        public int QuestionId { get; set; }
        public DateTime MarkedTime { get; set; } = DateTime.Now;
    }
}
