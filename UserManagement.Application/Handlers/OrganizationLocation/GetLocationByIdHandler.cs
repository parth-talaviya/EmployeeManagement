namespace UserManagement.Application.Handlers.OrganizationLocation;

public sealed class GetLocationByIdHandler : IRequestHandler<GetLocationQuery, GetAllLocationDetailsViewModel?>
{
    private readonly IOrganizationLocationService _locationService;

    public GetLocationByIdHandler(IOrganizationLocationService locationService)
    {
        _locationService = locationService;
    }

    public Task<GetAllLocationDetailsViewModel?> Handle(GetLocationQuery request, CancellationToken cancellationToken)
    {
        return _locationService.GetLocationAsync(request.Id, cancellationToken);
    }
}