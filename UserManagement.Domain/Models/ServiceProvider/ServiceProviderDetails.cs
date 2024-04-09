namespace UserManagement.Domain.Models.ServiceProviderl;

public sealed class ServiceProviderDetails
{
    public int Id { get; set; }

    public int ProviderId { get; set; }

    public int ServiceId { get; set; }

    public DateTime? CreatedAt { get; set; }
}