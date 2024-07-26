using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TNTExam.Application.Dtos;
using TNTExam.Common;
using TNTExam.Domain.Entities.Exams;

namespace TNTExam.Application.Services.Exams
{
	public class AddExamService : IAddExamService
	{

		private readonly IDataBaseContext _context;
        public AddExamService(IDataBaseContext context)
        {
            _context = context;
        }

        public ServiceResult Execute(ExamDto request)
		{
			if (string.IsNullOrEmpty(request.ExamName)
				|| request.ExamDate == null
				|| request.UserId == null)
			{

				return new ServiceResult()
				{
					IsSuccess = false,
					Message = "لطفا تمامی موارد را وارد کنید",
				};
			}


			Exam exam = new Exam()
			{
				Name = request.ExamName,
				ExamDate = request.ExamDate.Value,
				UserId = request.UserId.Value,
			};

			_context.Exams.Add(exam);
			_context.SaveChanges();


			return new ServiceResult()
			{
				IsSuccess = true,
				Message = "با موفقیت اضافه شد",
			};
		}
	}
}
