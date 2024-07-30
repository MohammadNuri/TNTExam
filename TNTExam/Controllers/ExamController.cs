using Microsoft.AspNetCore.Mvc;
using TNTExam.Application.Dtos;
using TNTExam.Application.Services.Exams;
using TNTExam.Application.Services.Lessons;
using TNTExam.Application.Services.Scores;
using TNTExam.Application.Services.Users;
using TNTExam.Common;
using TNTExam.Models;

namespace TNTExam.Controllers
{
	public class ExamController : Controller
	{

		private readonly IGetAllExamService _getAllExamService;
		private readonly IAddExamService _addExamService;
		private readonly IGetAllUsersService _getAllUsersService;
		private readonly IGetAllScoreService _getAllScoreService;
		private readonly IAddScoreService _addScoreService;
		private readonly IGetAllLessonsService _getAllLessonsService;

        public ExamController(IGetAllExamService getAllExamService,
			IAddExamService addExamService,
            IGetAllUsersService getAllUsersService,
            IGetAllScoreService getAllScoreService,
            IAddScoreService addScoreService,
			IGetAllLessonsService getAllLessonsService)
        {
            _getAllExamService = getAllExamService;
            _addExamService = addExamService;
            _getAllUsersService = getAllUsersService;
            _getAllScoreService = getAllScoreService;
            _addScoreService = addScoreService;
			_getAllLessonsService = getAllLessonsService;
        }

        public IActionResult Index()
		{
			var examResult = _getAllExamService.Execute();
			var userResult = _getAllUsersService.Execute();

			var viewModel = new ExamViewModel
			{
				Exams = examResult.IsSuccess ? examResult.Value : new List<ExamDto>(), 
				Users = userResult.IsSuccess ? userResult.Value : new List<UserDto>(),
			};

			if (!examResult.IsSuccess)
			{
				ViewBag.ErrorMessage = examResult.Message;
			}

			return View(viewModel);
		}

		[HttpPost]
		public IActionResult AddExam(ExamDto request)
		{
			var result = _addExamService.Execute(request);
			if(!result.IsSuccess)
			{
				{
					ViewBag.ErrorMessage = result.Message;
					return View(new ServiceResult()
					{
						IsSuccess = false,
						Message = "خطا", 
					});
				}
			}
			return Json(result);
		}



		public IActionResult Detail(long examId)
		{
			var score = _getAllScoreService.Execute(examId);
			var lessons = _getAllLessonsService.GetAllLessons();

			//todo (check why it being null in /exam/detail?examid=anything)

			ScoreViewModel model = new ScoreViewModel()
			{
				Score = score.Value,
				Lessons = lessons.Value,
			};

			return View(model);
		}

		[HttpPost]
        public IActionResult AddScore(RequestScoreDto request)
        {
            var result = _addScoreService.Execute(request);
            return Json(result);
        }

	}
}
