using System.ComponentModel.DataAnnotations;

namespace kolokwium_code_first_1.Models;

public class Employee
{
    [Key]
    public int EmployeeId { get; set; }
    
    [MaxLength(100)]
    public string FirstName { get; set; }
    [MaxLength(100)]
    public string LastName { get; set; }
    
    public DateTime HireDate { get; set; }

    public ICollection<Responsible> Responsibles { get; set; } = null!;
}