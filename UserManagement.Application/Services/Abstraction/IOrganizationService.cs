namespace UserManagement.Application.Services.Abstraction;

public interface IOrganizationService
{
    Task<int> AddOrganizationAsync(AddOrganizationViewModel organizationViewModel, CancellationToken cancellationToken);

    Task<UpdateOrganizationViewModel?> EditOrganizationAsync(UpdateOrganizationViewModel organizationViewModel,
        CancellationToken cancellationToken);

    Task<OrganizationViewModel?> DeleteOrganizationAsync(int id, CancellationToken cancellationToken);

    Task<OrganizationViewModel?> GetOrganizationAsync(int id, CancellationToken cancellationToken);

    Task<IEnumerable<OrganizationViewModel>> GetAllOrganizationAsync(CancellationToken cancellationToken);
}