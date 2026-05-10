using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PJATK_APBD_Cw7_s33463.Models;

[Table("ComponentManufacture")]
public class ComponentManufacture
{
    [Key]
    public int Id { get; set; }
    
    [MaxLength(30)]
    public string Abbreviation { get; set; } = string.Empty;
    
    [MaxLength(300)]
    public string FullName { get; set; } =  string.Empty;
    
    [Column(TypeName = "date")]
    public DateOnly FoundationDate { get; set; }

    public IEnumerable<Component> Components { get; set; } = [];
}