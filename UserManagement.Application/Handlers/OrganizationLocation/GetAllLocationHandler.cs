namespace UserManagement.Application.Handlers.OrganizationLocation;

public sealed class
    GetAllLocationHandler : IRequestHandler<GetAllLocationQuery, IEnumerable<GetAllLocationDetailsViewModel>>
{
    private readonly IOrganizationLocationService _locationService;

    public GetAllLocationHandler(IOrganizationLocationService locationService)
    {
        _locationService = locationService;
    }

    public async Task<IEnumerable<GetAllLocationDetailsViewModel>> Handle(GetAllLocationQuery request,
        CancellationToken cancellationToken)
    {
        return await _locationService.GetAllLocationAsync(cancellationToken).ConfigureAwait(false);
    }
}