using WebChat.Hubs;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSignalR();

var app = builder.Build();

app.MapHub<WebChatHub>("/WebChat");

app.Run();
