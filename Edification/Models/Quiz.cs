using System;
using System.Collections.Generic;

namespace Edification.Models
{
    public partial class Quiz
    {
        public Quiz()
        {
            QuestionQuizzes = new HashSet<QuestionQuiz>();
        }

        public int QuizId { get; set; }
        public string? QuizName { get; set; }
        public string? QuizNature { get; set; }

        public virtual ICollection<QuestionQuiz> QuestionQuizzes { get; set; }
    }
}
