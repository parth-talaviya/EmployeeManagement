namespace UserManagement.Application.Handlers.Organization;

public sealed class EditOrganizationHandler : IRequestHandler<EditOrganizationCommand, UpdateOrganizationViewModel?>
{
    private readonly IOrganizationService _organizationService;

    public EditOrganizationHandler(IOrganizationService organizationService)
    {
        _organizationService = organizationService;
    }

    public Task<UpdateOrganizationViewModel?> Handle(EditOrganizationCommand command,
        CancellationToken cancellationToken)
    {
        return _organizationService.EditOrganizationAsync(command.UpdateOrganizationViewModel, cancellationToken);
    }
}