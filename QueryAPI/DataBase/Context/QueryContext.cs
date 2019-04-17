using ClassesDTO.DTO.MatDTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataBase.Context
{
    public class QueryContext : DbContext
    {
        public DbSet<MaterialDTO> Material { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source= SUPORTE.db");
        }

    }
}
