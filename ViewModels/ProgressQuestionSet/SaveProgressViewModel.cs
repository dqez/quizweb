using quizweb.ViewModels.User;
using System.ComponentModel.DataAnnotations;

namespace quizweb.ViewModels.ProgressQuestionSet
{
    public class SaveProgressViewModel : ProgressQuestionSetViewModel
    {
        public List<UserAnswerViewModel> UserAnswers { get; set; } = [];
    }
}
