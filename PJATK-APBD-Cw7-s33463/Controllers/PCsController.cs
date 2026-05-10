using Microsoft.AspNetCore.Mvc;
using PJATK_APBD_Cw7_s33463.DTOs;
using PJATK_APBD_Cw7_s33463.Exceptions;
using PJATK_APBD_Cw7_s33463.Models;
using PJATK_APBD_Cw7_s33463.Services;

namespace PJATK_APBD_Cw7_s33463.Controllers;

[ApiController]
[Route("api/pcs")]
public class PCsController(IPcService service) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        return Ok(await service.GetAllPcsAsync(cancellationToken));
    }

    [HttpGet("{id:int}/components")]
    public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
    {
        try
        {
            return Ok(await service.GetPcByIdAsync(id, cancellationToken));
        }
        catch (NotFoundException e) 
        {
            return NotFound(e.Message);
        }
    }
    
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreatePcRequest request, CancellationToken cancellationToken)
    {
        var pc = await service.AddPcAsync(request, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = pc.Id }, pc);
    }
    
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdatePcRequest request  ,CancellationToken cancellationToken)
    {
        try
        {
            await service.UpdatePcAsync(id, request ,cancellationToken);
            return NoContent();
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
    
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        try
        {
            await service.DeletePcAsync(id, cancellationToken);
            return NoContent();
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
}