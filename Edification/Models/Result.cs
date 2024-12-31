using System;
using System.Collections.Generic;

namespace Edification.Models
{
    public partial class Result
    {
        public int? UsersId { get; set; }
        public int? QuizId { get; set; }
        public string? ResultsGrade { get; set; }
        public int? ResultsPercentage { get; set; }
        public int? ResultsObtainNum { get; set; }

        public virtual Quiz? Quiz { get; set; }
        public virtual UsersRegistration? Users { get; set; }
    }
}
