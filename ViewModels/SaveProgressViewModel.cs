using System.ComponentModel.DataAnnotations;

namespace quizweb.ViewModels
{
    public class SaveProgressViewModel : ProgressQuestionSetViewModel
    {
        public List<UserAnswerViewModel> UserAnswers { get; set; } = [];
    }
}
