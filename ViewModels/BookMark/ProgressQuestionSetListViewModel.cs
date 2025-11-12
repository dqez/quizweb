using quizweb.ViewModels.ProgressQuestionSet;

namespace quizweb.ViewModels.BookMark
{
    public class ProgressQuestionSetListViewModel : ProgressQuestionSetViewModel
    {
        public string AuthorName { get; set; } = null!;
        public int TotalQuestions { get; set; }
        public DateTime LastUpdated { get; set; }

    }
}
