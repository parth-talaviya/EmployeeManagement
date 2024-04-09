namespace UserManagement.Domain.Models.Service;

public sealed class ServiceDetails
{
    public int Id { get; set; }

    public string Name { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public LocationDetails? Location { get; set; }

    public Organization? Organization { get; set; }

    public ProvidersDetails? Providers { get; set; }
}