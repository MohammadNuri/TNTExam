using TNTExam.Application.Dtos;

namespace TNTExam.Models
{
	public class ScoreViewModel
	{
		public ScoreDto Score { get; set; } = new ScoreDto();
		public List<LessonDto> Lessons { get; set; } = new List<LessonDto>();
	}
}
