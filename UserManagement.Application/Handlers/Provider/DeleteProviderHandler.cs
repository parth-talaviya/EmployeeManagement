namespace UserManagement.Application.Handlers.Provider;

public sealed class DeleteProviderHandler : IRequestHandler<DeleteProviderCommand, ProvidersDetailsViewModel?>
{
    private readonly IProviderService _providerDetailService;

    public DeleteProviderHandler(IProviderService providerDetailService)
    {
        _providerDetailService = providerDetailService;
    }

    public async Task<ProvidersDetailsViewModel?> Handle(DeleteProviderCommand request,
        CancellationToken cancellationToken)
    {
        return await _providerDetailService.DeleteProviderAsync(request.Id, cancellationToken).ConfigureAwait(false);
    }
}