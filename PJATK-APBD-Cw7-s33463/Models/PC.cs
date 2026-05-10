using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PJATK_APBD_Cw7_s33463.Models;

[Table("PC")]
public class PC
{
    [Key]
    public int Id { get; set; }
    
    [MaxLength(50)]
    public string Name { get; set; } = string.Empty;
    
    public float Weight { get; set; }
    
    public int Warranty { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    public int Stock { get; set; }

    public IEnumerable<PCComponent> PcComponents { get; set; } = [];
}