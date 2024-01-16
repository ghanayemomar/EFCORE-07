using EFCORE_07.Data.Config;
using EFCORE_07.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EFCORE_07.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Tweet> Tweets { get; set; } = null!;
        public DbSet<Comment> Comments { get; set; } = null!;


        //protected override void OnModelCreating(ModelBuilder modelBuilder) //--- second way ---
        //{
        //    base.OnModelCreating(modelBuilder);

        //    modelBuilder.Entity<User>().ToTable("tblUsers");
        //    modelBuilder.Entity<Tweet>().ToTable("tblTweets");
        //    modelBuilder.Entity<Comment>().ToTable("tblComments");
        //    modelBuilder.Entity<Comment>().Property(p => p.Id).HasColumnName("CommentId");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder) //--- third way ---
        {
            base.OnModelCreating(modelBuilder);
            //new UserEntityTypeConfiguration().Configure(modelBuilder.Entity<User>());
            //new CommentEntityTypeConfiguration().Configure(modelBuilder.Entity<Comment>());
            //new TweetEntityTypeConfiguration().Configure(modelBuilder.Entity<Tweet>()); --- first way for calling ---
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserEntityTypeConfiguration).Assembly); // --- second way --- 




        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = config.GetSection("constr").Value;

            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}