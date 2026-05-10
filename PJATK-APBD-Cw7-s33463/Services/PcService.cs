using Microsoft.EntityFrameworkCore;
using PJATK_APBD_Cw7_s33463.DTOs;
using PJATK_APBD_Cw7_s33463.Exceptions;
using PJATK_APBD_Cw7_s33463.Infrastructure;
using PJATK_APBD_Cw7_s33463.Models;

namespace PJATK_APBD_Cw7_s33463.Services;

public class PcService(DatabaseContext db) : IPcService
{
    public async Task<IEnumerable<PcDto>> GetAllPcsAsync(CancellationToken cancellationToken)
    {
        return await db.Pcs.Select(pc => new PcDto(
            pc.Id,
            pc.Name,
            pc.Weight,
            pc.Warranty,
            pc.CreatedAt,
            pc.Stock
        )).ToListAsync(cancellationToken);
    }
    
    public async Task<PcDetailsDto> GetPcByIdAsync(int pcId, CancellationToken cancellationToken)
    {
        return await db.Pcs
            .Where(pc => pc.Id == pcId)
            .Select(pc => new PcDetailsDto
            (
                pc.Id,
                pc.Name,
                pc.Weight,
                pc.Warranty,
                pc.CreatedAt,
                pc.Stock,
                pc.PcComponents.Select(c => new PcComponentsDto(
                    c.Amount,
                    Component: new ComponentDto(
                        c.ComponentCode,
                        c.Component.Name,
                        c.Component.Description,
                        Manufacturer: new ManufacturerDto
                        (
                            c.Component.ComponentManufacturerId,
                            c.Component.ComponentManufacture.Abbreviation,
                            c.Component.ComponentManufacture.FullName,
                            c.Component.ComponentManufacture.FoundationDate
                        ),
                        Type: new TypeDto(
                            c.Component.ComponentTypeId,
                            c.Component.ComponentType.Abbreviation,
                            c.Component.ComponentType.Name
                        )
                    )
                ))
            )).FirstOrDefaultAsync(cancellationToken)
            ?? throw new NotFoundException($"Pc with id {pcId} not found");
    }

    public async Task<PcDto> AddPcAsync(CreatePcRequest request, CancellationToken cancellationToken)
    {
        var pc = new PC
        {
            Name = request.Name,
            Weight = request.Weight,
            Warranty = request.Warranty,
            CreatedAt = request.CreatedAt,
            Stock = request.Stock,
        };

        db.Add(pc);
        await db.SaveChangesAsync(cancellationToken);
        
        return new PcDto(pc.Id, pc.Name, pc.Weight, pc.Warranty, pc.CreatedAt, pc.Stock);
    }

    public async Task UpdatePcAsync(int id, UpdatePcRequest request, CancellationToken cancellationToken)
    {
        var pc = await db.Pcs.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        if (pc is null)
        {
            throw new NotFoundException($"Pc with id {id} not found");
        }
        
        pc.Name = request.Name;
        pc.Weight = request.Weight;
        pc.Warranty = request.Warranty;
        pc.CreatedAt = request.CreatedAt;
        pc.Stock = request.Stock;
        
        await db.SaveChangesAsync(cancellationToken);
    }

    public async Task DeletePcAsync(int id, CancellationToken cancellationToken)
    {
        var pc = await db.Pcs.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        if (pc is null)
        {
            throw new NotFoundException($"Pc with id {id} not found");
        }
        
        db.Pcs.Remove(pc);
        await db.SaveChangesAsync(cancellationToken);
    }
}