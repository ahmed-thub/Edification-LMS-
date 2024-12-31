using Edification.Data;
using Edification.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Edification.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly EdificationContext database;
        private readonly IHttpContextAccessor context;
        public HomeController(ILogger<HomeController> logger, EdificationContext database, IHttpContextAccessor context)
        {

            

      context.HttpContext.Session.SetString("sessroll", "visitor");

            _logger = logger;
            this.database = database;
            this.context = context;
        }

        public IActionResult Index()
        {
           return View();
        }
        [HttpGet]
        public IActionResult Singup()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Singup(UsersRegistration insertuser)
        {

            database.UsersRegistrations.Add(insertuser);
            database.SaveChanges();
            return RedirectToAction("Login");
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
            public IActionResult Login(UsersRegistration log)
        {
            var records = database.UsersRegistrations.FirstOrDefault(option => option.UsersEmail == log.UsersEmail && option.UsersPassword == log.UsersPassword);
            var name = records.UsersName;
            var email = records.UsersEmail;
            var roll = records.UsersRole;
            var password = records.UsersPassword;
         

            context.HttpContext.Session.SetString("sessname", name);
            context.HttpContext.Session.SetString("sessemail", email);
            context.HttpContext.Session.SetString("sessroll", roll);
            context.HttpContext.Session.SetString("sesspassword", password);


            if (records != null)
            {
                if (records.UsersRole == "Admin")
                {
                    return RedirectToAction("Index", "Admin");
                }
                else if (records.UsersRole == "Student")
                {
                    return RedirectToAction("Index", "Student");
                }
                else if (records.UsersRole == "Facitly")
                {
                    return RedirectToAction("Index", "Facitly");
                }

            }
            else
            {

            }
            return View();







            //if (records != null)
            //{
            //    if (records.UsersRole == "Admin")
            //    {
            //        return RedirectToAction("Index", "Admin");
            //    }
            //    else if (records.UsersRole == "Student")
            //    {
            //        return RedirectToAction("Index", "Student");
            //    }
            //    else if (records.UsersRole == "Vister")
            //    {
            //        return RedirectToAction("Index", "Vister");
            //    }

            //}
            //else
            //{

            //}
            //return View();
        }


        public IActionResult About()
        {
            return View();
        }

        public IActionResult Course()
        {
            var dataa = database.Courses.ToList();
            return View(dataa);
        }

        public IActionResult Coursedetails()
        {
            return View();
        }

        public IActionResult Teacher()
        {
            return View();
        }

        public IActionResult Teacherdetails()
        {
            return View();
        }

        public IActionResult Blog()
        {
            return View();
        }


        public IActionResult Contact()
        {
            return View();
        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}