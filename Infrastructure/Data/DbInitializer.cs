using Core.models;
using Infrastructure.Data.Identity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Infrastructure.Data
{
    public class DbInitializer
    {
        private readonly ModelBuilder _modelBuilder;
        public DbInitializer(ModelBuilder builder)
        {
            _modelBuilder = builder;
        }
        public void Seed()
        {
            _modelBuilder.Entity<Transaction>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Note).HasColumnType("varchar").HasMaxLength(50).IsRequired();
                entity.Property(e => e.Ammount).HasColumnType("decimal(18,2)").HasMaxLength(40).IsRequired();
                entity.HasOne(e => e.Category)
                .WithMany(e => e.Transactions)
                .HasForeignKey(e => e.CategoryId);
            });

            _modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).HasColumnType("varchar").HasMaxLength(50).IsRequired();
                entity.Property(e => e.Color).HasColumnType("varchar").HasMaxLength(20).IsRequired();
                entity.HasOne<User>()
                .WithMany()
                .HasForeignKey(e => e.UserId) 
                .OnDelete(DeleteBehavior.Cascade);
                   
                

                entity.HasOne(e => e.Icon)
                .WithMany() 
                .HasForeignKey(e => e.IconId);
            });

            _modelBuilder.Entity<User>(entity => 
            {
                entity.HasKey(e => e.Id);
            });

        }
    }
}
