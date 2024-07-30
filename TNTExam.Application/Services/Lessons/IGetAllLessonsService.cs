using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNTExam.Application.Dtos;
using TNTExam.Common;

namespace TNTExam.Application.Services.Lessons
{
    public interface IGetAllLessonsService
	{
		ServiceResult<AllLessonsDto> Execute();
		ServiceResult<List<LessonDto>> GetAllLessons();
	}
}
