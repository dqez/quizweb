using quizweb.Models;

namespace quizweb.ViewModels
{
    public class QuestionSetPlayViewModel
    {
        public int QSetId { get; set; }

        public string QSetName { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string AuthorName { get; set; } = null!;

        public string LevelName { get; set; } = null!;

        public string CategoryName { get; set; } = null!;

        public List<QuestionViewModel> Questions { get; set; } = [];
    }
}
