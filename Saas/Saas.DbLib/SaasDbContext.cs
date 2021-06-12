using Microsoft.EntityFrameworkCore;
using Saas.Model.Core;
using Saas.Model.Service;
using System;

namespace Saas.DbLib
{
    public class SaasDbContext : DbContext
    {
        private readonly string _connectionString;
        public SaasDbContext(string connectionString) //: base(GetOptions(connectionString))
        {
            _connectionString = connectionString;
            this.Database.EnsureCreated();
        }
        //public SaasDbContext(DbContextOptions<SaasDbContext> options)
        //    : base(options)
        //{
            
        //}

        //private static DbContextOptions GetOptions(string connectionString)
        //{
        //    return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), connectionString).Options;
        //}

        //public SaasDbContext(DbContextOptions<SaasDbContext> options)
        //    : options.UseSqlServer("")
        //{
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserModel>()
                .ToTable("Users")                
                .HasKey(x => x.UserId)
                .HasName("PrimaryKey_UserId");

            modelBuilder.Entity<ServiceReference>()
                .ToTable("Services")
                .HasKey(x => x.ServiceReferenceId)
                .HasName("PrimaryKey_ServiceReferenceId");

            modelBuilder.Entity<ScriptReference>()
                .ToTable("Scripts")
                .HasKey(x => x.ScriptId)
                .HasName("PrimaryKey_ScriptId");

            modelBuilder.Entity<ItemModel>()
                .ToTable("Items")
                .HasKey(x => x.ItemId)
                .HasName("PrimaryKey_ItemId");

        }

        //public virtual DbSet<BaseScript> BaseScript { get; set; }
        public virtual DbSet<UserModel> UserModel { get; set; }
        public virtual DbSet<ServiceReference> ServiceReference { get; set; }
        public virtual DbSet<ScriptReference> ScriptReference { get; set; }
        public virtual DbSet<ItemModel> itemModel { get; set; }


    }
}
