//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Reflection;
//using System.Text;
//using System.Threading.Tasks;

//namespace DataAccess
//{
//    public class RetailDataContext : DbContext
//    {
//         public DbSet<PersonEntity> Persons { get; set; }
//        public RetailDataContext()
//        {
//            SQLitePCL.Batteries_V2.Init();

//            Database.EnsureCreated();
//        }
//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//           // var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "RetailDatabse" + ".sqlite");
//            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "retaildatabase.db3");
//            //optionsBuilder.UseSqlite($"Filename={dbPath}");
//            ////optionsBuilder.UseSqlite(dbPath);
//            //optionsBuilder.UseSqlite("Filename=TestDatabase.db", options =>
//            //{
//            //    options.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
//            //});
//            base.OnConfiguring(optionsBuilder);
//        }
//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
//            // Map table names
//            //modelBuilder.Entity<PersonEntity>().ToTable("Persons", "BDM");
//            //modelBuilder.Entity<PersonEntity>(entity =>
//            //{
//            //    entity.HasKey(e => e.Id);
//            //    //entity.HasIndex(e => e.Title).IsUnique();
//            //    //entity.Property(e => e.DateTimeAdd).HasDefaultValueSql("CURRENT_TIMESTAMP");
//            //});
//            base.OnModelCreating(modelBuilder);
//        }
//    }
//}
