namespace UserManagement.Application.Handlers.Service;

public sealed class GetAllServiceHandler : IRequestHandler<GetAllServiceQuery, IEnumerable<ServiceDetailsViewModel>>
{
    private readonly IServiceService _serviceService;

    public GetAllServiceHandler(IServiceService serviceService)
    {
        _serviceService = serviceService;
    }

    public async Task<IEnumerable<ServiceDetailsViewModel>> Handle(GetAllServiceQuery request,
        CancellationToken cancellationToken)
    {
        return await _serviceService.GetAllServiceAsync(cancellationToken).ConfigureAwait(false);
    }
}