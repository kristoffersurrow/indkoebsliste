﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Eksamensopgave2f.Models
{
    public partial class Eksamensopgave2DBContext : DbContext
    {
        public Eksamensopgave2DBContext()
        {
        }

        public Eksamensopgave2DBContext(DbContextOptions<Eksamensopgave2DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<GroceryTable> GroceryTable { get; set; }
        public virtual DbSet<Users> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GroceryTable>(entity =>
            {
                entity.Property(e => e.Checkmark).HasColumnName("checkmark");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.LastLogin).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(20);
            });
        }
    }
}
