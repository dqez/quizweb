namespace quizweb.ViewModels
{
    public class QuestionViewModel
    {
        public int QuestionId { get; set; }
        public string QuestionText { get; set; } = null!;
        public List<AnswerViewModel> Answers = [];
    }
}