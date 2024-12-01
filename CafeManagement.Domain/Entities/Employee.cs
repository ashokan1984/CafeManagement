using CafeManagement.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CafeManagement.Domain.Entities;

public class Employee : BaseEntity
{
    [Required]
    [MaxLength(10)]
    public string EmployeeId { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string EmailAddress { get; set; }

    [Required]
    public string PhoneNumber { get; set; }

    [Required]
    public GenderEnum Gender { get; set; }

    [ForeignKey(nameof(Cafe))]
    public Guid CafeId { get; set; }

    public Cafe Cafe { get; set; }

    public CafeEmployee CafeEmployee { get; set; }
}
