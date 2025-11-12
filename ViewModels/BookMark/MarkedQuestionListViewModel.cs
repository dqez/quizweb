namespace quizweb.ViewModels.BookMark
{
    public class MarkedQuestionListViewModel
    {
        public int QuestionId { get; set; }
        public DateTime MarkedTime { get; set; } = DateTime.Now;

    }
}
