using System.Reflection.Metadata.Ecma335;

namespace TNTExam.Application.Dtos
{
	public class LessonDto
	{
        public long LessonId { get; set; }
        public string Name { get; set; } = string.Empty; //نام درس
	}
}
