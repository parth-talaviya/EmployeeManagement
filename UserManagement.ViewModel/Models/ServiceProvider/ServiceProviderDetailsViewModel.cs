namespace UserManagement.ViewModel.Models.ServiceProvider;

public sealed class ServiceProviderDetailsViewModel
{
    public int Id { get; set; }

    public int ProviderId { get; set; }

    public int ServiceId { get; set; }

    public DateTime? CreatedAt { get; set; }
}