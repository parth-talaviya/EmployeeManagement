namespace UserManagement.ViewModel.Models.ContactOrganization;

public sealed class ContactOrganizationViewModel
{
    public int Id { get; set; }

    public int ContactId { get; set; }

    public int OrganizationId { get; set; }

    public string OrganizationName { get; set; }
}