using DoctorWho.Db;
using DoctorWho.Db.Entities;
using DoctorWho.Db.Repositories;
using FluentValidation.AspNetCore;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddFluentValidation(c => c.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()));
//this line to validate data , like: name is not empty ...etc
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DoctorWhoCoreDbContext>(
    dbContextOptions => dbContextOptions.UseSqlServer(
        builder.Configuration["ConnectionStrings:DefaultConnection"]));

builder.Services.AddScoped<IDoctorRepository, DoctorRepository>(); //register a repository
//if i don't write this line, i will get a 500 error
builder.Services.AddScoped<IEpisodeRepository, EpisodeRepository>(); //register a repository
builder.Services.AddScoped<IAuthorRepository, AuthorRepository>(); //register a repository


builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
