namespace UserManagement.Application.Services.Implementation;

[RegisterService(typeof(IProviderService))]
public sealed class ProviderService : IProviderService
{
    private readonly IProvidersRepository _providerDetailsRepository;
    private readonly IMapper _mapper;

    public ProviderService(IProvidersRepository providerRegisterRepository,
        IMapper mapper)
    {
        _providerDetailsRepository = providerRegisterRepository;
        _mapper = mapper;
    }

    public async Task<AddProvidersViewModel?> AddProviderAsync(AddProvidersViewModel providerViewModel,
        CancellationToken cancellationToken)
    {
        var provider = _mapper.Map<AddProvidersViewModel, ProvidersDetails>(providerViewModel);
        await _providerDetailsRepository.AddProviderDetailAsync(provider, cancellationToken)
            .ConfigureAwait(false);

        return providerViewModel;
    }

    public async Task<EditProvidersViewModel?> EditProviderAsync(
        EditProvidersViewModel providerDetailsUpdateViewModel, CancellationToken cancellationToken)
    {
        var editProvider = _mapper.Map<EditProvidersViewModel, ProvidersDetails>(providerDetailsUpdateViewModel);
        var updateProvider = await _providerDetailsRepository
            .EditProviderDetailAsync(editProvider, cancellationToken)
            .ConfigureAwait(false);

        return updateProvider != null
            ? _mapper.Map<ProvidersDetails, EditProvidersViewModel>(updateProvider)
            : null;
    }

    public async Task<ProvidersDetailsViewModel?> DeleteProviderAsync(int id,
        CancellationToken cancellationToken)
    {
        var deleteProvider = await _providerDetailsRepository
            .DeleteProviderDetailAsync(id, cancellationToken)
            .ConfigureAwait(false);

        return deleteProvider != null ? _mapper.Map<ProvidersDetailsViewModel>(deleteProvider) : null;
    }

    public async Task<IEnumerable<ProvidersDetailsViewModel>> GetAllProviderAsync(
        CancellationToken cancellationToken)
    {
        var getAllServiceDetail = await _providerDetailsRepository
            .GetAllProviderDetailAsync(cancellationToken).ConfigureAwait(false);

        return _mapper.Map<IEnumerable<ProvidersDetailsViewModel>>(getAllServiceDetail) ??
               Enumerable.Empty<ProvidersDetailsViewModel>();
    }

    public async Task<ProvidersDetailsViewModel?> GetProviderAsync(int id, CancellationToken cancellationToken)
    {
        var getProvider = await _providerDetailsRepository.GetProviderDetailAsync(id, cancellationToken)
            .ConfigureAwait(false);

        return getProvider != null ? _mapper.Map<ProvidersDetailsViewModel>(getProvider) : null;
    }

    public async Task<IEnumerable<GetAllProviderswithLocationServiceAndOrganizationViewModel>>
        GetAllProviderWithServiceLocationAndOrganizationAsync(
            CancellationToken cancellationToken)
    {
        var getAllServiceDetail = await _providerDetailsRepository
            .GetspecifcProviderDetailWithServiceOrganizationAndOrganizationAsync(cancellationToken)
            .ConfigureAwait(false);

        return _mapper.Map<IEnumerable<GetAllProviderswithLocationServiceAndOrganizationViewModel>>(
                   getAllServiceDetail) ??
               Enumerable.Empty<GetAllProviderswithLocationServiceAndOrganizationViewModel>();
    }

    public async Task<IEnumerable<GetAllProviderswithLocationAndOrganizationViewModel>>
        GetAllProviderWithLocationAndOrganizationAsync(CancellationToken cancellationToken)
    {
        var getAllServiceDetail = await _providerDetailsRepository
            .GetspecifcProviderDetailWithOrganizationAndLocationAsync(cancellationToken).ConfigureAwait(false);

        return _mapper.Map<IEnumerable<GetAllProviderswithLocationAndOrganizationViewModel>>(getAllServiceDetail) ??
               Enumerable.Empty<GetAllProviderswithLocationAndOrganizationViewModel>();
    }
}