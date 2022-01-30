namespace api.Database;

using api.Models;

using Microsoft.EntityFrameworkCore;

public class PersistenceContext:DbContext
{
  public DbSet<Weapon> Weapons { get; set; } = null!;
  public DbSet<WeaponTemplate> WeaponTemplates { get; set; } = null!;
  public DbSet<Change<Weapon>> WeaponChanges { get; set; } = null!;

  public PersistenceContext(DbContextOptions options)
           : base(options) 
  {

  }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
      modelBuilder.Entity<Created<Weapon>>();
      //   .HasOne(created => created.gameObjectTemplate) 
      //   .WithMany();
      //   ;
      // modelBuilder.Entity<Created<Weapon>>()
      //   .HasOne(created => created.GameObjectInstance)
      //   .WithMany(weapon => weapon.History); 
      // modelBuilder.Entity<Destroyed<Weapon>>();
      // modelBuilder.Entity<Modifier<Weapon>>();
      // modelBuilder.Entity<Exchanged<Weapon>>();
      
    // base.OnModelCreating(modelBuilder);
  }
}
