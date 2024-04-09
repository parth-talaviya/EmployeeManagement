namespace UserManagement.Application.Handlers.Provider;

public sealed class AddProviderHandler : IRequestHandler<AddProviderCommand, AddProvidersViewModel?>
{
    private readonly IProviderService _providerDetailService;

    public AddProviderHandler(IProviderService providerDetailService)
    {
        _providerDetailService = providerDetailService;
    }

    public Task<AddProvidersViewModel?> Handle(AddProviderCommand addProviderCommand,
        CancellationToken cancellationToken)
    {
        return _providerDetailService.AddProviderAsync(addProviderCommand.AddProviderModel, cancellationToken);
    }
}