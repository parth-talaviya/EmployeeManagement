namespace UserManagement.Application.Handlers.Service;

public sealed class GetServiceByIdHandler : IRequestHandler<GetServiceQuery, ServiceDetailsViewModel?>
{
    private readonly IServiceService _serviceService;

    public GetServiceByIdHandler(IServiceService serviceService)
    {
        _serviceService = serviceService;
    }

    public Task<ServiceDetailsViewModel?> Handle(GetServiceQuery request, CancellationToken cancellationToken)
    {
        return _serviceService.GetServiceAsync(request.Id, cancellationToken);
    }
}