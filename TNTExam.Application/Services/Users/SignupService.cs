using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNTExam.Application.Dtos;
using TNTExam.Common;
using TNTExam.Domain.Entities.Users;

namespace TNTExam.Application.Services.Users
{
	public class SignupService : ISignupService
	{

		private readonly IDataBaseContext _context;
        public SignupService(IDataBaseContext context)
        {
			_context = context;	
        }


        public ServiceResult Execute(SignupDto request)
		{
			if (string.IsNullOrEmpty(request.FirstName)
				|| string.IsNullOrEmpty(request.LastName)
				|| string.IsNullOrEmpty(request.Email)
				|| string.IsNullOrEmpty(request.Password)
				|| string.IsNullOrEmpty(request.RPassword))
			{
				return new ServiceResult()
				{
					IsSuccess = false,
					Message = "لطفا تمامی اطلاعات را وارد کنید ",
				};
			}

			if (request.Password != request.RPassword)
			{
				return new ServiceResult()
				{
					IsSuccess = false,
					Message = "رمز های عبور وارد شده با هم برابر نیست",
				};
			}


			var users = _context.Users.ToList();
			if(users.Any(c => c.Email == request.Email))
			{
				return new ServiceResult()
				{
					IsSuccess = false,
					Message = "ایمیل تکراری می باشد",
				};
			}

			var passwordHasher = new PasswordHasher();
			var password = passwordHasher.HashPassword(request.Password);

			User user = new User()
			{
				FirstName = request.FirstName,
				LastName = request.LastName,
				Email = request.Email,
				Password = password,
			};

			UserInRole userInRole = new UserInRole()
			{
				RoleId = 5,
				User = user,
				UserId = user.Id,
			};

			_context.Users.Add(user);
			_context.UserInRoles.Add(userInRole);
			_context.SaveChanges();
			
			return new ServiceResult()
			{
				IsSuccess = true,
				Message = "با موفقیت ثبت نام شد",
			};
		}

	}
}
