using Microsoft.EntityFrameworkCore;
using StudentWebApi.Data;
using StudentWebApi.Data.Repositories.Implementation;
using StudentWebApi.Data.Repositories.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});
RegisterRepositories(builder.Services);

//-------------------------[ Register Repository Here ]---------------------------------
void RegisterRepositories(IServiceCollection services)
{
    services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
    services.AddTransient<IStudentRepository, StudentRepository>();
}
//--------------------------------------------------------------------------------------


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

app.UseCors();

app.Run();
