using BoardingTracker.Application.Auth.Abstract;
using BoardingTracker.Application.Auth.Options;
using BoardingTracker.Application.Auth.Services;
using BoardingTracker.Application.Auth.TokenGenerators;
using BoardingTracker.Application.Candidates.Queries.GetAllCandidates;
using BoardingTracker.Application.Infrastructure;
using BoardingTracker.Application.Infrastructure.Mapper;
using BoardingTracker.WebApi.Infrastructure.Data.Extensions;
using BoardingTracker.WebApi.Infrastructure.ExceptionHandling.Middleware;
using BoardingTracker.WebApi.Infrastructure.SendGrid.Extensions;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

await builder.Services.AddDatabase(builder.Configuration);

builder.Services.AddMediatR(typeof(GetCandidates).GetTypeInfo().Assembly);
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
builder.Services.AddAutoMapper(typeof(BoardingTrackerMappingProfile));
builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());



JwtOptions jwtOptions = new JwtOptions();
builder.Configuration.Bind("JwtOptions", jwtOptions);

builder.Services.AddSingleton(jwtOptions);

builder.Services.AddSingleton<JwtTokenGenerator>();
builder.Services.AddSingleton<AccessTokenGenerator>();
builder.Services.AddSingleton<RefreshTokenGenerator>();
builder.Services.AddScoped<ISecurityRepository, SecurityRepository>();
builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();
builder.Services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(o =>
{
    o.TokenValidationParameters = new TokenValidationParameters()
    {
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.AccessTokenSecret)),
        ValidIssuer = jwtOptions.Issuer,
        ValidAudience = jwtOptions.Audience,
        ValidateIssuerSigningKey = true,
        ValidateIssuer = true,
        ValidateAudience = true,
        ClockSkew = TimeSpan.Zero
    };
});

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCustomSendGrid(builder.Configuration);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.WithOrigins(new[] { "http://localhost:4200", "http://localhost:9876", "http://localhost:9877" })
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
});

var app = builder.Build();
app.UseMiddleware<GlobalExceptionHandlingMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
