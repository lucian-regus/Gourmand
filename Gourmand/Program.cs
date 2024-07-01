using Gourmand.Data;
using Gourmand.Repositories;
using Gourmand.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                });

builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IRestaurantRepository, RestaurantRepository>();
builder.Services.AddScoped<ICourierRepository, CourierRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IBasketRepository, BasketRepository>();
builder.Services.AddScoped<ITokenService, TokenService>();

builder.Services.AddDbContext<GourmandDBContext>(options => { options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")); });
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(option =>
{
    option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(JwtOptions =>
    {
        var key = builder.Configuration["Jwt:Key"];
        var keyBytes = Encoding.ASCII.GetBytes(key);
        JwtOptions.SaveToken = true;
        JwtOptions.TokenValidationParameters = new TokenValidationParameters
        {
            IssuerSigningKey = new SymmetricSecurityKey(keyBytes),
            ValidateLifetime = true,
            ValidateAudience = true,
            ValidAudience = builder.Configuration["Jwt:Audience"],
            ValidateIssuer = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"]
        };

    });

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
