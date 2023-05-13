using BoardingTracker.Application.Candidates.Queries.GetAllCandidates;
using BoardingTracker.Application.Infrastructure;
using BoardingTracker.Application.Infrastructure.Mapper;
using BoardingTracker.WebApi.Infrastructure.Data.Extensions;
using BoardingTracker.WebApi.Infrastructure.ExceptionHandling.Middleware;
using BoardingTracker.WebApi.Infrastructure.SendGrid.Extensions;
using FluentValidation;
using MediatR;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

await builder.Services.AddDatabase(builder.Configuration);

builder.Services.AddMediatR(typeof(GetCandidates).GetTypeInfo().Assembly);
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
builder.Services.AddAutoMapper(typeof(BoardingTrackerMappingProfile));
builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());


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
