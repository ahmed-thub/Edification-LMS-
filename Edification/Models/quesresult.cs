namespace Edification.Models
{
    public class quesresult
    {
        public IEnumerable<Quiz>? QuizNature { get; set; }
        public IEnumerable<QuestionQuiz>? QuizQuestions { get; set; }
        public Result? QuizPaperSubmission { get; set; }
    }
}
