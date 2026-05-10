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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ComponentType>().HasData(
            new ComponentType { Id = 1, Abbreviation = "CPU", Name = "Processor" },
            new ComponentType { Id = 2, Abbreviation = "GPU", Name = "Graphics Card" },
            new ComponentType { Id = 3, Abbreviation = "RAM", Name = "Memory" }
        );

        modelBuilder.Entity<ComponentManufacture>().HasData(
            new ComponentManufacture { Id = 1, Abbreviation = "AMD", FullName = "Advanced Micro Devices", FoundationDate = new DateOnly(1969, 5, 1) },
            new ComponentManufacture { Id = 2, Abbreviation = "NV", FullName = "NVIDIA Corporation", FoundationDate = new DateOnly(1993, 4, 5) },
            new ComponentManufacture { Id = 3, Abbreviation = "COR", FullName = "Corsair Gaming Inc.", FoundationDate = new DateOnly(1994, 1, 1) }
        );

        modelBuilder.Entity<Component>().HasData(
            new Component { 
                Code = "CPU0000001", 
                Name = "Ryzen 7 7800X3D", 
                Description = "8-core gaming processor", 
                ComponentManufacturerId = 1, 
                ComponentTypeId = 1 
            },
            new Component { 
                Code = "GPU0000001", 
                Name = "RTX 4080 Super", 
                Description = "High-end gaming graphics card", 
                ComponentManufacturerId = 2, 
                ComponentTypeId = 2 
            },
            new Component { 
                Code = "RAM0000001", 
                Name = "Corsair Vengeance DDR5 16GB", 
                Description = "DDR5 RAM module 16GB", 
                ComponentManufacturerId = 3, 
                ComponentTypeId = 3 
            }
        );

        modelBuilder.Entity<PC>().HasData(
            new PC { Id = 1, Name = "Gaming Beast X", Weight = 12.5F, Warranty = 36, CreatedAt = new DateTime(2026, 5, 8, 9, 0, 0), Stock = 5 },
            new PC { Id = 2, Name = "Office Mini Pro", Weight = 4.2F, Warranty = 24, CreatedAt = new DateTime(2026, 4, 15, 13, 30, 0), Stock = 12 }
        );

        modelBuilder.Entity<PCComponent>().HasData(
            new PCComponent { PCId = 1, ComponentCode = "CPU0000001", Amount = 1 },
            new PCComponent { PCId = 1, ComponentCode = "GPU0000001", Amount = 1 },
            new PCComponent { PCId = 1, ComponentCode = "RAM0000001", Amount = 2 }
        );
    }
}