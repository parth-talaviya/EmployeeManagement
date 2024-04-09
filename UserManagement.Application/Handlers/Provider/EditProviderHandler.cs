namespace UserManagement.Application.Handlers.Provider;

public sealed class EditProviderHandler : IRequestHandler<EditProviderCommand, EditProvidersViewModel?>
{
    private readonly IProviderService _providerDetailService;

    public EditProviderHandler(IProviderService providerDetailService)
    {
        _providerDetailService = providerDetailService;
    }

    public Task<EditProvidersViewModel?> Handle(EditProviderCommand editProviderCommand,
        CancellationToken cancellationToken)
    {
        return _providerDetailService.EditProviderAsync(editProviderCommand.ProviderDetailsViewModel,
            cancellationToken);
    }
}