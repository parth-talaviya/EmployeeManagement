namespace UserManagement.Application.Services.Implementation;

[RegisterService(typeof(IServiceProviderService))]
public sealed class ServiceProviderService : IServiceProviderService
{
    private readonly IServiceProviderRepository _serviceProviderDetailsRepository;
    private readonly IMapper _mapper;

    public ServiceProviderService(IServiceProviderRepository serviceProviderRegisterRepository,
        IMapper mapper)
    {
        _serviceProviderDetailsRepository = serviceProviderRegisterRepository;
        _mapper = mapper;
    }

    public async Task<AddServiceProviderViewModel?> AddServiceProviderAsync(
        AddServiceProviderViewModel serviceproviderViewModel,
        CancellationToken cancellationToken)
    {
        var serviceprovider =
            _mapper.Map<AddServiceProviderViewModel, ServiceProviderDetails>(serviceproviderViewModel);
        await _serviceProviderDetailsRepository.AddServiceProviderDetailAsync(serviceprovider, cancellationToken)
            .ConfigureAwait(false);

        return serviceproviderViewModel;
    }

    public async Task<ServiceProviderDetailsViewModel?> DeleteServiceProviderAsync(int id,
        CancellationToken cancellationToken)
    {
        var deleteServiceProvider = await _serviceProviderDetailsRepository
            .DeleteServiceProviderDetailAsync(id, cancellationToken)
            .ConfigureAwait(false);

        return deleteServiceProvider != null
            ? _mapper.Map<ServiceProviderDetailsViewModel>(deleteServiceProvider)
            : null;
    }

    public async Task<IEnumerable<ServiceProviderDetailsViewModel>> GetAllServiceProviderAsync(
        CancellationToken cancellationToken)
    {
        var getAllServiceProviderDetail = await _serviceProviderDetailsRepository
            .GetAllServiceProviderDetailAsync(cancellationToken).ConfigureAwait(false);

        return _mapper.Map<IEnumerable<ServiceProviderDetailsViewModel>>(getAllServiceProviderDetail) ??
               Enumerable.Empty<ServiceProviderDetailsViewModel>();
    }

    public async Task<ServiceProviderDetailsViewModel?> GetServiceProviderAsync(int id,
        CancellationToken cancellationToken)
    {
        var getServiceProvider = await _serviceProviderDetailsRepository
            .GetServiceProviderDetailAsync(id, cancellationToken)
            .ConfigureAwait(false);

        return getServiceProvider != null ? _mapper.Map<ServiceProviderDetailsViewModel>(getServiceProvider) : null;
    }
}