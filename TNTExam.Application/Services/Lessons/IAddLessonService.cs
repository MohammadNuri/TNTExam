using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNTExam.Common;

namespace TNTExam.Application.Services.Lessons
{
	public interface IAddLessonService
	{
		ServiceResult Execute(string name);
	}
}
