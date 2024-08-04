using Core.interfaces;
using Core.models;
using Infrastructure.Data.Identity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;


namespace Infrastructure.Data
{
    public class MoneyTrackerDbContext : IdentityDbContext<User>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public MoneyTrackerDbContext(DbContextOptions<MoneyTrackerDbContext> options, IHttpContextAccessor httpContextAccessor) : base(options) 
        {
            this._httpContextAccessor = httpContextAccessor;
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Icon> Icons { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            new DbInitializer(builder).Seed();
        }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries().Where(e => e.Entity is IAuditableEntity && (
              e.State == EntityState.Added || e.State == EntityState.Modified));
            foreach(var entityEntry in entries)
            {
                if (entityEntry.State == EntityState.Added)
                {
                    ((IAuditableEntity)entityEntry.Entity).CreatedAt = DateTime.UtcNow;
                    ((IAuditableEntity)entityEntry.Entity).CreatedBy = this._httpContextAccessor.HttpContext?.User?.Identity?.Name ?? "MyApp";
                }
                else
                {
                    Entry((IAuditableEntity)entityEntry.Entity).Property(p => p.CreatedAt).IsModified = false;
                    Entry((IAuditableEntity)entityEntry.Entity).Property(p => p.CreatedBy).IsModified = false;
                    ((IAuditableEntity)entityEntry.Entity).lastModifiedAt = DateTime.UtcNow;
                    ((IAuditableEntity)entityEntry.Entity).lastModifiedBy = this._httpContextAccessor.HttpContext?.User?.Identity?.Name ?? "MyApp";
                }
            }
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
