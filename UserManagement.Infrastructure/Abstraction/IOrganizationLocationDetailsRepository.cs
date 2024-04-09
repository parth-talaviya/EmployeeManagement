namespace UserManagement.Infrastructure.Abstraction;

public interface IOrganizationLocationDetailsRepository
{
    Task<LocationDetails?> AddLocationDetailAsync(LocationDetails locationDetails, CancellationToken cancellationToken);

    Task<LocationDetails?>
        EditLocationDetailAsync(LocationDetails locationDetails, CancellationToken cancellationToken);

    Task<LocationDetails?> DeleteLocationDetailAsync(int id, CancellationToken cancellationToken);
    Task<IEnumerable<LocationDetails>> GetAllLocationDetailAsync(CancellationToken cancellationToken);
    Task<LocationDetails?> GetLocationDetailAsync(int id, CancellationToken cancellationToken);
}