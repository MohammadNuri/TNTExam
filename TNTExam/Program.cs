using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using TNTExam.Application;
using TNTExam.Application.Services.Exams;
using TNTExam.Application.Services.Lessons;
using TNTExam.Application.Services.Scores;
using TNTExam.Application.Services.Users;
using TNTExam.Common;
using TNTExam.Persistence.Context;

var builder = WebApplication.CreateBuilder(args);


// DataBase
builder.Services.AddScoped<IDataBaseContext, DataBaseContext>();
builder.Services.AddDbContext<DataBaseContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
}).AddCookie(options =>
{
    options.LoginPath = new PathString("/Authentication/Login");
    options.ExpireTimeSpan = TimeSpan.FromDays(5);
    options.AccessDeniedPath = "/Authentication/AccessDenied";
});

// Authorization
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy(UserRoles.Admin, policy => policy.RequireRole(UserRoles.Admin));
    options.AddPolicy(UserRoles.Student, policy => policy.RequireRole(UserRoles.Student));
});

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
// Services
builder.Services.AddScoped<ISignupService, SignupService>();
builder.Services.AddScoped<ISigninService, SigninService>();
builder.Services.AddScoped<IAddLessonService, AddLessonService>();
builder.Services.AddScoped<IGetAllLessonsService, GetAllLessonsService>();
builder.Services.AddScoped<IGetAllExamService, GetAllExamService>();
builder.Services.AddScoped<IAddExamService, AddExamService>();
builder.Services.AddScoped<IGetAllUsersService, GetAllUsersService>();
builder.Services.AddScoped<IGetAllScoreService, GetAllScoreService>();
builder.Services.AddScoped<IAddScoreService, AddScoreService>();
builder.Services.AddScoped<IGetUserService, GetUserService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
    
app.Run();
