using TNTExam.Application.Dtos;

namespace TNTExam.Models
{
	public class ExamViewModel
	{
		public List<ExamDto> Exams { get; set; } = new List<ExamDto>();
		public List<UserDto> Users { get; set; } = new List<UserDto>();
	}
}
