namespace quizweb.ViewModels.QuestionSet
{
    public class SubmitQuizViewModel
    {
        public int QSetId { get; set; }
        public List<UserAnswerViewModel> UserAnswers { get; set; } = [];
    }

    public class UserAnswerViewModel
    {
        public int QuestionId { get; set; }
        public int SelectedAnswerId { get; set; }
    }
}
