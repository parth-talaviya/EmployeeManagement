namespace UserManagement.Application.Services.Abstraction;

public interface IOrganizationLocationService
{
    Task<AddLocationDetailsViewModel?> AddLocationAsync(AddLocationDetailsViewModel locationViewModel,
        CancellationToken cancellationToken);

    Task<UpdateLocationDetailsViewModel?> EditLocationAsync(
        UpdateLocationDetailsViewModel lovationDetailsUpdateViewModel, CancellationToken cancellationToken);

    Task<OrganizationLocationDetailsViewModel?> DeleteLocationAsync(int id, CancellationToken cancellationToken);

    Task<IEnumerable<GetAllLocationDetailsViewModel>> GetAllLocationAsync(CancellationToken cancellationToken);

    Task<GetAllLocationDetailsViewModel?> GetLocationAsync(int id, CancellationToken cancellationToken);
}