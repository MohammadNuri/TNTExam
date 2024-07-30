using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNTExam.Application.Dtos
{
    public class RequestScoreDto
    {
        public long ExamId { get; set; }
        public long LessonId { get; set; }
        public int? Correct { get; set; } //صحیح
        public int? Wrong { get; set; } //غلط
        public int? NoAnswer { get; set; } //نزده   
        public double? RawScore { get; set; } //نمره خام
    }
}
