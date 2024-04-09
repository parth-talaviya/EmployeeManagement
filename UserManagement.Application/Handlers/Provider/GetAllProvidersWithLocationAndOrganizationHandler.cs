namespace UserManagement.Application.Handlers.Provider;

public sealed class GetAllProvidersWithLocationAndOrganizationHandler : IRequestHandler<GetAllProviderWithLocationandOrganizationQuery, IEnumerable<GetAllProviderswithLocationAndOrganizationViewModel>>
{
    private readonly IProviderService _providerService;

    public GetAllProvidersWithLocationAndOrganizationHandler(IProviderService providerService)
    {
        _providerService = providerService;
    }

    public async Task<IEnumerable<GetAllProviderswithLocationAndOrganizationViewModel>> Handle(GetAllProviderWithLocationandOrganizationQuery request,
        CancellationToken cancellationToken)
    {
        return await _providerService.GetAllProviderWithLocationAndOrganizationAsync(cancellationToken).ConfigureAwait(false);
    }
}