namespace UserManagement.ViewModel.Models.Providers;

public sealed class GetAllProviderswithLocationServiceAndOrganizationViewModel
{
    public int Id { get; set; }

    public string ProviderName { get; set; }

    public GetAllLocationDetailsViewModel Location { get; set; }

    public OrganizationViewModel Organization { get; set; }

    public ServiceDetailsViewModel Service { get; set; }
}