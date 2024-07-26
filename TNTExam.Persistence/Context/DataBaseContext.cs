using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using TNTExam.Application;
using TNTExam.Domain.Entities.Exams;
using TNTExam.Domain.Entities.Users;

namespace TNTExam.Persistence.Context
{
    public class DataBaseContext : DbContext, IDataBaseContext
    {
        public DataBaseContext(DbContextOptions opetions) : base(opetions)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserInRole> UserInRoles {  get; set; }
        public DbSet<Role> Roles {  get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Score> Scores { get; set; }
        public DbSet<LessonToExam> LessonToExams { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();
            modelBuilder.Entity<User>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<UserInRole>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<Role>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<Exam>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<Lesson>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<Score>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<LessonToExam>().HasQueryFilter(p => !p.IsRemoved);
        }
    }
}
