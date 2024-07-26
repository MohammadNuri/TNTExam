using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices.JavaScript;
using System.Security.Claims;
using TNTExam.Application.Dtos;
using TNTExam.Application.Services.Users;
using TNTExam.Models;

namespace TNTExam.Controllers
{
    public class AuthenticationController : Controller
    {


        private readonly ISignupService _signupService;
		private readonly ISigninService _signinService;

		public AuthenticationController(ISignupService signupService, ISigninService signinService)
        {
            _signupService = signupService;
            _signinService = signinService;
        }

        public IActionResult Index()
        {
            return View();
        }



        public IActionResult SignIn()
        {
            return View();
        }


        public IActionResult SignUp()
        {
            return View();
        }


        [HttpPost]
        public IActionResult SignUpExecute(SignupDto request)
        {
            var result = _signupService.Execute(request);
			return Json(result);
        }

		[HttpPost]
		public IActionResult SignInExecute(SigninDto request)
		{
			var result = _signinService.Execute(request);

			if (result.IsSuccess)
			{
				var role = result.Value.Role;

				var claims = new List<Claim>
				{
					new Claim(ClaimTypes.NameIdentifier, result.Value.UserId.ToString()),
					new Claim(ClaimTypes.Email, request.Email),
					new Claim(ClaimTypes.Name, result.Value.Name),
					new Claim(ClaimTypes.Role, result.Value.Role),
				};

				var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
				var principal = new ClaimsPrincipal(identity);
				var properties = new AuthenticationProperties
				{
					IsPersistent = true,
					ExpiresUtc = DateTime.Now.AddDays(5)
				};

				HttpContext.SignInAsync(principal, properties);
			}


			return Json(result);
		}




	}
}
