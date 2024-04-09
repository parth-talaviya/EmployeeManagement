namespace UserManagement.ViewModel.Models.OrganizationLocation;

public sealed class UpdateLocationDetailsViewModel
{
    public int Id { get; set; }

    public string Country { get; set; }

    public string State { get; set; }

    public string City { get; set; }

    public string Street { get; set; }
}