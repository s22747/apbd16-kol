using kolokwium_code_first_1.Models;
using Microsoft.EntityFrameworkCore;

namespace kolokwium_code_first_1.Data;

public class DatabaseContext : DbContext
{
    public DbSet<Nursery> Nurseries { get; set; } = null!;
    public DbSet<Employee> Employees { get; set; } = null!;
    public DbSet<Responsible> Responsibles { get; set; } = null!;
    public DbSet<Tree_Species> Tree_Speciess { get; set; } = null!;
    public DbSet<Seeding_Batch> Seeding_Batches { get; set; } = null!;
    
    protected DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Nursery>().HasData(new List<Nursery>()
        {
            new Nursery() {NurseryId = 1, Name = "Bialy las", EstablishedDate = DateTime.Parse("2020-09-25")},
            new Nursery() {NurseryId = 2, Name = "Czarny Las", EstablishedDate = DateTime.Parse("2020-09-26")},
            new Nursery() {NurseryId = 3, Name = "Zielony Las", EstablishedDate = DateTime.Parse("2020-09-27")},
            
        });

        modelBuilder.Entity<Employee>().HasData(new List<Employee>()
        {
            new Employee() {EmployeeId = 1, FirstName = "Jon", LastName = "Jones", HireDate = DateTime.Parse("2018-09-25")},
            new Employee() {EmployeeId = 2, FirstName = "Jane", LastName = "Jone", HireDate = DateTime.Parse("2017-09-25")},
            new Employee() {EmployeeId = 3, FirstName = "Jun", LastName = "Jin", HireDate = DateTime.Parse("2016-09-25")}
            
        });
        
        modelBuilder.Entity<Tree_Species>().HasData(new List<Tree_Species>()
        {
            new Tree_Species() {SpeciesId = 1, LatinName = "Brzoza", GrowthTimeInYears = 10},
            new Tree_Species() {SpeciesId = 2, LatinName = "Dab", GrowthTimeInYears = 30},
            new Tree_Species() {SpeciesId = 3, LatinName = "Jemiola", GrowthTimeInYears = 5}
        });

        modelBuilder.Entity<Responsible>().HasData(new List<Responsible>()
        {
            new Responsible() {BatchId = 1, EmployeeId = 1, Role = "Sadzacz"},
            new Responsible() {BatchId = 2, EmployeeId = 2, Role = "Podlewacz"},
            new Responsible() {BatchId = 3, EmployeeId = 3, Role = "Podpalacz"},
        });
        
        modelBuilder.Entity<Seeding_Batch>().HasData(new List<Seeding_Batch>()
        {
            new Seeding_Batch() {BatchId = 1, NurseryId = 1, SpeciesId = 1, Quantity = 15, SownDate = DateTime.Parse("2025-09-25"), ReadyDate = DateTime.Parse("2025-10-25")},
            new Seeding_Batch() {BatchId = 2, NurseryId = 2, SpeciesId = 2, Quantity = 30, SownDate = DateTime.Parse("2025-09-30"), ReadyDate = DateTime.Parse("2028-10-25")},
            new Seeding_Batch() {BatchId = 3, NurseryId = 3, SpeciesId = 3, Quantity = 40, SownDate = DateTime.Parse("2025-11-30"), ReadyDate = DateTime.Parse("2028-10-25")}
        });
        
    }
}