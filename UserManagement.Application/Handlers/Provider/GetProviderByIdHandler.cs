namespace UserManagement.Application.Handlers.Provider;

public sealed class GetProviderByIdHandler : IRequestHandler<GetProviderQuery, ProvidersDetailsViewModel?>
{
    private readonly IProviderService _providerService;

    public GetProviderByIdHandler(IProviderService providerService)
    {
        _providerService = providerService;
    }

    public Task<ProvidersDetailsViewModel?> Handle(GetProviderQuery request, CancellationToken cancellationToken)
    {
        return _providerService.GetProviderAsync(request.Id, cancellationToken);
    }
}