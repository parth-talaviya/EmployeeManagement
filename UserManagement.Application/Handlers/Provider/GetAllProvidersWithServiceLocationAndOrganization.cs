namespace UserManagement.Application.Handlers.Provider;

public sealed class GetAllProviderGetAllProvidersWithServiceLocationAndOrganizationsHandlers : IRequestHandler<
    GetAllProvidersWithServiceLocationAndOrganizationQuery,
    IEnumerable<GetAllProviderswithLocationServiceAndOrganizationViewModel>>
{
    private readonly IProviderService _providerService;

    public GetAllProviderGetAllProvidersWithServiceLocationAndOrganizationsHandlers(IProviderService providerService)
    {
        _providerService = providerService;
    }

    public async Task<IEnumerable<GetAllProviderswithLocationServiceAndOrganizationViewModel>> Handle(
        GetAllProvidersWithServiceLocationAndOrganizationQuery request,
        CancellationToken cancellationToken)
    {
        return await _providerService.GetAllProviderWithServiceLocationAndOrganizationAsync(cancellationToken)
            .ConfigureAwait(false);
    }
}