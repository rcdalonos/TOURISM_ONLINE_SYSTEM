using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace STANDARDS_AND_SERVICES_DB_SYSTEM.Models;

public partial class StandardsDBContext : DbContext
{
    public StandardsDBContext()
    {
    }

    public StandardsDBContext(DbContextOptions<StandardsDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<businessprofile> businessprofiles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server= CTO-CRIS\\SQLEXPRESS03;Initial Catalog=StandardsDB;Integrated Security=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<businessprofile>(entity =>
        {
            entity.Property(e => e.id).ValueGeneratedNever();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
