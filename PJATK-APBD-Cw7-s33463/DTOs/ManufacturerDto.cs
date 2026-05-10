namespace PJATK_APBD_Cw7_s33463.DTOs;

public record ManufacturerDto(
    int Id,
    string Abbreviation,
    string FullName,
    DateOnly FoundationDate
);