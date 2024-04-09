namespace UserManagement.Application.Handlers.ServiceProviders;

public sealed class AddServiceProviderHandler : IRequestHandler<AddServiceProviderCommand, AddServiceProviderViewModel?>
{
    private readonly IServiceProviderService _serviceProviderDetailService;

    public AddServiceProviderHandler(IServiceProviderService serviceProviderDetailService)
    {
        _serviceProviderDetailService = serviceProviderDetailService;
    }

    public Task<AddServiceProviderViewModel?> Handle(AddServiceProviderCommand addServiceProviderCommand,
        CancellationToken cancellationToken)
    {
        return _serviceProviderDetailService.AddServiceProviderAsync(addServiceProviderCommand.AddServiceProviderModel,
            cancellationToken);
    }
}