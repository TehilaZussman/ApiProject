using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EX2.Models;

public partial class TasksDbContext : DbContext
{
    public TasksDbContext()
    {
    }

    public TasksDbContext(DbContextOptions<TasksDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<Tasks> Tasks { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<AttachPath> AttachPath { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Project>(entity =>
        {
            entity.ToTable("project");

            entity.HasKey(e => e.Id);
            //entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ProjectName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("projectName");
        });

        modelBuilder.Entity<Tasks>(entity =>
        {
            entity.ToTable("tasks");
            entity.HasKey(e => e.Id);
            //entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Date)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("date");
            entity.Property(e => e.ProjectId).HasColumnName("projectId");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("status");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("title");
            entity.Property(e => e.UserId).HasColumnName("userId");

            entity.HasOne(d => d.Project).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.ProjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_taskProject");

            entity.HasOne(d => d.User).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_taskUser");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("users");
            entity.HasKey(e => e.Id);
            //entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FirstName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("firstName");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("lastName");
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("phone");
        });

        modelBuilder.Entity <Attachments>(entity =>
        {
            entity.ToTable("attachments");
            entity.HasKey(e => e.AttachId);

            entity.Property(e => e.AttachId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("AttachId");
            entity.Property(e => e.AttachName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("AttachName");
            entity.Property(e => e.AttachPath)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("AttachPath");
            entity.Property(e => e.UploadDate)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("UploadDate");

        })

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
