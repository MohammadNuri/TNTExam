using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNTExam.Domain.Entities.Users;

namespace TNTExam.Domain.Entities.Exams
{

    //آزمون
    public class Lesson : BaseEntity
    {
        public string Name { get; set; } = string.Empty; //نام درس
        public virtual ICollection<LessonToExam> LessonToExams { get; set; } = new List<LessonToExam>(); // رابطه با جدول میانی
    }
}
