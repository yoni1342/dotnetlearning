using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PostgresDb.Models;

namespace PostgresDb.Data

{
    public class ApiDbContext : DbContext
    {
        // Specify the tables we want to use in our case we have 3 entities so we need 3 tables
        public DbSet<Team> Teams { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<DriverMedia> DriverMedias { get; set; }

        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // This is required for Identity models

            // One to many relationship between Team and Driver
            modelBuilder.Entity<Driver>(entity => {
                // 1-many
                entity.HasOne(t => t.Team)
                .WithMany(d => d.Drivers)
                .HasForeignKey(t => t.TeamId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Driver_Team");

                //1-1
                entity.HasOne(dm => dm.DriverMedia)
                .WithOne(d => d.Driver)
                .HasForeignKey<DriverMedia>(dm => dm.DriverId);
            });  

            // // One to one
            // modelBuilder.Entity<Team>(entity =>{
            //     entity.HasMany(d => d.Drivers)
            //     .WithOne(t => t.Team)
            //     .OnDelete(DeleteBehavior.Restrict)
            //     .HasConstraintName("FK_Team_Driver");
            // })
        }
    }
}