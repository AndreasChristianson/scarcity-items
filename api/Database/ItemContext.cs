namespace api;

using Microsoft.EntityFrameworkCore;

public class ItemContext : DbContext
{
    public DbSet<Equipment> Equipment { get; init; }
    public ItemContext(DbContextOptions options)
             : base(options)
    {
    }

}
