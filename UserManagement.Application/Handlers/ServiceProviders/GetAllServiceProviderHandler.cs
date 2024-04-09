namespace UserManagement.Application.Handlers.ServiceProviders;

public sealed class
    GetAllServiceProviderHandler : IRequestHandler<GetAllServiceProviderQuery,
    IEnumerable<ServiceProviderDetailsViewModel>>
{
    private readonly IServiceProviderService _serviceProviderService;

    public GetAllServiceProviderHandler(IServiceProviderService serviceProviderService)
    {
        _serviceProviderService = serviceProviderService;
    }

    public async Task<IEnumerable<ServiceProviderDetailsViewModel>> Handle(GetAllServiceProviderQuery request,
        CancellationToken cancellationToken)
    {
        return await _serviceProviderService.GetAllServiceProviderAsync(cancellationToken).ConfigureAwait(false);
    }
}