using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNTExam.Application.Dtos
{
	public class LessonScoreDto
	{
		public long LessonId { get; set; }
		public string Name { get; set; } = string.Empty; // Lesson name
		public int? Correct { get; set; } // Correct answers
		public int? Wrong { get; set; } // Wrong answers
		public int? NoAnswer { get; set; } // No answer
		public double? RawScore { get; set; } // Raw score
	}
}
