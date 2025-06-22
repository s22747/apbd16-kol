using System.ComponentModel.DataAnnotations;

namespace kolokwium_code_first_1.Models;

public class Tree_Species
{
    [Key]
    public int SpeciesId { get; set; }
    
    [MaxLength(100)]
    public string LatinName { get; set; }
    public int GrowthTimeInYears { get; set; }

    public ICollection<Seeding_Batch> Seeding_Batches { get; set; } = null!;
}