using DomoHome.Api.Services;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddSignalR();
builder.Services.AddControllers();
builder.Services.AddCors(options => options.AddDefaultPolicy(corsBuilder => corsBuilder.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader().AllowCredentials()));

WebApplication app = builder.Build();

app.UseCors();

app.UseRouting();
app.UseEndpoints(
    endpoints =>
        {
            endpoints.MapHub<AlarmHub>("/alarm-hub");
            endpoints.MapControllers();
        });

app.Run();