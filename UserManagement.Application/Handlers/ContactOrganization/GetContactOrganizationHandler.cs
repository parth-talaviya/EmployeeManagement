namespace UserManagement.Application.Handlers.ContactOrganization;

public sealed class
    GetContactOrganizationHandler : IRequestHandler<GetContactOrganizationQuery,
    IEnumerable<ContactOrganizationViewModel>>
{
    private readonly IContactOrganizationService _contactOrganizationService;

    public GetContactOrganizationHandler(IContactOrganizationService contactOrganizationService)
    {
        _contactOrganizationService = contactOrganizationService;
    }

    public Task<IEnumerable<ContactOrganizationViewModel>> Handle(GetContactOrganizationQuery request,
        CancellationToken cancellationToken)
    {
        return _contactOrganizationService.GetContactOrganizationAsync(request.ContactId, cancellationToken);
    }
}