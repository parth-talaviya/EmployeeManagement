namespace UserManagement.Domain.Models.ContactOrganization;

public sealed class ContactOrganization
{
    public int Id { get; set; }

    public int ContactId { get; set; }

    public int OrganizationId { get; set; }

    public string OrganizationName { get; set; }

    public DateTime CreatedAt { get; set; }
}