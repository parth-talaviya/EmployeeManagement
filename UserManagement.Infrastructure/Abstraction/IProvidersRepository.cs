namespace UserManagement.Infrastructure.Abstraction;

public interface IProvidersRepository
{
    Task<ProvidersDetails?> AddProviderDetailAsync(ProvidersDetails locationDetails,
        CancellationToken cancellationToken);

    Task<ProvidersDetails?> EditProviderDetailAsync(ProvidersDetails providerDetails,
        CancellationToken cancellationToken);

    Task<ProvidersDetails?> DeleteProviderDetailAsync(int id, CancellationToken cancellationToken);

    Task<IEnumerable<ProvidersDetails>> GetAllProviderDetailAsync(CancellationToken cancellationToken);

    Task<ProvidersDetails?> GetProviderDetailAsync(int id, CancellationToken cancellationToken);

    Task<IEnumerable<ProvidersDetails>> GetspecifcProviderDetailWithServiceOrganizationAndOrganizationAsync(
        CancellationToken cancellationToken);

    Task<IEnumerable<ProvidersDetails>> GetspecifcProviderDetailWithOrganizationAndLocationAsync(
        CancellationToken cancellationToken);
}