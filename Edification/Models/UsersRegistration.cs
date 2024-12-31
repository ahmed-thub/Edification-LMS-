using System;
using System.Collections.Generic;

namespace Edification.Models
{
    public partial class UsersRegistration
    {
        public UsersRegistration()
        {
            StudentEnrollCourses = new HashSet<StudentEnrollCourse>();
        }

        public int UsersId { get; set; }
        public string? UsersName { get; set; }
        public string? UsersEmail { get; set; }
        public string? UsersPassword { get; set; }
        public string? UsersRole { get; set; }

        public virtual ICollection<StudentEnrollCourse> StudentEnrollCourses { get; set; }
    }
}
