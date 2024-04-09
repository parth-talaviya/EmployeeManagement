namespace UserManagement.Infrastructure.Abstraction;

public interface IServiceProviderRepository
{
    Task<ServiceProviderDetails?> AddServiceProviderDetailAsync(ServiceProviderDetails serviceproviderDetails,
        CancellationToken cancellationToken);

    Task<ServiceProviderDetails?> DeleteServiceProviderDetailAsync(int id, CancellationToken cancellationToken);

    Task<IEnumerable<ServiceProviderDetails>> GetAllServiceProviderDetailAsync(CancellationToken cancellationToken);

    Task<ServiceProviderDetails?> GetServiceProviderDetailAsync(int id, CancellationToken cancellationToken);
}