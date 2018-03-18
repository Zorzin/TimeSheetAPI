using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TimeSheetAPI.Models;

namespace TimeSheetAPI.Data
{
    public class DBContext : IdentityDbContext<User>
    {
        public DBContext(DbContextOptions<DBContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // PostgreSQL uses the public schema by default - not dbo.
            builder.HasDefaultSchema("dbo");
            base.OnModelCreating(builder);


            builder.Entity<EntrySummary>()
                .HasKey(bc => new { bc.EntryId, bc.SummaryId });

            builder.Entity<EntrySummary>()
                .HasOne(bc => bc.Entry)
                .WithMany(b => b.EntrySummaries)
                .HasForeignKey(bc => bc.EntryId);

            builder.Entity<EntrySummary>()
                .HasOne(bc => bc.Summary)
                .WithMany(c => c.EntrySummaries)
                .HasForeignKey(bc => bc.SummaryId);

        }

        public DbSet<Summary> Summaries { get; set; }
        public DbSet<Entry> Entries { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<EntrySummary> EntrySummaries { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
