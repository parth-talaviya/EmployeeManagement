namespace UserManagement.Application.Handlers.Organization;

public sealed class
    GetAllOrganizationHandler : IRequestHandler<GetAllOrganizationQuery, IEnumerable<OrganizationViewModel>>
{
    private readonly IOrganizationService _organizationService;

    public GetAllOrganizationHandler(IOrganizationService organizationService)
    {
        _organizationService = organizationService;
    }

    public Task<IEnumerable<OrganizationViewModel>> Handle(GetAllOrganizationQuery request,
        CancellationToken cancellationToken)
    {
        return _organizationService.GetAllOrganizationAsync(cancellationToken);
    }
}