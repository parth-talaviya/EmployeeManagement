namespace UserManagement.Application.Handlers.ContactOrganization;

public sealed class
    DeleteContactOrganizationHandler : IRequestHandler<DeleteContactOrganizationCommand, ContactOrganizationViewModel?>
{
    private readonly IContactOrganizationService _contactOrganizationService;

    public DeleteContactOrganizationHandler(IContactOrganizationService contactOrganizationService)
    {
        _contactOrganizationService = contactOrganizationService;
    }

    public Task<ContactOrganizationViewModel?> Handle(DeleteContactOrganizationCommand request,
        CancellationToken cancellationToken)
    {
        return _contactOrganizationService.DeleteContactOrganizationAsync(request.Id, cancellationToken);
    }
}