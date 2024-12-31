using System;
using System.Collections.Generic;

namespace Edification.Models
{
    public partial class StudentEnrollCourse
    {
        public int StdCourseid { get; set; }
        public int? UsersId { get; set; }
        public int? CoursesId { get; set; }
        public DateTime? CoursesJoining { get; set; }
        public int? FacilityId { get; set; }
        public string? CourseName { get; set; }
        public string? CourseEmail { get; set; }
        public string? CoursePassword { get; set; }

        public virtual Course? Courses { get; set; }
        public virtual UsersRegistration? Users { get; set; }
    }
}
