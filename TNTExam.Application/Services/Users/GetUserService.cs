using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNTExam.Application.Dtos;
using TNTExam.Common;

namespace TNTExam.Application.Services.Users
{
	public class GetUserService : IGetUserService
	{

		private readonly IDataBaseContext _context;
        public GetUserService(IDataBaseContext context)
        {
            _context = context;
        }
        public ServiceResult<List<UserDto>> Execute(long userId)
		{
			var user = _context.Users
				.FirstOrDefault(c => c.Id == userId);

			if (user == null)
			{
				return new ServiceResult<List<UserDto>>()
				{
					IsSuccess = false,
					Message = "کاربر پیدا نشد",
				};
			}

			UserDto userDto = new UserDto()
			{
				FullName = $"{user.FirstName} {user.LastName}",
				UserId = user.Id,
			};

			List<UserDto> list = new List<UserDto>();
			list.Add(userDto);


			return new ServiceResult<List<UserDto>>()
			{
				IsSuccess = true,
				Message = "با موفقیت برگشت داده شد",
				Value = list,
			};
		}
	}
}
