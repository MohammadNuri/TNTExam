using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNTExam.Application.Dtos;
using TNTExam.Common;

namespace TNTExam.Application.Services.Users
{
	public class SigninService : ISigninService
	{

		private readonly IDataBaseContext _context;
        public SigninService(IDataBaseContext context)
        {
            _context = context;
        }

        public ServiceResult<ResultSigninDto> Execute(SigninDto request)
		{

			var user = _context.Users
				.Include(c => c.UserInRoles)
				.FirstOrDefault(c => c.Email == request.Email);


			if (user == null)
			{
				return new ServiceResult<ResultSigninDto>()
				{
					IsSuccess = false,
					Message = "ایمیل یا رمز عبور اشتباه می باشد",
				};
			}


			var passwordHasher = new PasswordHasher();
			bool verifyPass = passwordHasher.VerifyPassword(user.Password, request.Password);

			if (verifyPass == false)
			{
				return new ServiceResult<ResultSigninDto>()
				{
					IsSuccess = false,
					Message = "ایمیل یا رمز عبور اشتباه می باشد",
				};
			}


			var roleId = user.UserInRoles.Select(c => c.RoleId).First();
			var role = _context.Roles.FirstOrDefault(c => c.Id == roleId);

			if(role == null)
			{
				return new ServiceResult<ResultSigninDto>()
				{
					IsSuccess = false,
					Message = "نقش کاربر پیدا نشد لطفا با دولوپر تماس بگیرید",
				};
			}


			return new ServiceResult<ResultSigninDto>()
			{
				IsSuccess = true,
				Message = "با موفقیت وارد شدید",
				Value = new ResultSigninDto()
				{
					UserId = user.Id,
					Name = $"{user.FirstName} {user.LastName}",
					Role = role.Name,
				}
			};
		}

	}
}
