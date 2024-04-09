namespace UserManagement.ViewModel.Models.Service;

public sealed class GetAllServiceWithOrganizationAndLocationViewModel
{
    public int Id { get; set; }

    public string Name { get; set; }

    public GetAllLocationDetailsViewModel? Location { get; set; }

    public OrganizationViewModel? Organization { get; set; }

    public ProvidersDetailsViewModel Providers { get; set; }
}