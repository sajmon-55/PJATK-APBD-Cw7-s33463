using Microsoft.AspNetCore.Mvc;
using PJATK_APBD_Cw7_s33463.Models;

namespace PJATK_APBD_Cw7_s33463.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PCsController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok();
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        return Ok();
    }
    
    [HttpPost]
    public async Task<IActionResult> Add()
    {
        return Ok();
    }
    
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id)
    {
        return Ok();
    }
    
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        return Ok();
    }
}