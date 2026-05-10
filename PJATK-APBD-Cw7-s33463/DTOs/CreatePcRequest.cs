using System.ComponentModel.DataAnnotations;

namespace PJATK_APBD_Cw7_s33463.DTOs;

public record CreatePcRequest(
    [MaxLength(50)]
    string Name,
    float Weight,
    int Warranty,
    DateTime Date,
    int Stock
);