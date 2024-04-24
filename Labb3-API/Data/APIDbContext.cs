using Labb3_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Labb3_API.Data
{
    public class APIDbContext : DbContext
    {
        public APIDbContext(DbContextOptions<APIDbContext> options) : base(options)
        {

        }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Interest> Interests { get; set; }
        //public DbSet<Link> Links { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Interest>()
        //        .HasOne(p => p.Person)
        //        .WithMany(i => i.Interests)
        //        .HasForeignKey(p => p.FkPersonId)
        //        .OnDelete(DeleteBehavior.Restrict);

        //    modelBuilder.Entity<Link>()
        //        .HasOne(i => i.Interest)
        //        .WithMany(l => l.Links)
        //        .HasForeignKey(i => i.FkInterestId)
        //        .OnDelete(DeleteBehavior.Restrict);
        //}
    }
}
