using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ExchangeRateChange.Entity.Models;
using ExchangeRateChange.Entity.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRateChange.Infrastructure.Context
{
    public class ExchangeRateChangeContext : IdentityDbContext<AppUser, AppRole, string>
    {
        private readonly IConfiguration _configuration;
        public const string DEFAULT_SCHEMA = "dbo";

        public ExchangeRateChangeContext()
        {

        }

        public ExchangeRateChangeContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connStr = "Server=BATUHAN\\SQLEXPRESS;Initial Catalog=ExchangeRateChange;MultipleActiveResultSets=True;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;";
                optionsBuilder.UseSqlServer(connStr);
            }

        }
        public DbSet<Exchange> Exchanges { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder); // We need to add this line because we inherit from IdentityDbContext. If we are not using IdentityDbContext we do not need to add this line.
        }


        //THIS WILL WORK BEFORE ALL MY SAVE CHANGES CALLS.
        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }

        private void PrepareAddedEntites(IEnumerable<BaseEntity> entities)
        {
            foreach (var entity in entities)
            {
                if (entity.CreateDate == DateTime.MinValue)
                    entity.CreateDate = DateTime.Now;
            }
        }

    }
}
