using CafeManagement.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CafeManagement.Domain.Entities;

public class Cafe : BaseEntity
{
    [Required]
    public string Name { get; set; }

    [Required]
    public string Description { get; set; }

    [Required]
    public string Location { get; set; }
    public byte[] Logo { get; set; }

    public string ContentType { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } =  [];

    [NotMapped]
    public int EmployeeCount { get; set; }
}

