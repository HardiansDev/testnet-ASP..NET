using Rotativa.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Tambahkan env ke variabel agar bisa dipakai untuk konfigurasi Rotativa
var env = builder.Environment;

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Error handling & security
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

// ✅ Konfigurasi Rotativa versi terbaru
RotativaConfiguration.Setup(env.WebRootPath, "wkhtmltopdf");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
