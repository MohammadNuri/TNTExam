using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNTExam.Domain.Entities.Exams
{
    public class Score : BaseEntity
    {

        public int? Correct { get; set; } //صحیح
        public int? Wrong { get; set; } //غلط
        public int? NoAnswer { get; set; } //نزده   
        public double? RawScore { get; set; } //نمره خام

        public long LessonToExamId { get; set; }
        public virtual LessonToExam LessonToExam { get; set; } //مربوط به یک درس در یک آزمون
    }
}
