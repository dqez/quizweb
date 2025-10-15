using System.ComponentModel.DataAnnotations;

namespace quizweb.ViewModels.QuestionSet
{
    public class SubmitQuizViewModel
    {
        [Required(ErrorMessage = "Question Set ID is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Invalid Question Set ID")]
        public int QSetId { get; set; }

        [Required(ErrorMessage = "User answers are required")]
        [MinLength(1, ErrorMessage = "At least one answer is required")]
        public List<UserAnswerViewModel> UserAnswers { get; set; } = [];
    }

    public class UserAnswerViewModel
    {
        [Required(ErrorMessage = "Question ID is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Invalid Question ID")]
        public int QuestionId { get; set; }

        [Required(ErrorMessage = "Answer selection is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Invalid Answer ID")]
        public int SelectedAnswerId { get; set; }
    }
}
