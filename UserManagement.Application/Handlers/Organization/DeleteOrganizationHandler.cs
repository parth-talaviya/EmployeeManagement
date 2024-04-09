namespace UserManagement.Application.Handlers.Organization;

public sealed class DeleteOrganizationHandler : IRequestHandler<DeleteOrganizationCommand, OrganizationViewModel?>
{
    private readonly IOrganizationService _organizationService;

    public DeleteOrganizationHandler(IOrganizationService organizationService)
    {
        _organizationService = organizationService;
    }

    public Task<OrganizationViewModel?> Handle(DeleteOrganizationCommand request, CancellationToken cancellationToken)
    {
        return _organizationService.DeleteOrganizationAsync(request.Id, cancellationToken);
    }
}