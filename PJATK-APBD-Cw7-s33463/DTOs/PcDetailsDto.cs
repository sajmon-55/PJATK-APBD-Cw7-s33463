namespace PJATK_APBD_Cw7_s33463.DTOs;

public record PcDetailsDto(
    int Id,
    string Name,
    float Weight,
    int Warranty,
    DateTime CreatedAt,
    int Stock,
    IEnumerable<PcComponentsDto> Components
);