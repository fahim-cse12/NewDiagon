using GLDiagonistic.Domain.Users;
using GLDiagonistic.Infrastucture.Common;
using GLDiagonistic.Infrastucture.Helper;
using GLDiagonistic.Infrastucture.Repository.DoctorRepository;
using GLDiagonistic.Infrastucture.Repository.PatientAppointmentRepository;
using GLDiagonistic.Infrastucture.Repository.User;
using GLDiagonistice.Application.IRepository;
using GLDiagonistice.Application.IService.Common;
using GLDiagonistice.Application.IService.IDoctor;
using GLDiagonistice.Application.IService.IPatientAppointmentService;
using GLDiagonistice.Application.IService.User;
using GLDiagonistice.Application.Service.Common;
using GLDiagonistice.Application.Service.Doctor;
using GLDiagonistice.Application.Service.PatientAppointmentService;
using GLDiagonistice.Application.Service.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<GLDDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString"));
});

builder.Services.AddIdentityCore<User>(options =>
{
    options.Password.RequiredLength = 6;
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;

    options.SignIn.RequireConfirmedEmail = true;
}).AddRoles<IdentityRole>() // be able add roles
.AddRoleManager<RoleManager<IdentityRole>>()   // be abgle to make use of Rolemanger
.AddEntityFrameworkStores<GLDDbContext>() // Providing our Context
.AddSignInManager<SignInManager<User>>() // make use of Signin Manger
.AddUserManager<UserManager<User>>();  // make use of UserManager to create users

builder.Services.AddAuthentication("AuthCookie").AddCookie("AuthCookie",
             options =>
             {
                 options.Cookie.Name = "AuthCookie";
                 options.LoginPath = "/Account/Login";

             });

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IMailService, MailService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAppointmentService, PatientAppointmentService>();
builder.Services.AddScoped<IPatientAppointmentRepository, PatientAppointmentRepository>();
builder.Services.AddScoped<IDoctorRepository, DoctorRepository>();
builder.Services.AddScoped<IDoctorService, DoctorService>();
builder.Services.AddAutoMapper(typeof(AutoMappingProfile).Assembly);

var emailConfig = builder.Configuration.GetSection("EmailConfiguration").Get<EmailConfiguration>();
builder.Services.AddSingleton(emailConfig);
builder.Services.Configure<IdentityOptions>(opt => opt.SignIn.RequireConfirmedEmail = true);


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
