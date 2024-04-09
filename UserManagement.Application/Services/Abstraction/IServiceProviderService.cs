namespace UserManagement.Application.Services.Abstraction;

public interface IServiceProviderService
{
    Task<AddServiceProviderViewModel?> AddServiceProviderAsync(AddServiceProviderViewModel serviceproviderViewModel,
        CancellationToken cancellationToken);

    Task<ServiceProviderDetailsViewModel?> DeleteServiceProviderAsync(int id,
        CancellationToken cancellationToken);

    Task<IEnumerable<ServiceProviderDetailsViewModel>> GetAllServiceProviderAsync(
        CancellationToken cancellationToken);

    Task<ServiceProviderDetailsViewModel?> GetServiceProviderAsync(int id, CancellationToken cancellationToken);
}