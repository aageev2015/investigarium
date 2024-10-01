using Hangfire;
using HangfireBasicsService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddHangfire((serviceProvider, config) =>
{
    var connectionString = serviceProvider
        .GetRequiredService<IConfiguration>()
        .GetConnectionString("HangfireDB");
    config
        .SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
        .UseSimpleAssemblyNameTypeSerializer()
        .UseRecommendedSerializerSettings()
        .UseSqlServerStorage(connectionString);
});
builder.Services.AddHangfireServer();
builder.Services.AddHangfireBasicsService();

var app = builder.Build();

// Configure the HTTP request pipeline.

//app.UseStaticFiles(); // ???
//app.UseHttpsRedirection();
//app.UseRouting(); //???
app.UseAuthorization();

app.UseHangfireDashboard();

//app.MapControllers(); // ??

app.Run();
