namespace UserManagement.ViewModel.Models.Providers;

public sealed class ProvidersDetailsViewModel
{
    public int Id { get; set; }

    public string ProviderName { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}