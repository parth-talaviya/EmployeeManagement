namespace UserManagement.Domain.Models.ContactOrganization;

public sealed class Organization
{
    public int Id { get; set; }

    public string Name { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public  LocationDetails Location { get; set; }
}