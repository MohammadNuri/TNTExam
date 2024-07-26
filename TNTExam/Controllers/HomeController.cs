using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TNTExam.Models;

namespace TNTExam.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
