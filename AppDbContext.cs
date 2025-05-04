using Microsoft.EntityFrameworkCore;
using SatelliteImageExplorer.Models; // Tüm model sınıflarını buradan çekiyoruz

namespace SatelliteImageExplorer.Data
{
    /// <summary>
    /// Uygulamanın veritabanı bağlamı (DbContext)
    /// </summary>
    public class AppDbContext : DbContext
    {
        /// <summary>
        /// Yapıcı metot, Entity Framework'e hangi seçeneklerin kullanılacağını söyler.
        /// </summary>
        /// <param name="options">DbContext yapılandırma seçenekleri</param>
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        /// <summary>Denizler tablosu</summary>
        public DbSet<Sea> Seas { get; set; }

        /// <summary>Dağlar tablosu</summary>
        public DbSet<Mountain> Mountains { get; set; }

        /// <summary>Tarihi yerler tablosu</summary>
        public DbSet<HistoricPlace> HistoricPlaces { get; set; }

        /// <summary>Şehirler tablosu</summary>
        public DbSet<City> Cities { get; set; }

        /// <summary>Sahiller tablosu</summary>
        public DbSet<Beach> Beaches { get; set; }

        /// <summary>Ormanlar tablosu</summary>
        public DbSet<Forest> Forests { get; set; }

        /// <summary>Gezilecek yerler tablosu</summary>
        public DbSet<TravelDestination> TravelDestinations { get; set; }
    }
}
