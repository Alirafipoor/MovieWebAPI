using Application.Context;
using Application.Dto.Movie;
using Domain.Entitties.ActorEntities;
using Domain.Entitties.DirectorEntity;
using Domain.Entitties.UserEntity;
using FluentValidation;
using Infrastructure.EntityValidation.Dto;
using Infrastructure.EntityValidation.Entity;
using Infrastructure.Mapping.MyMovieMapping;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Persistance.Context;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddDbContext<DataBaseContext>(options =>
{
    options.UseSqlServer();
});

builder.Services.AddTransient<IDatabaseContext, DataBaseContext>();



//MediatR Config
var assemblies = Assembly.Load("Infrastructure");
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(assemblies));


//JWT Token Config
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(ConfigurationOptions =>
{
    ConfigurationOptions.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidAudience = builder.Configuration["JwtToken:audience"],
        ValidIssuer = builder.Configuration["JwtToken:issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtToken:Key"])),
        ValidateIssuerSigningKey = true,
        ValidateLifetime = true,
    };

    ConfigurationOptions.SaveToken = true;

    //ConfigurationOptions.Events = new JwtBearerEvents
    //{
    //    OnTokenValidated = context =>
    //    {
    //        var TokenValidatorService = context.HttpContext.RequestServices.GetRequiredService<ITokenValidator>();
    //        return TokenValidatorService.Execute(context);
    //    }
    //};
});


//Fluent Validation Config
builder.Services.AddTransient<IValidator<Director>, DirectorValidation>();
builder.Services.AddTransient<IValidator<SmsCode>,SmsCodeValidation>();
builder.Services.AddTransient<IValidator<User>,UserValidation>();
builder.Services.AddTransient<IValidator<ActorDto>,ActorDtoValidation>();
builder.Services.AddTransient<IValidator<AddMovieDto>,AddMovieDtoValidation>();
builder.Services.AddTransient<IValidator<DirectorsDto>,DirectorDtoValidation>();

//
builder.Services.AddHttpClient();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(opt =>
{
    opt.SwaggerDoc("v1", new OpenApiInfo { Title = "MyAPI", Version = "v1" });
    opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });

    opt.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});

//Auto Mapper

builder.Services.AddAutoMapper(typeof(MyMovieProfile));


//

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
