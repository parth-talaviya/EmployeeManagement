namespace UserManagement.Application.Services.Implementation;

[RegisterService(typeof(IServiceService))]
public sealed class ServiceService : IServiceService
{
    private readonly IServiceRepository _serviceDetailsRepository;
    private readonly IMapper _mapper;

    public ServiceService(IServiceRepository serviceRegisterRepository,
        IMapper mapper)
    {
        _serviceDetailsRepository = serviceRegisterRepository;
        _mapper = mapper;
    }

    public async Task<AddServiceViewModel?> AddServiceAsync(AddServiceViewModel serviceViewModel,
        CancellationToken cancellationToken)
    {
        var service = _mapper.Map<AddServiceViewModel, ServiceDetails>(serviceViewModel);
        await _serviceDetailsRepository.AddServiceDetailAsync(service, cancellationToken)
            .ConfigureAwait(false);

        return serviceViewModel;
    }

    public async Task<EditServiceViewModel?> EditServiceAsync(
        EditServiceViewModel serviceDetailsUpdateViewModel, CancellationToken cancellationToken)
    {
        var editService = _mapper.Map<EditServiceViewModel, ServiceDetails>(serviceDetailsUpdateViewModel);
        var updateService = await _serviceDetailsRepository
            .EditServiceDetailAsync(editService, cancellationToken)
            .ConfigureAwait(false);

        return updateService != null
            ? _mapper.Map<ServiceDetails, EditServiceViewModel>(updateService)
            : null;
    }

    public async Task<ServiceDetailsViewModel?> DeleteServiceAsync(int id,
        CancellationToken cancellationToken)
    {
        var deleteService = await _serviceDetailsRepository
            .DeleteServiceDetailAsync(id, cancellationToken)
            .ConfigureAwait(false);

        return deleteService != null ? _mapper.Map<ServiceDetailsViewModel>(deleteService) : null;
    }

    public async Task<IEnumerable<ServiceDetailsViewModel>> GetAllServiceAsync(
        CancellationToken cancellationToken)
    {
        var getAllServiceDetail = await _serviceDetailsRepository
            .GetAllServiceDetailAsync(cancellationToken).ConfigureAwait(false);

        return _mapper.Map<IEnumerable<ServiceDetailsViewModel>>(getAllServiceDetail) ??
               Enumerable.Empty<ServiceDetailsViewModel>();
    }

    public async Task<ServiceDetailsViewModel?> GetServiceAsync(int id, CancellationToken cancellationToken)
    {
        var getService = await _serviceDetailsRepository.GetServiceDetailAsync(id, cancellationToken)
            .ConfigureAwait(false);

        return getService != null ? _mapper.Map<ServiceDetailsViewModel>(getService) : null;
    }

    public async Task<IEnumerable<GetAllServiceWithOrganizationAndLocationViewModel>>
        GetAllServiceWithLocationIdOrOrganizationIdAsync(
            CancellationToken cancellationToken)
    {
        var getAllServiceDetail = await _serviceDetailsRepository
            .GetAllServiceDetailWithLocationIdAndOrganizationIdAsync(cancellationToken).ConfigureAwait(false);

        return _mapper.Map<IEnumerable<GetAllServiceWithOrganizationAndLocationViewModel>>(getAllServiceDetail) ??
               Enumerable.Empty<GetAllServiceWithOrganizationAndLocationViewModel>();
    }

    public async Task<IEnumerable<GetAllServiceWithOrganizationAndLocationViewModel>>
        GetAllServiceWithLocationIdOrOrganizationAndProvidersIdAsync(
            CancellationToken cancellationToken)
    {
        var getAllServiceDetail = await _serviceDetailsRepository
            .GetAllServiceDetailWithLocationIdAndOrganizationAndProvidersIdAsync(cancellationToken)
            .ConfigureAwait(false);

        return _mapper.Map<IEnumerable<GetAllServiceWithOrganizationAndLocationViewModel>>(getAllServiceDetail) ??
               Enumerable.Empty<GetAllServiceWithOrganizationAndLocationViewModel>();
    }
}