using Microsoft.EntityFrameworkCore;
using QimiaProject.DataAccess.Entities;

namespace QimiaProject.DataAccess;

public class QimiaProjectDbContext : DbContext
{
    public QimiaProjectDbContext(
        DbContextOptions<QimiaProjectDbContext> contextOptions ) : base( contextOptions)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<Request> Requests { get; set; }
    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

}
