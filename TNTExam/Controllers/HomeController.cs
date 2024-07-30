using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using TNTExam.Application.Services.Exams;
using TNTExam.Application.Services.Users;
using TNTExam.Models;

namespace TNTExam.Controllers
{
	public class HomeController : Controller
	{

		private readonly IGetAllExamService _getAllExamsService;
		private readonly IGetUserService _getUserService;

		public HomeController(IGetAllExamService getAllExamService, IGetUserService getUserService)
		{
			_getAllExamsService = getAllExamService;
			_getUserService = getUserService;
		}
		public IActionResult Index()
		{
			if (User.Identity.IsAuthenticated && User.IsInRole("Admin"))
			{
				var examModel = _getAllExamsService.Execute();
				ExamViewModel model = new ExamViewModel()
				{
					Exams = examModel.Value,
				};

				return View(model);
			}

			else if (User.Identity.IsAuthenticated && User.IsInRole("Student"))
			{
				var userId = User.Claims
		               .Where(c => c.Type == ClaimTypes.NameIdentifier)
		               .Select(c => c.Value)
		               .FirstOrDefault();

				if (string.IsNullOrEmpty(userId))
				{
					return RedirectToAction("SignIn", "Authentication");
				}

				var examModel = _getAllExamsService.Execute(Convert.ToInt64(userId));
				var userModel = _getUserService.Execute(Convert.ToInt64(userId));
				ExamViewModel model = new ExamViewModel()
				{
					Exams = examModel.Value,
					Users = userModel.Value,
				};
				return View(model);
			}

			else
			{
				return RedirectToAction("SignIn", "Authentication");
			}



		}
	}
}
