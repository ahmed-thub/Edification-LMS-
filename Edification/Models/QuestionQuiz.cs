using System;
using System.Collections.Generic;

namespace Edification.Models
{
    public partial class QuestionQuiz
    {
        public int QuestionQuizId { get; set; }
        public int? QuestionsTotalNum { get; set; }
        public int? QuizId { get; set; }
        public string? RightAnswer { get; set; }
        public string? OptionOne { get; set; }
        public string? OptionTwo { get; set; }
        public string? OptionThree { get; set; }
        public string? Question { get; set; }

        public virtual Quiz? Quiz { get; set; }
    }
}
