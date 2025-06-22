namespace kolokwium_code_first_1.DTOs;

public class NurseryDto
{
    public int NurseryId { get; set; }
    public string Name { get; set; }
    public DateTime EstablishedDate { get; set; }
    public BatchDto Batch { get; set; }
}