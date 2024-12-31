using Edification.Data;
using Edification.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Edification.Controllers
{
    public class Student : Controller
    {
        private readonly EdificationContext database;
        private readonly IHttpContextAccessor context;
        public Student(ILogger<Student> _logger, EdificationContext database, IHttpContextAccessor context)
        {
            this.database = database;
            this.context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CourseLists()
        {
            var courselsit = database.Courses.ToList();
            return View(courselsit);
        }
        public IActionResult FacuilityLists()
        {
            var fucilitylit = database.Facuilities.ToList();
            return View(fucilitylit);
        }
        public IActionResult UserRoleList()
        {
            var rolelist = database.StudentEnrollCourses.Include(options => options.Courses).Include(options => options.Users).ToList();
            return View(rolelist);
        }
        public IActionResult Lecturess()
        {

            var lecture = database.Lectures.ToList();
            return View(lecture);
        }
        //[HttpGet]
        //public IActionResult Course()
        //{





        //    var courses = database.Courses.ToList();





        //    return View(courses);

        //}

        [HttpGet]
        public IActionResult JavascriptList()
        {
            course_data addjava = new course_data()
            {
                list = database.Courses.ToList(),
                userlist = database.UsersRegistrations.ToList(),
                datatable = new StudentEnrollCourse(),
            };
            return View(addjava);

        }
        [HttpPost]
        public IActionResult JavascriptList(course_data userdatainsert)
        {
            database.StudentEnrollCourses.Add(userdatainsert.datatable);
            database.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Python()
        {
            course_data addQuiz = new course_data()
            {
                list = database.Courses.ToList(),
                datatable = new StudentEnrollCourse(),



            };

            return View(addQuiz);
        }
        [HttpGet]
        public IActionResult Frankfurt()
        {
            course_data addQuiz = new course_data()
            {
                list = database.Courses.ToList(),
                datatable = new StudentEnrollCourse(),



            };

            return View(addQuiz);
        }
        [HttpGet]
        public IActionResult Net_Framework()
        {
            course_data addQuiz = new course_data()
            {
                list = database.Courses.ToList(),
                datatable = new StudentEnrollCourse(),



            };

            return View(addQuiz);
        }
        [HttpGet]
        public IActionResult C_Sharp()
        {
            course_data addQuiz = new course_data()
            {
                list = database.Courses.ToList(),
                datatable = new StudentEnrollCourse(),



            };

            return View(addQuiz);
        }
        public IActionResult About()
        {
            return View();
        }


    }
}
