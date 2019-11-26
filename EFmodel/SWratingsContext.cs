using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;


namespace WebApiService.EFmodel
{
    public class SWratingsContext : DbContext
    {
        public SWratingsContext()
        {
            this.Database.EnsureCreated();
        }
        public DbSet<SWRating> Ratings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
           => options.UseSqlite("Data Source=Ratings.db");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          
            modelBuilder.Entity<SWRating>()
                .HasKey(p => p.ID);

          
        }
    }


}
