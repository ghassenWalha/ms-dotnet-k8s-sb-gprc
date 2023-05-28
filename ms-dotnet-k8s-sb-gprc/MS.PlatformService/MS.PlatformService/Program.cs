using Microsoft.EntityFrameworkCore;
using MS.PlatformService.Data;
using MS.PlatformService.Data.Interfaces;
using MS.PlatformService.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IPlatformRepository, PlatformRepository>();
builder.Services.AddDbContext<AppDbContext>(opt =>
opt.UseInMemoryDatabase("InMem")
);

var app = builder.Build();

app.PrepPopulation();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
