namespace UserManagement.Application.Services.Abstraction;

public interface IServiceService
{
    Task<AddServiceViewModel?> AddServiceAsync(AddServiceViewModel serviceViewModel,
        CancellationToken cancellationToken);

    Task<EditServiceViewModel?> EditServiceAsync(
        EditServiceViewModel serviceDetailsUpdateViewModel, CancellationToken cancellationToken);

    Task<ServiceDetailsViewModel?> DeleteServiceAsync(int id,
        CancellationToken cancellationToken);

    Task<IEnumerable<ServiceDetailsViewModel>> GetAllServiceAsync(
        CancellationToken cancellationToken);

    Task<ServiceDetailsViewModel?> GetServiceAsync(int id, CancellationToken cancellationToken);

    Task<IEnumerable<GetAllServiceWithOrganizationAndLocationViewModel>>
        GetAllServiceWithLocationIdOrOrganizationIdAsync(
            CancellationToken cancellationToken);

    Task<IEnumerable<GetAllServiceWithOrganizationAndLocationViewModel>>
        GetAllServiceWithLocationIdOrOrganizationAndProvidersIdAsync(
            CancellationToken cancellationToken);
}