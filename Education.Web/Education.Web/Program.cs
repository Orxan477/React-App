using Microsoft.EntityFrameworkCore;
using Education.Data.DAL;
using Education.Core.Interfaces;
using Education.Data.Implementations;
using Education.Business.Implementations.Employee;
using Education.Business.Interfaces.Employee;
using MediatR;
using Education.Business.Mediator.Queries;
using AutoMapper;
using Education.Business.Profiles;
using FluentValidation.AspNetCore;
using Education.Business.Validations.Employee;
using Education.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Education.Business.Implementations.Account;
using Education.Business.Interfaces.Account;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

builder.Services.AddControllers();
//builder.Services.AddControllersWithViews();
builder.Services.AddMediatR(typeof(GetEmployeeByIdQuery));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration["ConnectionStrings:Default"]);
});

builder.Services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(opt =>
{
    opt.Password.RequireDigit = true;
    opt.Password.RequireLowercase = false;
    opt.Password.RequireUppercase = false;
    opt.Password.RequireNonAlphanumeric = false;

    opt.Lockout.AllowedForNewUsers = true;
    opt.Lockout.MaxFailedAccessAttempts = 3;
    opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);

    opt.User.RequireUniqueEmail = true;
});

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IAccountService, AccountService>();

builder.Services.AddMapperService();
builder.Services.AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<CreateEmployeeVMValidation>());
builder.Services.AddAuthentication(opt =>
{
    opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(opt =>
{
    opt.TokenValidationParameters = new TokenValidationParameters
    {
        ValidAudience = builder.Configuration["Jwt:audience"],
        ValidIssuer = builder.Configuration["Jwt:issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                                                        builder.Configuration["Jwt:securityKey"]))
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllerRoute(
//      name: "default",
//      pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
//    );
//});
