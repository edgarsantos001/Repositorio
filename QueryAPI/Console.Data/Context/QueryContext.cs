using ClassesDTO.DTO.MatDTO;
using ConData.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConData.Context
{
    public class QueryContext : DbContext
    {
        private static bool _create = false;
        public QueryContext() : base()
        {
            if (!_create)
            {
                _create = true;
                Database.EnsureDeleted();
                Database.EnsureCreated();
            }
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source= C:\sqlLite\SUPORTE.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MaterialConfiguration());
            modelBuilder.ApplyConfiguration(new ContentConfiguration());


        }
        public DbSet<MaterialDTO> Material { get; set; }

    }

}
