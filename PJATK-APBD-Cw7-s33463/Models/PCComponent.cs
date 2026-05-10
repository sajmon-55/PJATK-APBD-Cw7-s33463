using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PJATK_APBD_Cw7_s33463.Models;

[Table("PCComponent"), PrimaryKey(nameof(PCId), nameof(ComponentCode))]
public class PCComponent
{
    public int PCId { get; set; }
    
    [Column(TypeName = "char(10)")]
    public string ComponentCode { get; set; } = string.Empty;
    
    public int Amount { get; set; }
}