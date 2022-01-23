using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace gwsApi.Models
{
    public class gwsContext : DbContext
    {
        public gwsContext(DbContextOptions<gwsContext> options)
            : base(options)
        {
            
        }
        public DbSet<gwsItem> gwsItems { get; set; } = null!;

        //  protected override void OnModelCreating(ModelBuilder modelBuilder)
        //  {
        //      modelBuilder.Entity<gwsItem>().HasData(new gwsItem("India","LIC",1000));
        //      modelBuilder.Entity<gwsItem>().HasData(new gwsItem("India","LIC",1000));
        //      modelBuilder.Entity<gwsItem>().HasData(new gwsItem("US","LIC",1000));
        //      modelBuilder.Entity<gwsItem>().HasData(new gwsItem("US","LIC",1000));
        //      modelBuilder.Entity<gwsItem>().HasData(new gwsItem("UK","LIC",1000));
        //  }
    }
}