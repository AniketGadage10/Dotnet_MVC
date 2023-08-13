using Microsoft.AspNetCore.Mvc;
using PassionPursuit.Models;
using System.Diagnostics;
using BLL;
using BOL;
namespace PassionPursuit.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Register()
        {
            ViewData["welcome"] = "WELCOME TO REGISTER PAGE";
            return View();
        }

        [HttpPost]
        public IActionResult Register(string name, String age, String email, string password, String hobies, String dob)
        {
            User u = new User(name, int.Parse(age), email, password, hobies, DateOnly.Parse(dob));
            if (BLL.Userservice.insertuser(u) == 0)
            {
                return View("Index");
            }
            return View("Login");
        }

        [HttpGet]
        public IActionResult Login()
        {
            ViewData["welcome"] = "Welcome To Passion Pursuit";
            return View();
        }

        [HttpPost]
        public IActionResult Login(String email, String password)
        {
            User u = BLL.Userservice.validate(email, password);
            if (u == null)
            {
                return RedirectToAction("Register");
            }
            ViewBag.user = u;
            return View("userdata");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Console.WriteLine(id);
            ViewData["welcome"] = "Welcome To Update Page";
            ViewBag.user = BLL.Userservice.Getbyid(id);
            return View();
        }

        [HttpPost]
        public IActionResult Edit(String id, string name, String age, String email, string password, String hobies, String dob)
        {
            User u = new User(int.Parse(id), name, int.Parse(age), email, password, hobies, DateOnly.Parse(dob));
            if(BLL.Userservice.update(u)==1)
            {
                ViewBag.user = u;
                return View("userdata");
            }
            return View("Login");
        }

        [HttpGet]
        public IActionResult GetList()
        {
            ViewData["welcome"] = "Welcome To User List";
           List<User> list=BLL.Userservice.Getbylist();
            ViewBag.user = list;
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            //ViewData["welcome"] = "Thank You For ";
            BLL.Userservice.deletebyid(id);
            return RedirectToAction("GetList");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}