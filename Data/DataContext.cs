using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversityServer.Entities;

namespace UniversityServer.Data
{
    public class DataContext : DbContext
    {
        public DataContext( DbContextOptions options) : base(options)
        {
        }

        public DbSet<AppUser> Users { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Schedule> Schedule { get; set; }
        public DbSet<UserCourse> UserCourse { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //builder.Entity<AppUser>()
            //    .HasMany(ur => ur.UserRoles)
            //    .WithOne(u => u.User)
            //    .HasForeignKey(ur => ur.UserId)
            //    .IsRequired();

            //builder.Entity<AppRole>()
            //    .HasMany(ur => ur.UserRoles)
            //    .WithOne(u => u.Role)
            //    .HasForeignKey(ur => ur.RoleId)
            //    .IsRequired();


            builder.Entity<UserCourse>()
                .HasKey(k => new { k.UserId, k.CourseId });

            //builder.Entity<AppUser>()
            //    .HasOne(s => s.Id)
            //    .WithMany(l => l.LikedUsers)
            //    .HasForeignKey(s => s.SourceUserId)
            //    .OnDelete(DeleteBehavior.Cascade);

            //builder.Entity<UserCourse>()
            //    .HasOne(s => s.UserId)
            //    .WithMany(l => l.CourseId)
            //    .HasForeignKey(s => s.LikedUserId)
            //    .OnDelete(DeleteBehavior.Cascade);

            //builder.Entity<Message>()
            //    .HasOne(u => u.Recipient)
            //    .WithMany(m => m.MessagesReceived)
            //    .OnDelete(DeleteBehavior.Restrict);

            //builder.Entity<Message>()
            //    .HasOne(u => u.Sender)
            //    .WithMany(m => m.MessagesSent)
            //    .OnDelete(DeleteBehavior.Restrict);

        }
    }

}

