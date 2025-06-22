using kolokwium_code_first_1.DTOs;
using kolokwium_code_first_1.Models;

namespace kolokwium_code_first_1.Services;

public interface IDbService
{
    /*
    Task<OrderDto> GetOrderById(int orderId);
    Task FulfillOrder(int orderId, FulfillOrderDto dto);
    */
    
    Task <BatchDto> GetBatchById(int BatchId);
    Task <NurseryDto> GetNurseryById(int NurseryId);
    //Task <ResponsibleDto> GetResponsible(int ResponsibleId); //todo
    //Task <SpeciesDto> GetSpecies(int SpeciesId); //todo

}