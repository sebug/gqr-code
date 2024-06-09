var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Urls.Add("https://localhost:3000");

app.UseDefaultFiles();

app.UseStaticFiles();

app.MapGet("/qrcode", (string text) => {
    return new {
        text
    };
});

app.Run();
