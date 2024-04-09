namespace UserManagement.Application.Handlers.Organization;

public sealed class GetOrganizationHandler : IRequestHandler<GetOrganizationByIdQuery, OrganizationViewModel?>
{
    private readonly IOrganizationService _organizationService;

    public GetOrganizationHandler(IOrganizationService organizationService)
    {
        _organizationService = organizationService;
    }

    public Task<OrganizationViewModel?> Handle(GetOrganizationByIdQuery request, CancellationToken cancellationToken)
    {
        return _organizationService.GetOrganizationAsync(request.Id, cancellationToken);
    }
}