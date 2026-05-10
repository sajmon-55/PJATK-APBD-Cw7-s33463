using Microsoft.EntityFrameworkCore;
using PJATK_APBD_Cw7_s33463.Models;

namespace PJATK_APBD_Cw7_s33463.Infrastructure;

public class DatabaseContext(DbContextOptions opt) : DbContext(opt)
{
    public DbSet<PC> Pcs { get; set; }
    public DbSet<Component> Components { get; set; }
    public DbSet<PCComponent> PCComponents { get; set; }
    public DbSet<ComponentType> ComponentTypes { get; set; }
    public DbSet<ComponentManufacture> ComponentManufactures { get; set; }
}