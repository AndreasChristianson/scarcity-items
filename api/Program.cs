using api;
using Microsoft.EntityFrameworkCore;
using static api.Utils.ConnectionStringHelper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHealthChecks();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ItemContext>(options =>
            options.UseNpgsql(
              GetConnectionString(builder)
              ));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapHealthChecks("/healthz");
// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
