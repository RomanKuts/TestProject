using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestProject.Domain.Dtos;
using TestProject.Services.Abstraction;

namespace TestProject.API.Controllers;

[AllowAnonymous]
[Route("api/[controller]")]
[ApiController]
public class WorkOrderController : ControllerBase
{
    private readonly IWorkOrderService _workOrderService;

    public WorkOrderController(IWorkOrderService workOrderService)
    {
        _workOrderService = workOrderService;
    }

    [HttpGet("all")]
    [ProducesResponseType(typeof(List<WorkOrderDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllAsync() =>
        Ok(await _workOrderService.GetAllAsync());

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> CreateAsync([FromBody] WorkOrderDto workOrderDto)
    {
        await _workOrderService.CreateAsync(workOrderDto);

        return Ok();
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> UpdateAsync(int id, [FromBody] WorkOrderDto workOrderDto)
    {
        await _workOrderService.UpdateAsync(id, workOrderDto);

        return Ok();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        await _workOrderService.DeleteAsync(id);

        return Ok();
    }
}
