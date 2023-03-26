using System.Data.Entity;
using Webmall.Model.Database.DataLayer.Models;

namespace Webmall.Model.Database.DataLayer
{
    public class WebmallDbContext : DbContext
    {
        public WebmallDbContext()
            : base("name=WebmallDbContext")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    
        public DbSet<DbAddress> Addresses { get; set; }
        public DbSet<DbBootLog> BootLog { get; set; }
        public DbSet<DbUser> Users { get; set; }
        public DbSet<DbUserHistory> UsersHistory { get; set; }
        public DbSet<DbVINRequestDetail> VINRequestDetails { get; set; }
        public DbSet<DbVINRequest> VINRequests { get; set; }
        public DbSet<DbVinSearchHistory> VinSearchHistories { get; set; }
        public DbSet<DbClientPresenter> ClientPresenters { get; set; }
        public DbSet<DbCar> Garages { get; set; }
        public DbSet<DbCartPosition> Cart { get; set; }
    }
}
