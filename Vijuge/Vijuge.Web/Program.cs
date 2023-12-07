using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System.Text;
using Vijuge.Data;
using Vijuge.Data.Models.DTOs;
using Vijuge.Data.Repositories.Implementation;
using Vijuge.Data.Repositories.Interface;
using Vijuge.Web.Configuration;

// Add services to the container.

try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Services.AddAutoMapper(typeof(Program));
    builder.Services.AddDatabaseses(builder.Configuration);

    builder.Configuration.AddConfiguration();

    builder.Services.AddControllers();

    builder.Services.AddDatabaseses(builder.Configuration);
    builder.Services.AddServices(builder.Configuration);

    builder.Services.AddIdentityCore<UserDTO>()
                    .AddEntityFrameworkStores<VijugeDbContext>();

    builder.Services.AddMvc();

    builder.Services.AddAuthorizationBuilder();

    var jwtIssuer = builder.Configuration.GetSection("your_issuer").Get<string>();
    var jwtKey = builder.Configuration.GetSection("your_secret_key").Get<string>();

    builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = "your_issuer",
                ValidAudience = "your_audience",
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("your_secret_key"))
            };
        });

    var app = builder.Build();

    app.UseHttpsRedirection();
    app.UseAuthorization();

    app.MapControllers();

    app.Run();

}
catch (Exception ex)
{
    Console.WriteLine("Exception in app start/config: " + ex.Message);
    Log.Fatal("Exception in app start/config: " + ex.Message);
}
