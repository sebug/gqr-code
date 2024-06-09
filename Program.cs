using ZXing;
using ZXing.QrCode;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Urls.Add("https://localhost:3000");

app.UseDefaultFiles();

app.UseStaticFiles();

app.MapGet("/qrcode", (string text) => {
    var writer = new QRCodeWriter();
    var matrix = writer.encode(text, BarcodeFormat.QR_CODE, 500,
             500, null);
    List<List<bool>> table = new List<List<bool>>();
    for (int y = 0; y < matrix.Height; y += 1)
    {
        var row = new List<bool>();
        for (int x = 0; x < matrix.Width; x += 1)
        {
            row.Add(matrix[x, y]);
        }
        table.Add(row);
    }
    return new {
        table
    };
});

app.MapPost("/gcodes", (List<List<bool>> table) => {
    return new {
        height = table.Count,
        width = table[0].Count
    };
});

app.Run();
