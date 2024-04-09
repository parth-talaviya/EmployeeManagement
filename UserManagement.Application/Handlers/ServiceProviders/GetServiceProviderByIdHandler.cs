namespace UserManagement.Application.Handlers.ServiceProviders;

public sealed class
    GetServiceProviderByIdHandler : IRequestHandler<GetServiceProviderQuery, ServiceProviderDetailsViewModel?>
{
    private readonly IServiceProviderService _serviceProvideService;

    public GetServiceProviderByIdHandler(IServiceProviderService serviceProviderService)
    {
        _serviceProvideService = serviceProviderService;
    }

    public Task<ServiceProviderDetailsViewModel?> Handle(GetServiceProviderQuery request,
        CancellationToken cancellationToken)
    {
        return _serviceProvideService.GetServiceProviderAsync(request.Id, cancellationToken);
    }
}