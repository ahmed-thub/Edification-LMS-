using Edification.Data;
using Edification.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;

namespace Edification.Controllers
{
    public class Facitly : Controller
    {
        private readonly EdificationContext database;
        private readonly IHttpContextAccessor context;
        public Facitly(ILogger<Facitly> _logger, EdificationContext database, IHttpContextAccessor context)
        {
            this.database = database;
            this.context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult userlist()
        {
            var facil = database.CoursesToFacuilities.Include(options => options.Courses).ToList();
            var abc = database.CoursesToFacuilities.Include(Option => Option.Facuility).ToList();
            //return View(facil);
            return View(abc);

        }
        public IActionResult enrolllist()
        {

            facilty_details enrolllist = new facilty_details()
            {
                abc = database.UsersRegistrations.ToList(),
                roles = database.StudentEnrollCourses.ToList(),
                couresss = database.Courses.ToList(),
                faci = database.Facuilities.ToList()


            };

            return View(enrolllist);
        }
        public IActionResult enrdelete(int id)
        {
            var userid = id;
            var Records = database.StudentEnrollCourses.FirstOrDefault(user => user.StdCourseid == userid);
            database.StudentEnrollCourses.Remove(Records);
            database.SaveChanges();
            return RedirectToAction("enrolllist");
        }
    }
}
