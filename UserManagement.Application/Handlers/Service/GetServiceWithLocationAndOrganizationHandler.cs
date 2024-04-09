namespace UserManagement.Application.Handlers.Service;

public sealed class GetServiceWithLocationAndOrganizationHandler : IRequestHandler<GetAllServicewithLocationAndOrganizationQuery, IEnumerable<GetAllServiceWithOrganizationAndLocationViewModel>>
{
    private readonly IServiceService _serviceService;

    public GetServiceWithLocationAndOrganizationHandler(IServiceService serviceService)
    {
        _serviceService = serviceService;
    }

    public async Task<IEnumerable<GetAllServiceWithOrganizationAndLocationViewModel>> Handle(GetAllServicewithLocationAndOrganizationQuery request,
        CancellationToken cancellationToken)
    {
        return await _serviceService.GetAllServiceWithLocationIdOrOrganizationIdAsync(cancellationToken).ConfigureAwait(false);
    }
}