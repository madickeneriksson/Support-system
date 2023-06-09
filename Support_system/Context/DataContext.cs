﻿

using Microsoft.EntityFrameworkCore;
using Support_system.Models.Entities;

namespace Support_system.Context
{
    internal class DataContext : DbContext
    {
        private readonly string _connectionstring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Conle\OneDrive\Dokument\sql_support_system_db_one.mdf;Integrated Security=True;Connect Timeout=30";


        #region context and overrides
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(_connectionstring);
        }
        #endregion

        public DbSet<CaseEntity> Cases { get; set; } = null!;
        public DbSet<CustomerEntity> Customers { get; set; } = null!;
        public DbSet<AddressEntity> Addresses { get; set; } = null!;
        public DbSet<CommentEntity> Comments { get; set; }


    }
}
