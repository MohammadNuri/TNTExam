using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNTExam.Domain.Entities.Exams;

namespace TNTExam.Application.Dtos
{
	public class ScoreDto
	{
		public long ExamId { get; set; }
		public string ExamName { get; set; } = string.Empty;
		public DateTime ExamDate { get; set; }

		public long UserId { get; set; }
        public string UserName { get; set; } = string.Empty;

        public List<LessonScoreDto> Lessons { get; set; } = new List<LessonScoreDto>();
	}
}
