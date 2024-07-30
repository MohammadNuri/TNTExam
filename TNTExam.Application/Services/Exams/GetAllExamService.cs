using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using TNTExam.Application.Dtos;
using TNTExam.Common;

namespace TNTExam.Application.Services.Exams
{
	public class GetAllExamService : IGetAllExamService
	{
		private readonly IDataBaseContext _context;
        public GetAllExamService(IDataBaseContext context)
        {
            _context = context;
        }

        public ServiceResult<List<ExamDto>> Execute()
        {
            var exams = _context.Exams
                .Include(c => c.User)
				.ToList();

			if (!exams.Any())
			{
				return new ServiceResult<List<ExamDto>>()
				{
					IsSuccess = false,
					Message = "آزمونی پیدا نشد",
				};
			}


			var examDtos = exams.Select(c => new ExamDto
			{
				Id = c.Id,
				ExamName = c.Name,
				ExamDate = c.ExamDate,
				UserName = $"{c.User.FirstName} {c.User.LastName}" 
			}).ToList();


			return new ServiceResult<List<ExamDto>>()
			{
				IsSuccess = true,
				Message = "با موفقیت برگشت داده شد",
				Value = examDtos,
			};
		}

		public ServiceResult<List<ExamDto>> Execute(long userId)
		{
			var user = _context.Users.FirstOrDefault(c => c.Id == userId);
			if (user == null)
			{
				return new ServiceResult<List<ExamDto>>()
				{
					IsSuccess = false,
					Message = "یوزر پیدا نشد",
				};
			}

			var q = _context.Exams
				.Where(c => c.UserId == userId)
				.ToList();

			List<ExamDto> list = new List<ExamDto>();

			foreach(var item in q)
			{
				ExamDto exam = new ExamDto()
				{
					ExamDate = item.ExamDate,
					ExamName= item.Name,
					Id = item.Id,
					UserId = item.UserId,
					UserName = $"{user.FirstName} {user.LastName}",	
				};
				list.Add(exam);	
			}

			
			return new ServiceResult<List<ExamDto>>()
			{
				IsSuccess = true,
				Message = "لیست با موفقیت برگشت داده شد",
				Value = list,
			};
		}

	}
}
