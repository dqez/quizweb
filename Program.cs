using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using quizweb.Data;
using quizweb.Models;
using quizweb.Repositories.Interfaces;
using quizweb.Repositories.Implementations;
using quizweb.Services.Interfaces;
using quizweb.Services.Implementaitions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false).AddEntityFrameworkStores<AppDbContext>();

//DI for repositories
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ILevelRepository, LevelRepository>();
builder.Services.AddScoped<IMarkedQuestionRepository, MarkedQuestionRepository>();
builder.Services.AddScoped<IProgressQuestionSetRepository, ProgressQuestionSetRepository>();
builder.Services.AddScoped<IQuestionRepository, QuestionRepository>();
builder.Services.AddScoped<IQuestionSetRepository, QuestionSetRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
//DI for services
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ILevelService, LevelService>();
builder.Services.AddScoped<IMarkedQuestionService, MarkedQuestionService>();
builder.Services.AddScoped<IProgressQuestionSetService, ProgressQuestionSetService>();
builder.Services.AddScoped<IQuestionService, QuestionService>();
builder.Services.AddScoped<IQuestionSetService, QuestionSetService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IFileService, FileService>();

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

app.MapRazorPages();
app.Run();
