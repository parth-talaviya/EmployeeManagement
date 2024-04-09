namespace UserManagement.Application.Services.Implementation;

[RegisterService(typeof(IOrganizationLocationService))]
public sealed class OrganizationLocationService : IOrganizationLocationService
{
    private readonly IOrganizationLocationDetailsRepository _organizationLocationDetailsRepository;
    private readonly IMapper _mapper;

    public OrganizationLocationService(IOrganizationLocationDetailsRepository locationRegisterRepository,
        IMapper mapper)
    {
        _organizationLocationDetailsRepository = locationRegisterRepository;
        _mapper = mapper;
    }

    public async Task<AddLocationDetailsViewModel?> AddLocationAsync(AddLocationDetailsViewModel? locationViewModel,
        CancellationToken cancellationToken)
    {
        var locationDetails = _mapper.Map<AddLocationDetailsViewModel?, LocationDetails>(locationViewModel);
        var addedLocationDetails = await _organizationLocationDetailsRepository
            .AddLocationDetailAsync(locationDetails, cancellationToken)
            .ConfigureAwait(false);
        var updatedViewModel = _mapper.Map<LocationDetails?, AddLocationDetailsViewModel>(addedLocationDetails);

        return updatedViewModel != null ? updatedViewModel : null;
    }

    public async Task<UpdateLocationDetailsViewModel?> EditLocationAsync(
        UpdateLocationDetailsViewModel lovationDetailsUpdateViewModel, CancellationToken cancellationToken)
    {
        var editLocation = _mapper.Map<UpdateLocationDetailsViewModel, LocationDetails>(lovationDetailsUpdateViewModel);
        var updateLocation = await _organizationLocationDetailsRepository
            .EditLocationDetailAsync(editLocation, cancellationToken)
            .ConfigureAwait(false);

        return updateLocation != null
            ? _mapper.Map<LocationDetails, UpdateLocationDetailsViewModel>(updateLocation)
            : null;
    }

    public async Task<OrganizationLocationDetailsViewModel?> DeleteLocationAsync(int id,
        CancellationToken cancellationToken)
    {
        var deleteContact = await _organizationLocationDetailsRepository
            .DeleteLocationDetailAsync(id, cancellationToken)
            .ConfigureAwait(false);

        return deleteContact != null ? _mapper.Map<OrganizationLocationDetailsViewModel>(deleteContact) : null;
    }

    public async Task<IEnumerable<GetAllLocationDetailsViewModel>> GetAllLocationAsync(
        CancellationToken cancellationToken)
    {
        var getAllContactsDetail = await _organizationLocationDetailsRepository
            .GetAllLocationDetailAsync(cancellationToken).ConfigureAwait(false);

        return _mapper.Map<IEnumerable<GetAllLocationDetailsViewModel>>(getAllContactsDetail) ??
               Enumerable.Empty<GetAllLocationDetailsViewModel>();
    }

    public async Task<GetAllLocationDetailsViewModel?> GetLocationAsync(int id, CancellationToken cancellationToken)
    {
        var getContact = await _organizationLocationDetailsRepository.GetLocationDetailAsync(id, cancellationToken)
            .ConfigureAwait(false);

        return getContact != null ? _mapper.Map<GetAllLocationDetailsViewModel>(getContact) : null;
    }
}