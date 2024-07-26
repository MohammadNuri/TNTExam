using Microsoft.AspNetCore.Mvc;
using TNTExam.Application.Dtos;
using TNTExam.Application.Services.Lessons;

namespace TNTExam.Controllers
{
	public class LessonController : Controller
	{

		private readonly IAddLessonService _addLessonService;
		private readonly IGetAllLessonsService _getAllLessonsService;
        public LessonController(IAddLessonService addLessonService, IGetAllLessonsService getAllLessonsService)
        {
            _addLessonService = addLessonService;
			_getAllLessonsService = getAllLessonsService;
        }
        public IActionResult Index()
		{
			var result = _getAllLessonsService.Execute();

			if (!result.IsSuccess)
			{
				ViewBag.ErrorMessage = result.Message;
				return View(new AllLessonsDto());
			}

			return View(result.Value);
		}



		public IActionResult AddLesson(string name)
		{
			var result = _addLessonService.Execute(name);

			return Json(result);
		}

	}
}
