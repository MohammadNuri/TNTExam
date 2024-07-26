using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNTExam.Application.Dtos;
using TNTExam.Common;

namespace TNTExam.Application.Services.Lessons
{
	public class GetAllLessonsService : IGetAllLessonsService
	{

		
		private readonly IDataBaseContext _context;
        public GetAllLessonsService(IDataBaseContext context)
        {
            _context = context;
        }
        public ServiceResult<AllLessonsDto> Execute()
		{

			var lessons = _context.Lessons.Select(c => c.Name).ToList();

			if(lessons == null || !lessons.Any())
			{

				return new ServiceResult<AllLessonsDto>()
				{
					IsSuccess = false,
					Message = "درسی پیدا نشد",
				};
			}


			return new ServiceResult<AllLessonsDto>()
			{
				IsSuccess = true,
				Message = "لیست با موفقیت برگشت داده شد",
				Value = new AllLessonsDto()
				{
					Lessons = lessons,	
				},  
			};
		}




	}
}
