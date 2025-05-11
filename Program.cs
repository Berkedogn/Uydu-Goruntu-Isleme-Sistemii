using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UyduGoruntu.Data; // AppDbContext'in namespace'i (UyduGoruntu projesi için)
using UyduGoruntu.Models; // Proje ismiyle uyumlu model namespace'i

var builder = WebApplication.CreateBuilder(args);

// 🔗 Bağlantı cümlesini oku ve DbContext'i konfigüre et
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 🔧 MVC servislerini ekle
builder.Services.AddControllersWithViews()
    .AddViewLocalization()
    .AddDataAnnotationsLocalization();

// 💡 Razor runtime derleyici (değişiklikleri anında görmek için - isteğe bağlı)
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();

var app = builder.Build();

// 🌍 Ortama göre hata yönetimi
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// 🌐 HTTPS ve Static Files
app.UseHttpsRedirection();
app.UseStaticFiles();

// MVC routing işlemleri
app.UseRouting();
app.UseAuthorization();

// Varsayılan route yapılandırması
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
