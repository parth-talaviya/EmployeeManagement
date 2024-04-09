namespace UserManagement.Domain.Models.OrganizationLocation;

public sealed class LocationDetails
{
    public int Id { get; set; }

    public string Country { get; set; }

    public string State { get; set; }

    public string City { get; set; }

    public string Street { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}