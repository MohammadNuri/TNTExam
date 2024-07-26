using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNTExam.Domain.Entities.Exams
{
    public class LessonToExam : BaseEntity
    {
        public long LessonId { get; set; }
        public virtual Lesson Lesson { get; set; }

        public long ExamId { get; set; }
        public virtual Exam Exam { get; set; }

        public virtual Score Score { get; set; } // نمره درس
    }
}
