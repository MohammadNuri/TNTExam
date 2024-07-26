﻿using Microsoft.AspNetCore.Mvc;
using TNTExam.Application.Dtos;
using TNTExam.Application.Services.Exams;
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
		public ExamController(IGetAllExamService getAllExamService, IAddExamService addExamService,IGetAllUsersService getAllUsersService)
        {
            _getAllExamService = getAllExamService;
			_addExamService = addExamService;
			_getAllUsersService = getAllUsersService;
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

		public IActionResult Detail(long id)
		{
			return View();
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


		public IActionResult AddScore(long id)
		{


			return Json(null);
		}

	}
}
