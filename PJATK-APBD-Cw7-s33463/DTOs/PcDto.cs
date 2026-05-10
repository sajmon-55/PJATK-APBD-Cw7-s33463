namespace PJATK_APBD_Cw7_s33463.DTOs;

public record PcDto(
    int Id,
    string Name,
    float Weight,
    int Warranty,
    DateTime Date,
    int Stock
);