using CafeManagement.Domain.Common;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CafeManagement.Domain.Entities
{
    public class CafeEmployee : AuditEntity
    {
        // Foreign Key to Cafe
        [ForeignKey(nameof(Cafe))]
        [Required]
        public Guid CafeId { get; set; }
        public virtual Cafe Cafe { get; set; }

        // Foreign Key to Employee (Only one reference is needed)
        [ForeignKey(nameof(Employee))]
        [Required]
        public Guid EmployeeID { get; set; }
        public virtual Employee Employee { get; set; }

        // Start date for when the employee started working at this cafe
        public DateTime StartDate { get; set; }
    }
}
