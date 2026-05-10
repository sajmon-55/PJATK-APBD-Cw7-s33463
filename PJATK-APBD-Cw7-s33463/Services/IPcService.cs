using PJATK_APBD_Cw7_s33463.DTOs;

namespace PJATK_APBD_Cw7_s33463.Services;

public interface IPcService
{
    Task<IEnumerable<PcDto>> GetAllPcsAsync(CancellationToken cancellationToken);
    Task<PcDetailsDto> GetPcByIdAsync(int pcId, CancellationToken cancellationToken);
    Task<PcDto> AddPcAsync(CreatePcRequest request, CancellationToken cancellationToken);
    Task UpdatePcAsync(int id, UpdatePcRequest request, CancellationToken cancellationToken);
    Task DeletePcAsync(int id, CancellationToken cancellationToken);
}