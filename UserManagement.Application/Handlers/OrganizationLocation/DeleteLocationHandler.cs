namespace UserManagement.Application.Handlers.OrganizationLocation;

public sealed class
    DeleteLocationHandler : IRequestHandler<DeleteLocationCommand, OrganizationLocationDetailsViewModel?>
{
    private readonly IOrganizationLocationService _locationDetailService;

    public DeleteLocationHandler(IOrganizationLocationService locationDetailService)
    {
        _locationDetailService = locationDetailService;
    }

    public async Task<OrganizationLocationDetailsViewModel?> Handle(DeleteLocationCommand request,
        CancellationToken cancellationToken)
    {
        return await _locationDetailService.DeleteLocationAsync(request.Id, cancellationToken).ConfigureAwait(false);
    }
}