using DiararyApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace DiararyApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) 
        { 

        }

        public DbSet<DairyEntry> DiaryEntries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<DairyEntry>().HasData(
               new DairyEntry { Id = 1, 
                   Title="Went Hiking",
                   Content="Went hiking with Joe!",
                   Create = DateTime.Now}, 

               new DairyEntry { Id = 2, 
                   Title="Went Shopping",
                   Content="Went Shopping with Joe!",
                   Create = DateTime.Now},

               new DairyEntry { Id = 3, 
                   Title="Went Diving",
                   Content="Went Diving with Joe!",
                   Create = DateTime.Now}

                );
        }

        /*
         * Four stepts to add a table
         * 1. Create a Model class
         * 2. Add DB Set
         * 3. add-migration AddDiaryEntryTable in Packge Manager Console
         * 4. update-database in console
         */
    }
}
