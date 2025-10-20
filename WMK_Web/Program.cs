var builder = WebApplication.CreateBuilder(args);

// (tuỳ chọn) nếu có API
builder.Services.AddControllers();

var app = builder.Build();

// API endpoints
app.MapControllers();

// Static files cho Production (sau khi build Vite vào wwwroot)
app.UseDefaultFiles();
app.UseStaticFiles();

if (app.Environment.IsDevelopment())
{
    // DEV: duyệt 1 URL của ASP.NET Core, nó PROXY sang Vite dev server => HMR cực nhanh, không CORS
    app.UseSpa(spa =>
    {
        spa.Options.SourcePath = "ClientApp";
        spa.UseProxyToSpaDevelopmentServer("http://localhost:5173");
    });
}
else
{
    // PROD: trả về index.html trong wwwroot cho mọi route SPA
    app.MapFallbackToFile("/index.html");
}

app.Run();
