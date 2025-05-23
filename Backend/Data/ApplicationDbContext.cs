using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {

        public ApplicationDbContext(DbContextOptions options)
        : base(options)
        {

        }

        public DbSet<Gemaelde> Gemaelder { get; set; }

        public DbSet<Kommentar> Kommentare { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            List<IdentityRole> roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Name = "User",
                    NormalizedName = "USER"
                }
            };

            builder.Entity<IdentityRole>().HasData(roles);

            // Das ist neu ↓
            builder.Entity<Gemaelde>().HasData(
                new Gemaelde
                {
                    Id = 1,
                    Name = "Mona Lisa"
                },
                new Gemaelde
                {
                    Id = 2,
                    Name = "Scream"
                }, new Gemaelde
                {
                    Id = 3,
                    Name = "Letztes Abendmal"
                }, new Gemaelde
                {
                    Id = 4,
                    Name = "Sternennacht"
                }, new Gemaelde
                {
                    Id = 5,
                    Name = "Creation of Adam"
                }, new Gemaelde
                {
                    Id = 6,
                    Name = "The Kiss"
                }, new Gemaelde
                {
                    Id = 7,
                    Name = "The Girl"
                }, new Gemaelde
                {
                    Id = 8,
                    Name = "Venus"
                }
                );
        }
    }
}

