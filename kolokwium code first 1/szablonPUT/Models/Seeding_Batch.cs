using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using kolokwium_code_first_1.Models;

namespace kolokwium_code_first_1.Models;

public class Seeding_Batch
{
    [Key]
    public int BatchId { get; set; }
    
    [ForeignKey(nameof(NurseryId))]
    public int NurseryId { get; set; }
    
    [ForeignKey(nameof(SpeciesId))]
    public int SpeciesId { get; set; }
    
    public int Quantity { get; set; }
    
    public DateTime SownDate { get; set; }
    public DateTime? ReadyDate { get; set; }
    
    public Nursery Nursery { get; set; } = null!;
    public Tree_Species Tree_Species { get; set; } = null!;
}