using Microsoft.EntityFrameworkCore;
using System;
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


    }
}
