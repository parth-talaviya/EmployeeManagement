namespace UserManagement.Application.Handlers.ServiceProviders;

public sealed class
    DeleteServiceProviderHandler : IRequestHandler<DeleteServiceProviderCommand, ServiceProviderDetailsViewModel?>
{
    private readonly IServiceProviderService _serviceProividerDetailService;

    public DeleteServiceProviderHandler(IServiceProviderService serviceProviderDetailService)
    {
        _serviceProividerDetailService = serviceProviderDetailService;
    }

    public async Task<ServiceProviderDetailsViewModel?> Handle(DeleteServiceProviderCommand request,
        CancellationToken cancellationToken)
    {
        return await _serviceProividerDetailService.DeleteServiceProviderAsync(request.Id, cancellationToken)
            .ConfigureAwait(false);
    }
}