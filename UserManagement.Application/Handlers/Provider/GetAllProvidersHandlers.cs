namespace UserManagement.Application.Handlers.Provider;

public sealed class
    GetAllProvidersHandlers : IRequestHandler<GetAllProvidersQuery, IEnumerable<ProvidersDetailsViewModel>>
{
    private readonly IProviderService _providerService;

    public GetAllProvidersHandlers(IProviderService providerService)
    {
        _providerService = providerService;
    }

    public async Task<IEnumerable<ProvidersDetailsViewModel>> Handle(GetAllProvidersQuery request,
        CancellationToken cancellationToken)
    {
        return await _providerService.GetAllProviderAsync(cancellationToken).ConfigureAwait(false);
    }
}