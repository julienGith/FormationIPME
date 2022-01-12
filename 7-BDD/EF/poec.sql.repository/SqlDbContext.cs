using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using poec.sql.dtos;

namespace poec.sql.repository;

public class SqlDbContext : DbContext
{

    private string ConnectionString { get; }

    public SqlDbContext(string connectionString)
    {
        ConnectionString = connectionString;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        optionsBuilder.UseSqlServer(ConnectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        EntityTypeBuilder<UserSqlDto> entityTypeBuilder = modelBuilder.Entity<UserSqlDto>();

        //[Column("Pseudo")] //Si nom de colonne différent
        //entityTypeBuilder.Property(u => u.Login).HasColumnName("Pseudo");

        //si pas de clé
        //entityTypeBuilder.HasNoKey();

        //équivalent à [Table("User")] dans le SqlDto
        //entityTypeBuilder.ToTable("User");
        //équivalent à [Key] dans le SqlDto
        //userCatalog.HasKey(u => u.UserId);
    }

    public override DbSet<TEntity> Set<TEntity>()
    {
        ChangeTracker.LazyLoadingEnabled = false;
        ChangeTracker.AutoDetectChangesEnabled = false;
        ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

        return base.Set<TEntity>();
    }
}