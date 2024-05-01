using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using task_tracker_api_backend.Services;
using task_tracker_api_backend.Services.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<UserService>();

// This is how we’re connecting our database to API
var connectionString = builder.Configuration.GetConnectionString("MyTaskTrackerString");

//configures entity framework core to use SQL server as the database provider for a datacontext DbContext in our project
builder.Services.AddDbContext<DataContext>(Options => Options.UseSqlServer(connectionString));

builder.Services.AddCors(options => options.AddPolicy("TaskTrackerPolicy", 
builder => {
    builder.WithOrigins("http://localhost:5074")
    .AllowAnyHeader()
    .AllowAnyMethod();
}
));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();
app.UseCors("TaskTrackerPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
