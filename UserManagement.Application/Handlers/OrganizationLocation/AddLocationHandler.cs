namespace UserManagement.Application.Handlers.OrganizationLocation;

public sealed class AddLocationHandler : IRequestHandler<AddLocationCommand, AddLocationDetailsViewModel?>
{
    private readonly IOrganizationLocationService _locationDetailService;

    public AddLocationHandler(IOrganizationLocationService locationDetailService)
    {
        _locationDetailService = locationDetailService;
    }

    public Task<AddLocationDetailsViewModel?> Handle(AddLocationCommand addLocationCommand,
        CancellationToken cancellationToken)
    {
        return _locationDetailService.AddLocationAsync(addLocationCommand.AddLocationModel, cancellationToken);
    }
}