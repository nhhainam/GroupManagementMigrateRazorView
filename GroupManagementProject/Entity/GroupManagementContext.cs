using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace GroupManagementProject.Entity;

public partial class GroupManagementContext : DbContext
{
    public GroupManagementContext()
    {
    }

    public GroupManagementContext(DbContextOptions<GroupManagementContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Group> Groups { get; set; }

    public virtual DbSet<Invitation> Invitations { get; set; }

    public virtual DbSet<Issue> Issues { get; set; }

    public virtual DbSet<Member> Members { get; set; }

    public virtual DbSet<MemberIssue> MemberIssues { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server =NAM\\SQLEXPRESS; database =GroupManagement;uid=sa;pwd=123;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Group>(entity =>
        {
            entity.HasKey(e => e.GroupId).HasName("PK__Groups__88C1034D49403D87");

            entity.Property(e => e.GroupId).HasColumnName("groupId");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.GroupName)
                .HasMaxLength(255)
                .HasColumnName("groupName");
            entity.Property(e => e.Purpose)
                .HasMaxLength(255)
                .HasColumnName("purpose");
            entity.Property(e => e.State).HasColumnName("state");
            entity.Property(e => e.Status).HasColumnName("status");
        });

        modelBuilder.Entity<Invitation>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.GroupId }).HasName("PK__Invitati__03160CCB5D5EB5D8");

            entity.ToTable("Invitation");

            entity.Property(e => e.UserId).HasColumnName("userId");
            entity.Property(e => e.GroupId).HasColumnName("groupId");
            entity.Property(e => e.Status).HasColumnName("status");

            entity.HasOne(d => d.Group).WithMany(p => p.Invitations)
                .HasForeignKey(d => d.GroupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Invitatio__group__276EDEB3");

            entity.HasOne(d => d.User).WithMany(p => p.Invitations)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Invitatio__userI__267ABA7A");
        });

        modelBuilder.Entity<Issue>(entity =>
        {
            entity.HasKey(e => e.IssueId).HasName("PK__Issues__749E806CECCE95EA");

            entity.Property(e => e.IssueId).HasColumnName("issueId");
            entity.Property(e => e.Assignee).HasColumnName("assignee");
            entity.Property(e => e.Content)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("content");
            entity.Property(e => e.Creator).HasColumnName("creator");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.DueDate)
                .HasColumnType("datetime")
                .HasColumnName("dueDate");
            entity.Property(e => e.ProjectId).HasColumnName("projectId");
            entity.Property(e => e.StartDate)
                .HasColumnType("datetime")
                .HasColumnName("startDate");
            entity.Property(e => e.State).HasColumnName("state");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("title");

            entity.HasOne(d => d.AssigneeNavigation).WithMany(p => p.IssueAssigneeNavigations)
                .HasForeignKey(d => d.Assignee)
                .HasConstraintName("FK__Issues__assignee__1ED998B2");

            entity.HasOne(d => d.CreatorNavigation).WithMany(p => p.IssueCreatorNavigations)
                .HasForeignKey(d => d.Creator)
                .HasConstraintName("FK__Issues__creator__1FCDBCEB");

            entity.HasOne(d => d.Project).WithMany(p => p.Issues)
                .HasForeignKey(d => d.ProjectId)
                .HasConstraintName("FK__Issues__projectI__1DE57479");
        });

        modelBuilder.Entity<Member>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.GroupId }).HasName("PK__Members__03160CEB8AD7E03D");

            entity.Property(e => e.UserId).HasColumnName("userID");
            entity.Property(e => e.GroupId).HasColumnName("groupId");
            entity.Property(e => e.RoleId).HasColumnName("roleId");
            entity.Property(e => e.State).HasColumnName("state");
            entity.Property(e => e.Status).HasColumnName("status");

            entity.HasOne(d => d.Group).WithMany(p => p.Members)
                .HasForeignKey(d => d.GroupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Members__groupId__173876EA");

            entity.HasOne(d => d.Role).WithMany(p => p.Members)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__Members__roleId__182C9B23");

            entity.HasOne(d => d.User).WithMany(p => p.Members)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Members__userID__164452B1");
        });

        modelBuilder.Entity<MemberIssue>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.IssueId }).HasName("PK__MemberIs__1CD3F4F9714FF3A8");

            entity.Property(e => e.UserId).HasColumnName("userId");
            entity.Property(e => e.IssueId).HasColumnName("issueId");
            entity.Property(e => e.Status).HasColumnName("status");

            entity.HasOne(d => d.Issue).WithMany(p => p.MemberIssues)
                .HasForeignKey(d => d.IssueId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__MemberIss__issue__239E4DCF");

            entity.HasOne(d => d.User).WithMany(p => p.MemberIssues)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__MemberIss__userI__22AA2996");
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(e => e.ProjectId).HasName("PK__Projects__11F14DA5033B30BA");

            entity.Property(e => e.ProjectId).HasColumnName("projectId");
            entity.Property(e => e.Createdate)
                .HasColumnType("datetime")
                .HasColumnName("createdate");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.GroupId).HasColumnName("groupId");
            entity.Property(e => e.ProjectName)
                .HasMaxLength(255)
                .HasColumnName("projectName");
            entity.Property(e => e.Status).HasColumnName("status");

            entity.HasOne(d => d.Group).WithMany(p => p.Projects)
                .HasForeignKey(d => d.GroupId)
                .HasConstraintName("FK__Projects__groupI__1B0907CE");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Roles__CD98462AD5A92FE9");

            entity.Property(e => e.RoleId).HasColumnName("roleId");
            entity.Property(e => e.RoleName)
                .HasMaxLength(255)
                .HasColumnName("roleName");
            entity.Property(e => e.Status).HasColumnName("status");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__CB9A1CDF5975BAA6");

            entity.Property(e => e.UserId).HasColumnName("userID");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.Fullname)
                .HasMaxLength(255)
                .HasColumnName("fullname");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.Username)
                .HasMaxLength(255)
                .HasColumnName("username");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
