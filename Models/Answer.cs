using System.ComponentModel.DataAnnotations;

namespace quizweb.Models
{
    public class Answer
    {
        [Key]
        public int AnswerId { get; set; }

        [Required]
        public int QuestionId { get; set; }
        
        [Required]
        [StringLength(500, ErrorMessage = "Answer text cannot be longer than 500 characters.")]
        public string AnswerText { get; set; } = null!;

        public bool IsCorrect { get; set; }

        // Navigation property
        public Question Question { get; set; } = null!;

    }
}
