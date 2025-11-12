using System.ComponentModel.DataAnnotations;

namespace quizweb.ViewModels.ProgressQuestionSet
{
    public class ProgressQuestionSetViewModel
    {
        [Required]
        public int QSetId { get; set; }

        [Required]
        public int QuestionCount { get; set; }

        [Required]
        public int QuestionLastId { get; set; }
    }
}
