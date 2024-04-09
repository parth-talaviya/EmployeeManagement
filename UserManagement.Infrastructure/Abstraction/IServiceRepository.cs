namespace UserManagement.Infrastructure.Abstraction;

public interface IServiceRepository
{
    Task<ServiceDetails?> AddServiceDetailAsync(ServiceDetails serviceDetails,
        CancellationToken cancellationToken);

    Task<ServiceDetails?> EditServiceDetailAsync(ServiceDetails serviceDetails,
        CancellationToken cancellationToken);

    Task<ServiceDetails?> DeleteServiceDetailAsync(int id, CancellationToken cancellationToken);

    Task<IEnumerable<ServiceDetails>> GetAllServiceDetailAsync(CancellationToken cancellationToken);

    Task<ServiceDetails?> GetServiceDetailAsync(int id, CancellationToken cancellationToken);

    Task<IEnumerable<ServiceDetails>> GetAllServiceDetailWithLocationIdAndOrganizationIdAsync(
        CancellationToken cancellationToken);

    Task<IEnumerable<ServiceDetails>> GetAllServiceDetailWithLocationIdAndOrganizationAndProvidersIdAsync(
        CancellationToken cancellationToken);
}