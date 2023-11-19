using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestProject.Domain.Dtos;
using TestProject.Services.Abstraction;

namespace TestProject.API.Controllers;

[AllowAnonymous]
[Route("api/[controller]")]
[ApiController]
public class VisitController : ControllerBase
{
    private readonly IVisitService _visitOrderService;

    public VisitController(IVisitService visitOrderService)
    {
        _visitOrderService = visitOrderService;
    }

    [HttpGet("all")]
    [ProducesResponseType(typeof(List<VisitDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllAsync() =>
        Ok(await _visitOrderService.GetAllAsync());

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> CreateAsync([FromBody] VisitDto visitDto)
    {
        await _visitOrderService.CreateAsync(visitDto);

        return Ok();
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> UpdateAsync(int id, [FromBody] VisitDto visitDto)
    {
        await _visitOrderService.UpdateAsync(id, visitDto);

        return Ok();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        await _visitOrderService.DeleteAsync(id);

        return Ok();
    }
}