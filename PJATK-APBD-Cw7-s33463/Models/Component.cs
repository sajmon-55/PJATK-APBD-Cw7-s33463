using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PJATK_APBD_Cw7_s33463.Models;

[Table("Component")]
public class Component
{
    [Key, Column(TypeName = "char(10)")]
    public string Code { get; set; } = string.Empty;
    
    [MaxLength(300)]
    public string Name { get; set; } = string.Empty;
    
    public string Description { get; set; } =  string.Empty;
    
    public int ComponentManufacturerId { get; set; }
    
    public int ComponentTypeId { get; set; }

    public IEnumerable<PCComponent> PcComponents { get; set; } = [];

    [ForeignKey(nameof(ComponentManufacturerId))]
    public ComponentManufacture ComponentManufacture { get; set; } = null!;
    
    [ForeignKey(nameof(ComponentTypeId))]
    public ComponentType ComponentType { get; set; } = null!;
}