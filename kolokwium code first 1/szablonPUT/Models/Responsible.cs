using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace kolokwium_code_first_1.Models;

[PrimaryKey(nameof(BatchId),nameof(EmployeeId))]
public class Responsible
{
    [ForeignKey(nameof(BatchId))]
    public int BatchId { get; set; }
    [ForeignKey(nameof(EmployeeId))]
    public int EmployeeId { get; set; }
    [MaxLength(100)]
    public string Role { get; set; }
}