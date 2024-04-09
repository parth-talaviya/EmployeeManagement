namespace UserManagement.Infrastructure.Abstraction;

public interface IOrganizationRepository
{
    Task<int> AddOrganizationAsync(Organization organization, CancellationToken cancellationToken);

    Task<Organization?> EditOrganizationAsync(Organization organization, CancellationToken cancellationToken);

    Task<Organization?> DeleteOrganizationAsync(int id, CancellationToken cancellationToken);

    Task<IEnumerable<Organization>> GetAllOrganizationAsync(CancellationToken cancellationToken);

    Task<Organization?> GetOrganizationAsync(int id, CancellationToken cancellationToken);
}