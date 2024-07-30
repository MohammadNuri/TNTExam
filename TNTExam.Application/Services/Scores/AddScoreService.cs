using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNTExam.Application.Dtos;
using TNTExam.Common;
using TNTExam.Domain.Entities.Exams;

namespace TNTExam.Application.Services.Scores
{
    public class AddScoreService : IAddScoreService
    {
        private readonly IDataBaseContext _context;
        public AddScoreService(IDataBaseContext context)
        {
            _context = context;
        }

        public ServiceResult Execute(RequestScoreDto request)
        {
            var validationResult = ValidateRequest(request);

            if (!validationResult.IsSuccess)
            {
                return validationResult;
            }

            LessonToExam lessonToExam = new LessonToExam()
            {
                ExamId = request.ExamId,
                LessonId = request.LessonId,
                Score = new Score()
                {
                    Correct = request.Correct,
                    Wrong = request.Wrong,
                    NoAnswer = request.NoAnswer,
                    RawScore = request.RawScore,
                }
            };

            _context.LessonToExams.Add(lessonToExam);
            _context.SaveChanges();

            return new ServiceResult()
            {
                IsSuccess = true,
                Message = "نمرات با موفقیت اضافه شد",
            };
        }

        private ServiceResult ValidateRequest(RequestScoreDto request)
        {
            var exam = _context.Exams.FirstOrDefault(c => c.Id == request.ExamId);
            if (exam == null)
            {
                return new ServiceResult()
                {
                    IsSuccess = false,
                    Message = "آزمون پیدا نشد",
                };
            }

            var lesson = _context.Lessons.FirstOrDefault(c => c.Id == request.LessonId);
            if (lesson == null)
            {
                return new ServiceResult()
                {
                    IsSuccess = false,
                    Message = "درس پیدا نشد",
                };
            }

            if (request.Correct == null)
            {
                return new ServiceResult()
                {
                    IsSuccess = false,
                    Message = "مقدار نمره صحیح وارد نشده",
                };
            }

            if (request.Wrong == null)
            {
                return new ServiceResult()
                {
                    IsSuccess = false,
                    Message = "مقدار نمره غلط وارد نشده",
                };
            }

            if (request.NoAnswer == null)
            {
                return new ServiceResult()
                {
                    IsSuccess = false,
                    Message = "مقدار تعداد نزده وارد نشده",
                };
            }

            if (request.RawScore == null)
            {
                return new ServiceResult()
                {
                    IsSuccess = false,
                    Message = "مقدار نمره خام وارد نشده",
                };
            }

            return new ServiceResult()
            {
                IsSuccess = true,
            };
        }
    }
}
