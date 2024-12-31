using Edification.Data;
using Edification.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;
using Microsoft.CodeAnalysis.VisualBasic;
using Microsoft.EntityFrameworkCore;

namespace Edification.Controllers
{
    public class Admin : Controller
    {
        private readonly EdificationContext database;
        private readonly IHttpContextAccessor context;
        public Admin(ILogger<Admin> _logger, EdificationContext database, IHttpContextAccessor context)
        {
            this.database = database;
            this.context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult adduser()
        {
            return View();
        }
        [HttpPost]
        public IActionResult adduser(UsersRegistration addusers)
        {
            database.UsersRegistrations.Add(addusers);
            database.SaveChanges();
            return RedirectToAction("userlist");
        }
        [HttpGet]
        public IActionResult userlist()
        {
            var userdata = database.UsersRegistrations.ToList();

            return View(userdata);
        }
        [HttpGet]
        public IActionResult update(int id)
        {

            var userData = database.UsersRegistrations.Find(id);
            return View(userData);
        }
        [HttpPost]
        public IActionResult update(UsersRegistration updateuser, int id)
        {
            var oldfechupdate = database.UsersRegistrations.Find(id);
            oldfechupdate.UsersName = updateuser.UsersName;
            oldfechupdate.UsersEmail = updateuser.UsersEmail;
            oldfechupdate.UsersPassword = updateuser.UsersPassword;
            oldfechupdate.UsersRole = updateuser.UsersRole;
            database.SaveChanges();
            return RedirectToAction("userlist");
        }
        public IActionResult delete(int id)
        {
            var userid = id;
            var Records = database.UsersRegistrations.FirstOrDefault(user => user.UsersId == userid);
            database.UsersRegistrations.Remove(Records);
            database.SaveChanges();
            return RedirectToAction("userlist");
        }
        [HttpGet]
        public IActionResult addcourse()
        {
            return View();
        }
        [HttpPost]
        public IActionResult addcourse(Course addcourse)
        {
            database.Courses.Add(addcourse);
            database.SaveChanges();
            return RedirectToAction("courselist");
        }

        public IActionResult courselist()
        {
            var coursedata = database.Courses.ToList();
            return View(coursedata);
        }
        [HttpGet]
        public IActionResult courseupdate(int id)
        {
            var CourseData = database.Courses.Find(id);
            return View(CourseData);

        }
        [HttpPost]
        public IActionResult courseupdate(Course updatecourse, int id)
        {
            var fachupdate = database.Courses.Find(id);
            fachupdate.CoursesName = updatecourse.CoursesName;
            fachupdate.CoursesFees = updatecourse.CoursesFees;
            fachupdate.CoursesToFacuilities = updatecourse.CoursesToFacuilities;
            database.SaveChanges();

            return RedirectToAction("courselist");
        }

        public IActionResult coursedelete(int id)
        {
            var courseid = id;
            var Records = database.Courses.FirstOrDefault(user => user.CoursesId == courseid);
            database.Courses.Remove(Records);
            database.SaveChanges();
            return RedirectToAction("courselist");
        }
        [HttpGet]
        public IActionResult addfaclity()
        {
            return View();
        }
        [HttpPost]
        public IActionResult addfaclity(Facuility addfacuility)
        {
            database.Facuilities.Add(addfacuility);
            database.SaveChanges();
            return RedirectToAction("faclitylist");
        }
        public IActionResult faclitylist()
        {
            var facuilitydata = database.Facuilities.ToList();
            return View(facuilitydata);
        }

        [HttpGet]
        public IActionResult updatefacuility(int id)
        {
            var facalityData = database.Facuilities.Find(id);
            return View(facalityData);


        }
        [HttpPost]
        public IActionResult updatefacuility(Facuility updatefacuility, int id)
        {

            var fachupdate = database.Facuilities.Find(id);
            fachupdate.FacuilityName = updatefacuility.FacuilityName;
            fachupdate.FacuilityEmail = updatefacuility.FacuilityEmail;
            database.SaveChanges();

            return RedirectToAction("faclitylist");

        }

        public IActionResult deletefacliuity(int id)
        {
            var facuilityid = id;
            var Records = database.Facuilities.FirstOrDefault(user => user.FacuilityId == facuilityid);
            database.Facuilities.Remove(Records);
            database.SaveChanges();
            return RedirectToAction("addfaclity");
        }
        [HttpGet]
        public IActionResult addquiz()
        {
            querytable addQuiz = new querytable()
            {
                QuizNature = database.Quizzes.ToList(),
                QuizQuestions = new QuestionQuiz(),

            };

            return View(addQuiz);
        }

        [HttpPost]
        public IActionResult addquiz(querytable addquiz)
        {
            database.QuestionQuizzes.Add(addquiz.QuizQuestions);
            database.SaveChanges();
            return RedirectToAction("quizlist");
        }

        [HttpGet]
        public IActionResult quizlist()
        {
            //quesresult quizresult = new quesresult()
            //{
            //    QuizNature = database.Quizzes.ToList(),
            //    QuizQuestions = database.QuestionQuizzes.ToList(),
            //    QuizPaperSubmission = new Result(),
            //};



            var quizresult = database.QuestionQuizzes.Include(options => options.Quiz).ToList();

            return View(quizresult);
        }

        [HttpPost]
        public IActionResult quizlist(QuestionQuiz addquiz)
        {
            database.QuestionQuizzes.Add(addquiz);
            database.SaveChanges();
            return View();
        }


        [HttpGet]
        public IActionResult quizupdate(int id)
        {
            querytable quizupdatee = new querytable()
            {
                QuizNature = database.Quizzes.ToList(),
                QuizQuestions = database.QuestionQuizzes.Find(id)
            };

            return View(quizupdatee);
        }

        [HttpPost]
        public IActionResult quizupdate(querytable updatequiz, int id)
        {

            var oldQuizUpdate = database.QuestionQuizzes.Find(id);
            oldQuizUpdate.QuestionsTotalNum = updatequiz.QuizQuestions.QuestionsTotalNum;
            oldQuizUpdate.QuizId = updatequiz.QuizQuestions.QuizId;
            oldQuizUpdate.Question = updatequiz.QuizQuestions.Question;
            oldQuizUpdate.RightAnswer = updatequiz.QuizQuestions.RightAnswer;
            oldQuizUpdate.OptionOne = updatequiz.QuizQuestions.OptionOne;
            oldQuizUpdate.OptionTwo = updatequiz.QuizQuestions.OptionTwo;
            oldQuizUpdate.OptionThree = updatequiz.QuizQuestions.OptionThree;

            database.SaveChanges();


            return RedirectToAction("quizlist");


        }

        public IActionResult quizdelete(int id)
        {
            var Quizid = id;
            var Records = database.QuestionQuizzes.FirstOrDefault(user => user.QuestionQuizId == Quizid);
            database.QuestionQuizzes.Remove(Records);
            database.SaveChanges();
            return RedirectToAction("quizlist");
        }
        [HttpGet]
        public IActionResult addcoursequiz()
        {
            return View();
        }

        [HttpPost]
        public IActionResult addcoursequiz(Quiz addcoursequiz)
        {
            database.Quizzes.Add(addcoursequiz);
            database.SaveChanges();
            return View();
        }


        public IActionResult coursequizlist()
        {
            var coursequizdata = database.Quizzes.ToList();


            return View(coursequizdata);
        }


        [HttpGet]

        public IActionResult updatequizcourse(int id )
        {
            var coursequizdata = database.Quizzes.Find(id);
            return View(coursequizdata);
        }
        [HttpPost]
        public IActionResult updatequizcourse(Quiz updatequizcourse,int id)
        {

            var quizcourseupdate = database.Quizzes.Find(id);
            quizcourseupdate.QuizName = updatequizcourse.QuizNature;
            quizcourseupdate.QuizNature = updatequizcourse.QuizNature;
            database.SaveChanges();

            return RedirectToAction("coursequizlist");
        }


        public IActionResult deletequizcourse( int id)
        {
            var coursequizid = id;
            var Records = database.Quizzes.FirstOrDefault(user => user.QuizId == coursequizid);
            database.Quizzes.Remove(Records);
            database.SaveChanges();
            return RedirectToAction("addcoursequiz");
        }
       public IActionResult logout()
        {
            context.HttpContext.Session.SetString("sessroll", "visitor");
            return RedirectToAction("Index", "Home");
        }
    }
}


