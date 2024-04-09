namespace UserManagement.ViewModel.Models.ContactOrganization;

public sealed class OrganizationViewModel
{
    public int Id { get; set; }

    public string Name { get; set; }

    public GetAllLocationViewModel Location { get; set; }
}    