using quizweb.ViewModels.ProgressQuestionSet;

namespace quizweb.ViewModels.BookMark
{
    public class ProgressQuestionSetListViewModel : ProgressQuestionSetViewModel
    {
        public string QSetName { get; set; } = null!;
        public int TotalQuestions { get; set; }
        public string AuthorName { get; set; } = null!;
        public DateTime LastUpdated { get; set; }

    }
}
