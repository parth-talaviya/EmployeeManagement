namespace UserManagement.ViewModel.Models.Providers;

public sealed class ProviderDetailsViewModel
{
    public int Id { get; set; }

    public string ProviderName { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public LocationDetails Location { get; set; }

    public Organization Organization { get; set; }

    public ServiceDetails Service { get; set; }
}