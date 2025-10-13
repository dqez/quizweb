namespace quizweb.ViewModels.QuestionSet
{
    public class QuizResultViewModel
    {
        public int QSetId { get; set; }
        public string QSetName { get; set; } = null!;
        public int TotalQuestions { get; set; }
        public int CorrectAnswers { get; set; }
        public double ScorePercentage { get; set; }
        public List<QuestionResultViewModel> QuestionResults { get; set; } = [];
    }

    public class QuestionResultViewModel
    {
        public int QuestionId { get; set; }
        public string QuestionText { get; set; } = null!;
        public int UserSelecteAnswerId { get; set; }
        public int CorrectAnswerId { get; set; }
        public bool IsCorrect { get; set; }
        public string UserAnswerText { get; set; } = null!;
        public string CorrectAnswerText { get; set; } = null;

    }
}
