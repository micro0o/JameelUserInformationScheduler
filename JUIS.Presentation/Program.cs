using Hangfire;
using JUIS.Application;
using JUIS.Domain.Interfaces;
using JUIS.Infrastructure;
using JUIS.Infrastructure.Data;
using JUIS.Presentation.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder =>
        {
            builder.WithOrigins("http://localhost:4200") // Add more origins if needed
                   .AllowAnyHeader()
                   .WithMethods("GET", "POST") // Add more methods if needed
                   .AllowCredentials();
        });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSignalR();


builder.Services.AddHangfire(builder.Configuration.GetConnectionString("HangfireConnection"));
builder.Services.AddDbContext<UserDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
//builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<INotificationService, SignalRNotificationService>();
builder.Services.AddHealthChecks();
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

app.UseHangfire();

app.UseCors("AllowSpecificOrigin");

app.UseRouting().UseEndpoints(e => {
    e.MapControllers();
    e.MapHangfireDashboard();
    e.MapHub<NotificationHub>("/notificationHub");
    e.MapHealthChecks("/healthCheck");
});

app.Run();
