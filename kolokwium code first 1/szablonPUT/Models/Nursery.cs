using System.ComponentModel.DataAnnotations;

namespace kolokwium_code_first_1.Models;

public class Nursery
{
    [Key]
    public int NurseryId { get; set; }
    
    [MaxLength(100)]
    public string Name { get; set; }
    
    public DateTime EstablishedDate { get; set; }

    public ICollection<Seeding_Batch> Seeding_Batches { get; set; } = null!;
}