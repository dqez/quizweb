using System.ComponentModel.DataAnnotations;

namespace quizweb.Models
{
    public class Question
    {
        [Key]
        public int QuestionId { get; set; }

        [Required]
        [StringLength(500, ErrorMessage = "Question text cannot be longer than 500 characters.")]
        public string QuestionText { get; set; } = null!;

        [Required]
        public int QSetId { get; set; }

        //navigation property
        public QuestionSet QuestionSet { get; set; } = null!;
        public ICollection<Answer> Answers { get; set; } = new List<Answer>();
    }
}
