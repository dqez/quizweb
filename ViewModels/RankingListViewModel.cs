using System.ComponentModel.DataAnnotations;

namespace quizweb.ViewModels
{
    public class RankingListViewModel
    {
        [Display(Name = "Username")]
        public string Username { get; set; } = null!;
        [Display(Name = "Total Score")]
        public int TotalScore { get; set; }
    }
}
