using Gourmand.Data;
using Gourmand.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddDbContext<GourmandDBContext>(options => { options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")); });

var app = builder.Build();
app.MapControllers();
app.UseHttpsRedirection();

app.Run();
