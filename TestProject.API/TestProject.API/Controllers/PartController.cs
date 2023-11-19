using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestProject.Domain.Dtos;
using TestProject.Services.Abstraction;

namespace TestProject.API.Controllers;

[AllowAnonymous]
[Route("api/[controller]")]
[ApiController]
public class PartController : ControllerBase
{
    private readonly IPartService _partService;

    public PartController(IPartService partService)
    {
        _partService = partService;
    }

    [HttpGet("all")]
    [ProducesResponseType(typeof(List<PartDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllAsync() =>
        Ok(await _partService.GetAllAsync());

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> CreateAsync([FromBody] PartDto partDto)
    {
        await _partService.CreateAsync(partDto);

        return Ok();
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> UpdateAsync(int id, [FromBody] PartDto partDto)
    {
        await _partService.UpdateAsync(id, partDto);

        return Ok();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        await _partService.DeleteAsync(id);

        return Ok();
    }
}
