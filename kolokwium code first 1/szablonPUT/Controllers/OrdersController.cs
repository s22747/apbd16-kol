using kolokwium_code_first_1.DTOs;
using kolokwium_code_first_1.Exceptions;
using kolokwium_code_first_1.Services;
using Microsoft.AspNetCore.Mvc;

namespace kolokwium_code_first_1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    
    private readonly IDbService _dbService;

    public OrdersController(IDbService dbService)
    {
        _dbService = dbService;
    }

    [HttpGet("/nurseries/{nurseriesId}/batches")]
    public async Task<IActionResult> GetBatch(int BatchId)
    {
        try
        {
            return NotFound(); //todo
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }
    
    /*
    [HttpPut("{orderId}/fulfill")]
    public async Task<IActionResult> FulfillOrder(int orderId, FulfillOrderDto dto)
    {
        try
        {
            await _dbService.FulfillOrder(orderId, dto);
            return Ok();
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (ConflictException e)
        {
            return Conflict(e.Message);
        }
    }
    */
}