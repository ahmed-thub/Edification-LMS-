namespace Edification.Models
{
    public class course_data
    {
        public StudentEnrollCourse datatable { get; set; }
        public IEnumerable<Course>? list { get; set; }
        public IEnumerable<UsersRegistration>? userlist { get; set; }
    }
}
