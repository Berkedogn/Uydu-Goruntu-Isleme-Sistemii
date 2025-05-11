using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using UyduGoruntu.Data; // AppDbContext'in namespace'i
using UyduGoruntu.Models; // Eğer varsa model namespace

var builder = WebApplication.CreateBuilder(args);

// 🔗 Veritabanı bağlantısını yapılandır (appsettings.json > DefaultConnection)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 💡 MVC & Razor Pages yapılandırması
builder.Services.AddControllersWithViews()
    .AddViewLocalization()
    .AddDataAnnotationsLocalization();

builder.Services.AddRazorPages()
    .AddRazorRuntimeCompilation(); // Değişiklikleri anlık görmek için

var app = builder.Build();

// 🌍 Ortama göre hata yönetimi
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// 🌐 HTTPS, Statik Dosyalar ve Yönlendirme
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

// 🌐 (İsteğe bağlı) Kültür desteği (örn: Türkçe varsayılan)
var supportedCultures = new[] { new CultureInfo("tr-TR"), new CultureInfo("en-US") };
app.UseRequestLocalization(new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture("tr-TR"),
    SupportedCultures = supportedCultures,
    SupportedUICultures = supportedCultures
});

// 🔁 Varsayılan route ayarı (HomeController > Index)
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

