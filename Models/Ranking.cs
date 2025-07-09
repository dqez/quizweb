using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace quizweb.Models
{
    public class Ranking
    {
        [Key]
        [ForeignKey(nameof(User))]
        public string UserName { get; set; } = null!;

        public int TotalScore { get; set; }

        public ApplicationUser User { get; set; } = null!; // Navigation property to ApplicationUser
    }
}
