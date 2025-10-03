using quizweb.ViewModels.Answer;

namespace quizweb.ViewModels.Question
{
    public class PlayQuestionViewModel
    {
        public int QuestionId { get; set; }
        public string QuestionText { get; set; } = null!;
        public List<PlayAnswerViewModel> Answers = [];
    }
}