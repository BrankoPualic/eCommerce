using eCommerce.Users.Api.Endpoints;
using eCommerce.Users.Api.Infrastructure.Persistence;
using eCommerce.Users.Api.Infrastructure.Queries;
using eCommerce.Users.Api.Interfaces;
using eCommerce.Users.Api.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("Database")));

builder.Services.AddTransient<IValidator<CreateUserRequest>, CreateUserRequestValidator>();
builder.Services.AddTransient<IUserManager, UserManager>();
builder.Services.AddTransient<IUserQueries, UserQueries>();

var app = builder.Build();

app.MapUserEndpoints();

app.Run();