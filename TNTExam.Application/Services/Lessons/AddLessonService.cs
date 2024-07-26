using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNTExam.Common;
using TNTExam.Domain.Entities.Exams;

namespace TNTExam.Application.Services.Lessons
{
	public class AddLessonService : IAddLessonService
	{

		private readonly IDataBaseContext _context;
        public AddLessonService(IDataBaseContext context)
        {
            _context = context;
        }
        public ServiceResult Execute(string name)
		{
			if (string.IsNullOrEmpty(name))
			{
				return new ServiceResult()
				{
					IsSuccess = false,
					Message = "لطفا نام درس را وارد کنید",
				};
			}

			Lesson lesson = new Lesson()
			{
				Name = name,
			};

			_context.Lessons.Add(lesson);
			_context.SaveChanges();	

			return new ServiceResult()
			{
				IsSuccess = true,
			    Message = "با موفقیت اضافه شد",
			};
		}
	}
}
