using System.Data.Entity;
using Service.Data.Models.Models;
using Service.Global.Settings;

namespace Service.Data.Contexts
{
    public class DbFinContext : DbContext
    {
        public DbFinContext(string dbName) : base(dbName)
        {
        }

        public DbFinContext() : base("FinDb.Db.Dev")
        {
        }

        public ApplicationSettings Setting { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<DateCollection> Dates { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}