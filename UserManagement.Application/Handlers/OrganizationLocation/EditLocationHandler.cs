namespace UserManagement.Application.Handlers.OrganizationLocation;

public sealed class EditLocationHandler : IRequestHandler<EditLocationCommand, UpdateLocationDetailsViewModel?>
{
    private readonly IOrganizationLocationService _locationDetailService;

    public EditLocationHandler(IOrganizationLocationService locationDetailService)
    {
        _locationDetailService = locationDetailService;
    }

    public Task<UpdateLocationDetailsViewModel?> Handle(EditLocationCommand editLocationCommand,
        CancellationToken cancellationToken)
    {
        return _locationDetailService.EditLocationAsync(editLocationCommand.LocationDetailsViewModel,
            cancellationToken);
    }
}