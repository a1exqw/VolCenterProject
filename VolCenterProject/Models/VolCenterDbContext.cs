using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace VolCenterProject.Models;

public partial class VolCenterDbContext : DbContext
{
    public VolCenterDbContext()
    {
    }

    public VolCenterDbContext(DbContextOptions<VolCenterDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<EventRegistration> EventRegistrations { get; set; }

    public virtual DbSet<EventStatus> EventStatuses { get; set; }

    public virtual DbSet<RegistrationStatus> RegistrationStatuses { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=volCenter_db;Username=postgres;Password=1111");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("categories_pkey");

            entity.ToTable("categories");

            entity.HasIndex(e => e.CategoryName, "categories_category_name_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(100)
                .HasColumnName("category_name");
        });

        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("events_pkey");

            entity.ToTable("events");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.EventDate).HasColumnName("event_date");
            entity.Property(e => e.EventName)
                .HasMaxLength(200)
                .HasColumnName("event_name");
            entity.Property(e => e.Category).HasColumnName("id_category");
            entity.Property(e => e.IdCoordinator).HasColumnName("id_coordinator");
            entity.Property(e => e.IdStatus).HasColumnName("id_status");
            entity.Property(e => e.Location)
                .HasMaxLength(200)
                .HasColumnName("location");
            entity.Property(e => e.VolunteersNeeded).HasColumnName("volunteers_needed");

            entity.HasOne(d => d.IdCategoryNavigation).WithMany(p => p.Events)
                .HasForeignKey(d => d.Category)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("events_id_category_fkey");

            entity.HasOne(d => d.IdCoordinatorNavigation).WithMany(p => p.Events)
                .HasForeignKey(d => d.IdCoordinator)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("events_id_coordinator_fkey");

            entity.HasOne(d => d.IdStatusNavigation).WithMany(p => p.Events)
                .HasForeignKey(d => d.IdStatus)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("events_id_status_fkey");
        });

        modelBuilder.Entity<EventRegistration>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("event_registrations_pkey");

            entity.ToTable("event_registrations");

            entity.HasIndex(e => new { e.IdEvent, e.IdVolunteer }, "event_registrations_id_event_id_volunteer_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdEvent).HasColumnName("id_event");
            entity.Property(e => e.IdStatus).HasColumnName("id_status");
            entity.Property(e => e.IdVolunteer).HasColumnName("id_volunteer");
            entity.Property(e => e.RegistrationDate).HasColumnName("registration_date");

            entity.HasOne(d => d.IdEventNavigation).WithMany(p => p.EventRegistrations)
                .HasForeignKey(d => d.IdEvent)
                .HasConstraintName("event_registrations_id_event_fkey");

            entity.HasOne(d => d.IdStatusNavigation).WithMany(p => p.EventRegistrations)
                .HasForeignKey(d => d.IdStatus)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("event_registrations_id_status_fkey");

            entity.HasOne(d => d.IdVolunteerNavigation).WithMany(p => p.EventRegistrations)
                .HasForeignKey(d => d.IdVolunteer)
                .HasConstraintName("event_registrations_id_volunteer_fkey");
        });

        modelBuilder.Entity<EventStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("event_statuses_pkey");

            entity.ToTable("event_statuses");

            entity.HasIndex(e => e.StatusName, "event_statuses_status_name_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.StatusName)
                .HasMaxLength(50)
                .HasColumnName("status_name");
        });

        modelBuilder.Entity<RegistrationStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("registration_statuses_pkey");

            entity.ToTable("registration_statuses");

            entity.HasIndex(e => e.StatusName, "registration_statuses_status_name_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.StatusName)
                .HasMaxLength(50)
                .HasColumnName("status_name");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("roles_pkey");

            entity.ToTable("roles");

            entity.HasIndex(e => e.RoleName, "roles_role_name_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.RoleName)
                .HasMaxLength(50)
                .HasColumnName("role_name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("users_pkey");

            entity.ToTable("users");

            entity.HasIndex(e => e.Email, "users_email_key").IsUnique();

            entity.HasIndex(e => e.Login, "users_login_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.FullName)
                .HasMaxLength(200)
                .HasColumnName("full_name");
            entity.Property(e => e.IdRole).HasColumnName("id_role");
            entity.Property(e => e.Login)
                .HasMaxLength(50)
                .HasColumnName("login");
            entity.Property(e => e.Pass)
                .HasMaxLength(100)
                .HasColumnName("pass");

            entity.HasOne(d => d.IdRoleNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdRole)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("users_id_role_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
