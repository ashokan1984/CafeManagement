namespace CafeManagement.Domain.Common;

public abstract class AuditEntity
{
    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.Now;
    public DateTimeOffset? UpdatedAt { get; set; } = DateTimeOffset.Now;

    public string CreatedBy { get; set; }

    public string UpdatedBy { get; set; }
}

