using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace quizweb.Models
{
    public class QuestionSet
    {
        [Key]
        public int QSetId { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Question set name cannot be longer than 100 characters.")]
        public string QSetName { get; set; } = null!;

        [Required]
        [StringLength(500, ErrorMessage = "Description cannot be longer than 500 characters.")]
        public string Description { get; set; } = null!;

        [Required]
        public string AuthorName { get; set; } = null!;

        //[Required]
        public int LevelId { get; set; }

        //[Required]
        public int CategoryId { get; set; }

        public DateTime CreatedTime { get; set; } = DateTime.Now;

        // Navigation properties
        [ForeignKey(nameof(AuthorName))]
        public ApplicationUser Author { get; set; } = null!;

        //Khong can [ForeiKey..] vì EF auto 
        public Level Level { get; set; } = null!;

        public Category Category { get; set; } = null!;

    }
}
