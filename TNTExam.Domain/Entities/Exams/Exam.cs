using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNTExam.Domain.Entities.Users;

namespace TNTExam.Domain.Entities.Exams
{

    //آزمون
    public class Exam : BaseEntity
    {
        public string Name { get; set; } = string.Empty; // نام آزمون   
        public DateTime ExamDate { get; set; } //تاریخ آزمون

        public long UserId { get; set; }
        public virtual User User { get; set; } //دانش آموز

        public virtual ICollection<LessonToExam> LessonToExams { get; set; } = new List<LessonToExam>(); // رابطه با جدول میانی

        public string? Images { get; set; } = string.Empty; //تصویر کارنامه آزمون
    }
}
