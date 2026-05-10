using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PJATK_APBD_Cw7_s33463.Models;

[Table("ComponentType")]
public class ComponentType
{
    [Key]
    public int Id { get; set; }
    
    [MaxLength(30)]
    public string Abbreviation { get; set; } = string.Empty;
    
    [MaxLength(150)]
    public string Name { get; set; } = string.Empty;
    
    public IEnumerable<Component> Components { get; set; } = [];
}