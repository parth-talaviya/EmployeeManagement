namespace UserManagement.Domain.Models.Countries;

public sealed class CountryDetails
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string RegionCode { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}