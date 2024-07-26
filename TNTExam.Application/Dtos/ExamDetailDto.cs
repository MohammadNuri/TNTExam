using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TNTExam.Domain.Entities.Exams;

namespace TNTExam.Application.Dtos
{
	public class ExamDetailDto
	{
		public long ExamId {  get; set; }
		public string StudentName = string.Empty; //دانش آموز
		public string Name { get; set; } = string.Empty; // نام آزمون
		public DateTime ExamDate { get; set; } //تاریخ آزمون
		public List<LessonDto> Lessons { get; set; } //درس مربوط به آزمون
	}
}
