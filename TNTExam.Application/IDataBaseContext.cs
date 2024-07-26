using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNTExam.Domain.Entities.Exams;
using TNTExam.Domain.Entities.Users;

namespace TNTExam.Application
{
    public interface IDataBaseContext
    {
        DbSet<User> Users { get; set; }
        DbSet<UserInRole> UserInRoles { get; set; }
        DbSet<Role> Roles { get; set; }
        DbSet<Exam> Exams { get; set; }
        DbSet<Lesson> Lessons { get; set; }
        DbSet<Score> Scores { get; set; }
        DbSet<LessonToExam> LessonToExams { get; set; }

        int SaveChanges(bool acceptAllChangesOnSuccess);
        int SaveChanges();
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken());
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
    }
}
