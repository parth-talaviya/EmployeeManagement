using UserManagement.ViewModel.Models.ContactOrganization;
using UserManagement.ViewModel.Models.Service;

namespace UserManagement.ViewModel.Models.Providers;

public sealed class GetAllProviderswithLocationAndOrganizationViewModel
{
    public int Id { get; set; }

    public string ProviderName { get; set; }

    public GetAllLocationDetailsViewModel Location { get; set; }

    public OrganizationViewModel Organization { get; set; }
}