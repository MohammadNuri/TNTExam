using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNTExam.Application.Dtos;
using TNTExam.Common;

namespace TNTExam.Application.Services.Scores
{
	public class GetAllScoreService : IGetAllScoreService
	{

		private readonly IDataBaseContext _context;
        public GetAllScoreService(IDataBaseContext context)
        {
            _context = context;
        }

		public ServiceResult<ScoreDto> Execute(long examId)
		{
			// Fetch exam details along with associated lessons and scores
			var examQuery = _context.Exams
				.Where(e => e.Id == examId)
				.Select(e => new
				{
					e.Id,
					e.UserId,
					e.User.FirstName,
					e.User.LastName,
					e.Name,
					e.ExamDate,
					Lessons = e.LessonToExams
					.Where(c => c.ExamId == examId)
					.Select(le => new
					{
						le.LessonId,
						LessonName = le.Lesson.Name, // Assuming you have a navigation property to Lesson
						Score = le.Score // Assuming Score is part of the LessonToExam relationship
					})
				})
				.FirstOrDefault();

			// Check if the exam exists
			if (examQuery == null)
			{
				return new ServiceResult<ScoreDto>
				{
					IsSuccess = false,
					Message = "آزمون پیدا نشد"
				};
			}

			// Create the ScoreDto
			var scoreDto = new ScoreDto
			{
				ExamId = examQuery.Id,
				ExamName = examQuery.Name,
				ExamDate = examQuery.ExamDate,
				UserId = examQuery.UserId,
				UserName = $"{examQuery.FirstName} {examQuery.LastName}",
				Lessons = examQuery.Lessons.Select(l => new LessonScoreDto
				{
					LessonId = l.LessonId,
					Name = l.LessonName,
					Correct = l.Score?.Correct,
					Wrong = l.Score?.Wrong,
					NoAnswer = l.Score?.NoAnswer,
					RawScore = l.Score?.RawScore
				}).ToList()
			};

			return new ServiceResult<ScoreDto>
			{
				IsSuccess = true,
				Value = scoreDto
			};
		}

	}
}

