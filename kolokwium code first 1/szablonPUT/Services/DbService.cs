using kolokwium_code_first_1.Data;
using kolokwium_code_first_1.DTOs;
using kolokwium_code_first_1.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace kolokwium_code_first_1.Services;

public class DbService : IDbService
{
    private readonly DatabaseContext _context;

    public DbService(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<BatchDto> GetBatchById(int batchId)
    {
        var batch = await _context.Seeding_Batches
            .Select(e => new BatchDto
            {
                BatchId = e.BatchId,
                Quantity = e.Quantity,
                SownDate = e.SownDate,
                ReadyDate = e.ReadyDate,
                Species = new SpeciesDto()
                {
                    SpeciesId = e.Tree_Species.SpeciesId,
                    GrowthTimeInYears = e.Tree_Species.GrowthTimeInYears,
                },
                
            })
            .FirstOrDefaultAsync(e => e.BatchId == batchId);
        
        if (batch is null)
            throw new NotFoundException();
        
        return batch;
    }

    public async Task<NurseryDto> GetNurseryById(int nurseryId) //todo
    {
        var nursery = await _context.Nurseries
            .Select(e => new NurseryDto
            {
                NurseryId = e.NurseryId,
            })
            .FirstOrDefaultAsync(e => e.NurseryId == nurseryId);
        return nursery;
    }
    
    
    
    /*
    public async Task<OrderDto> GetOrderById(int orderId)
    {
        var order = await _context.Orders
            .Select(e => new OrderDto
            {
                OrderId = e.OrderId,
                CreatedAt = e.CreatedAt,
                FulfilledAt = e.FulfilledAt,
                Status = e.Status.Name,
                Client = new ClientInfoDto()
                {
                    FirstName = e.Client.FirstName,
                    LastName = e.Client.LastName,
                },
                Products = e.Product_Orders.Select(e => new OrderProductsDto()
                {
                    Name = e.Product.Name,
                    Price = e.Product.Price,
                    Amount = e.Amount
                }).ToList()
            })
            .FirstOrDefaultAsync(e => e.OrderId == orderId);
        
        if (order is null)
            throw new NotFoundException();
        
        return order;
    }

    public async Task FulfillOrder(int orderId, FulfillOrderDto dto)
    {
        using var transaction = await _context.Database.BeginTransactionAsync();

        try
        {
            var order = await _context.Orders
                .FirstOrDefaultAsync(o => o.OrderId == orderId);

            if (order is null)
                throw new NotFoundException("Order not found.");

            var status = await _context.Statuses.FirstOrDefaultAsync(s => s.Name.Equals(dto.StatusName));
            if (status is null)
                throw new NotFoundException("Status not found.");

            if (order.FulfilledAt != null)
                throw new ConflictException("Order already fulfilled.");
            
            order.StatusId = status.StatusId;
            order.FulfilledAt = DateTime.Now;
            
            var relatedProducts = _context.Product_Orders.Where(po => po.OrderId == orderId);
            _context.Product_Orders.RemoveRange(relatedProducts);

            await _context.SaveChangesAsync();
            await transaction.CommitAsync();
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync();
            throw;
        }
    }
    */
}