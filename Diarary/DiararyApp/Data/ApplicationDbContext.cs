using DiaryApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace DiaryApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) 
        { 

        }

        public DbSet<DiaryEntry> DiaryEntries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<DiaryEntry>().HasData(
               new DiaryEntry { Id = 1, 
                   Title="Went Hiking",
                   Content="Went hiking with Joe!",
                   Create = DateTime.Now}, 

               new DiaryEntry { Id = 2, 
                   Title="Went Shopping",
                   Content="Went Shopping with Joe!",
                   Create = DateTime.Now},

               new DiaryEntry { Id = 3, 
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
