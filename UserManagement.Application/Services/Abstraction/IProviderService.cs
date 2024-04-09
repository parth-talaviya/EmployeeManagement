namespace UserManagement.Application.Services.Abstraction;

public interface IProviderService
{
    Task<AddProvidersViewModel?> AddProviderAsync(AddProvidersViewModel providerViewModel,
        CancellationToken cancellationToken);

    Task<EditProvidersViewModel?> EditProviderAsync(
        EditProvidersViewModel providerDetailsUpdateViewModel, CancellationToken cancellationToken);

    Task<ProvidersDetailsViewModel?> DeleteProviderAsync(int id,
        CancellationToken cancellationToken);

    Task<IEnumerable<ProvidersDetailsViewModel>> GetAllProviderAsync(
        CancellationToken cancellationToken);

    Task<ProvidersDetailsViewModel?> GetProviderAsync(int id, CancellationToken cancellationToken);

    Task<IEnumerable<GetAllProviderswithLocationServiceAndOrganizationViewModel>>
        GetAllProviderWithServiceLocationAndOrganizationAsync(
            CancellationToken cancellationToken);

    Task<IEnumerable<GetAllProviderswithLocationAndOrganizationViewModel>>
        GetAllProviderWithLocationAndOrganizationAsync(
            CancellationToken cancellationToken);
}