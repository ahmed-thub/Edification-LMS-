using System;
using System.Collections.Generic;

namespace Edification.Models
{
    public partial class Course
    {
        public Course()
        {
            CoursesToFacuilities = new HashSet<CoursesToFacuility>();
            StudentEnrollCourses = new HashSet<StudentEnrollCourse>();
        }

        public int CoursesId { get; set; }
        public string? CoursesName { get; set; }
        public int? CoursesFees { get; set; }
        public decimal? CoursesRequiredPercentage { get; set; }
        public string? CourseAction { get; set; }

        public virtual ICollection<CoursesToFacuility> CoursesToFacuilities { get; set; }
        public virtual ICollection<StudentEnrollCourse> StudentEnrollCourses { get; set; }
    }
}
