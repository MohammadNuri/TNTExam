using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNTExam.Application.Dtos
{
	public class ExamDto
	{
		public long Id { get; set; }
		public string ExamName { get; set; } = string.Empty;
        public DateTime? ExamDate { get; set; }
		public string? UserName { get; set; } = string.Empty;
        public long? UserId { get; set; }


	}
}
