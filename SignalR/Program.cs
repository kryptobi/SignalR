using SignalRTest;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSignalR();

builder.Services.AddControllers();

var app = builder.Build();

app.UseCors(builder =>
            {
                builder.WithOrigins("http://localhost:63342")
                       .AllowAnyHeader()
                       .AllowCredentials()
                       .AllowAnyMethod();
            });

app.MapHub<HubMethods>("chat");
app.MapDefaultControllerRoute();
app.Run();