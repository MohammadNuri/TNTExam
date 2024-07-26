using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using TNTExam.Application.Dtos;
using TNTExam.Common;

namespace TNTExam.Application.Services.Users
{
	public class GetAllUsersService : IGetAllUsersService
	{
		private readonly IDataBaseContext _context;
        public GetAllUsersService(IDataBaseContext context)
        {
            _context = context;
        }

        public ServiceResult<List<UserDto>> Execute()
        {
            var users = _context.Users
                .Join(_context.UserInRoles, u => u.Id , r => r.UserId , (u,r) => new {u,r})
                .Where(c => c.r.RoleId == 5)
                .ToList();


            if (!users.Any())
            {
                return new ServiceResult<List<UserDto>>()
                {
                    IsSuccess = false,
                    Message = "دانش آموزی وجود ندارد",
                };
            }

            var result = users.Select(c => new UserDto()
            {
                UserId = c.u.Id,
                FullName = $"{c.u.FirstName} {c.u.LastName}"
            }).ToList();

            return new ServiceResult<List<UserDto>>()
            {
                IsSuccess = true,
                Message = "لیست با موفقیت برگشت داده شد",
                Value = result,
            };
        }
    }
}
