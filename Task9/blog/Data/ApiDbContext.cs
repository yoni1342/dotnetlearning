using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using blog.Entities;

namespace blog.Data
{
    public class ApiDbContext : DbContext
    {

        public DbSet<Post> posts { get; set; }
        public DbSet<Comment> comments { get; set; }

        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Post>(entity =>{
                entity.HasMany(e => e.Comments)
                    .WithOne(e => e.Post)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }

    }

}