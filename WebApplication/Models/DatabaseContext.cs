namespace WebApplication.Models
{
  using System;
  using System.Data.Entity;
  using System.ComponentModel.DataAnnotations.Schema;
  using System.Linq;

  public partial class DatabaseContext : DbContext
  {
    public DatabaseContext()
        : base("name=DatabaseContext")
    {
      Configuration.ProxyCreationEnabled = true;
      Configuration.LazyLoadingEnabled = true;
    }

    public virtual DbSet<Project> Projects { get; set; }
    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<UserProject> UserProjects { get; set; }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Project>()
          .HasMany(e => e.UserProjects)
          .WithRequired(e => e.Project)
          .WillCascadeOnDelete(false);

      modelBuilder.Entity<User>()
          .Property(e => e.FirstName)
          .IsUnicode(false);

      modelBuilder.Entity<User>()
          .Property(e => e.LastName)
          .IsUnicode(false);

      modelBuilder.Entity<User>()
          .HasMany(e => e.UserProjects)
          .WithRequired(e => e.User)
          .WillCascadeOnDelete(false);
    }
  }
}
