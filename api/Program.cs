using Microsoft.EntityFrameworkCore;
using static api.Utils.ConnectionStringHelper;
using api.Database;
using api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHealthChecks();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<PersistenceContext>(
  options => options.UseNpgsql(GetConnectionString(builder))
  );


builder.Services.AddScoped<WeaponService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
  app.UseHttpLogging();
}
app.MapHealthChecks("/healthz");
// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using (var serviceScope = app.Services.GetService<IServiceScopeFactory>()!.CreateScope())
{
  var context = serviceScope.ServiceProvider.GetRequiredService<PersistenceContext>();
  context.Database.Migrate();

  InitializeWeaponTemplates.Seed(context);
}

app.Run();
