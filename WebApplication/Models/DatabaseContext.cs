namespace WebApplication.Models
{
  using System;
  using System.Data.Entity;

  public partial class DatabaseContext : DbContext
  {
    private static string DbConnectString = 
      @"data source={0}\SQLEXPRESS;initial catalog=ProductionDatabase;" + 
      @"integrated security=True;MultipleActiveResultSets=True;App=EntityFramework";


    public DatabaseContext()
        : base(string.Format(DbConnectString, Environment.MachineName))
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
