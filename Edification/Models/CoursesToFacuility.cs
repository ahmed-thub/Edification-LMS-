using System;
using System.Collections.Generic;

namespace Edification.Models
{
    public partial class CoursesToFacuility
    {
        public int CoursesFacuilityId { get; set; }
        public int? CoursesId { get; set; }
        public int? FacuilityId { get; set; }

        public virtual Course? Courses { get; set; }
        public virtual Facuility? Facuility { get; set; }
    }
}
