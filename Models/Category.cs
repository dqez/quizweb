using System.ComponentModel.DataAnnotations;

namespace quizweb.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Category name cannot be longer than 50 characters.")]
        public string CategoryName { get; set; } = null!;

        public ICollection<QuestionSet> QuestionSets { get; set; } = new List<QuestionSet>();
    }
}
