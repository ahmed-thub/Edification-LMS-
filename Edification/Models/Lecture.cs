using System;
using System.Collections.Generic;

namespace Edification.Models
{
    public partial class Lecture
    {
        public int LectureId { get; set; }
        public string? LectureName { get; set; }
        public string? LectureLink { get; set; }
        public int? QuizNature { get; set; }
    }
}
