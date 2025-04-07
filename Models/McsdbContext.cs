using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MCS.Models;

public partial class McsdbContext : DbContext
{
    public McsdbContext()
    {
    }

    public McsdbContext(DbContextOptions<McsdbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Booking> Bookings { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<MovingCompany> MovingCompanies { get; set; }

    public virtual DbSet<QuoteRequest> QuoteRequests { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=RAHEL\\SQLEXPRESS;Database=MCSDB;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Booking>(entity =>
        {
            entity.HasKey(e => e.BookingId).HasName("PK__Booking__C6D03BCD9A6AA127");

            entity.ToTable("Booking");

            entity.Property(e => e.BookingId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("bookingId");
            entity.Property(e => e.CustomerId).HasColumnName("customerId");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.ServiceId).HasColumnName("serviceId");

            entity.HasOne(d => d.Customer).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__Booking__custome__4316F928");

            entity.HasOne(d => d.Service).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.ServiceId)
                .HasConstraintName("FK__Booking__service__440B1D61");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Customer__B611CB7D28F8DFCB");

            entity.ToTable("Customer");

            entity.HasIndex(e => e.Email, "UQ__Customer__AB6E6164DFD2E194").IsUnique();

            entity.Property(e => e.CustomerId)
                .ValueGeneratedNever()
                .HasColumnName("customerId");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("phone");
        });

        modelBuilder.Entity<MovingCompany>(entity =>
        {
            entity.HasKey(e => e.CompanyName).HasName("PK__MovingCo__B3107417180C431F");

            entity.ToTable("MovingCompany");

            entity.Property(e => e.CompanyName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("companyName");
            entity.Property(e => e.Location)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("location");
        });

        modelBuilder.Entity<QuoteRequest>(entity =>
        {
            entity.HasKey(e => e.RequestId).HasName("PK__QuoteReq__E3C5DE3123ED1CB6");

            entity.ToTable("QuoteRequest");

            entity.Property(e => e.RequestId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("requestId");
            entity.Property(e => e.CustomerId).HasColumnName("customerId");
            entity.Property(e => e.DropoffLocation)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("dropoffLocation");
            entity.Property(e => e.MovingDate).HasColumnName("movingDate");
            entity.Property(e => e.PickupLocation)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("pickupLocation");

            entity.HasOne(d => d.Customer).WithMany(p => p.QuoteRequests)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__QuoteRequ__custo__403A8C7D");
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => e.ServiceId).HasName("PK__Service__455070DF9C731ED4");

            entity.ToTable("Service");

            entity.Property(e => e.ServiceId)
                .ValueGeneratedNever()
                .HasColumnName("serviceId");
            entity.Property(e => e.CompanyName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("companyName");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.ServiceName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("serviceName");

            entity.HasOne(d => d.CompanyNameNavigation).WithMany(p => p.Services)
                .HasForeignKey(d => d.CompanyName)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Service__company__398D8EEE");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
