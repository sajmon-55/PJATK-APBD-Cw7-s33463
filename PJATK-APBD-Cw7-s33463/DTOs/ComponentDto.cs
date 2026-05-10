namespace PJATK_APBD_Cw7_s33463.DTOs;

public record ComponentDto(
    string Code,
    string Name,
    string Description,
    ManufacturerDto Manufacturer,
    TypeDto Type
);