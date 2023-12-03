using Microsoft.Extensions.Configuration;
using Serilog;
using Vijuge.Web.Configuration;

// Add services to the container.

try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Configuration.AddConfiguration();

    builder.Services.AddControllers();
    builder.Services.AddDatabaseses(builder.Configuration);
    builder.Services.AddServices(builder.Configuration);

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
    app.Run();

}
catch (Exception ex)
{
    Console.WriteLine("Exception in app start/config: " + ex.Message);
    Log.Fatal("Exception in app start/config: " + ex.Message);
}
