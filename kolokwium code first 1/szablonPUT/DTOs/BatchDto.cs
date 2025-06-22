using kolokwium_code_first_1.Models;

namespace kolokwium_code_first_1.DTOs;

public class BatchDto
{
    public int BatchId { get; set; }
    public int Quantity { get; set; }
    public DateTime SownDate { get; set; }
    public DateTime? ReadyDate { get; set; }
    public SpeciesDto Species { get; set; }
    public List<ResponsibleDto> Responsibles { get; set; }
}