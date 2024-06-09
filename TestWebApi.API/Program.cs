using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using TestWebApi.Application.Services;
using TestWebApi.Core.Abstractions;
using TestWebApi.Core.Auth;
using TestWebApi.DataAccess;
using TestWebApi.DataAccess.Entities;
using TestWebApi.DataAccess.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors();

builder.Services.AddAuthorization();

builder.Services.AddAuthentication(options => {
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;

        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = AuthOptions.ISSUER,
            ValidateAudience = true,
            ValidAudience = AuthOptions.AUDIENCE,
            // будет ли валидироваться время существования
            ValidateLifetime = true,
            // валидация ключа безопасности
            ValidateIssuerSigningKey = true,
            // установка ключа безопасности
            IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
        };
    });

builder.Services.AddDbContext<TestWebApiDbContext>(
    options =>
    {
        // b - необходимо для миграции базы данных
        options.UseNpgsql(builder.Configuration.GetConnectionString(nameof(TestWebApiDbContext)), b => b.MigrationsAssembly("TestWebApi.API"));
    });

// добавляем сервисы 
builder.Services.AddScoped<IBooksServices, BooksServices>();
builder.Services.AddScoped<IBookRepository, BookRepository>();

builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<IGenresServices, GenresServices>();
builder.Services.AddScoped<IGenreRepository, GenreRepository>();

builder.Services.AddScoped<IJwtServices, JwtServices>();

var app = builder.Build();

app.UseCors(builder => builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader()
);

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
