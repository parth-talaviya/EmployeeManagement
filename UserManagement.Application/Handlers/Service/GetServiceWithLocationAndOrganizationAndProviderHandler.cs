namespace UserManagement.Application.Handlers.Service;

public sealed class GetServiceWithLocationAndOrganizationAndProviderHandler : IRequestHandler<
    GetAllServiceWithLcationAndOrganizationandProvidersQuery,
    IEnumerable<GetAllServiceWithOrganizationAndLocationViewModel>>
{
    private readonly IServiceService _serviceService;

    public GetServiceWithLocationAndOrganizationAndProviderHandler(IServiceService serviceService)
    {
        _serviceService = serviceService;
    }

    public async Task<IEnumerable<GetAllServiceWithOrganizationAndLocationViewModel>> Handle(
        GetAllServiceWithLcationAndOrganizationandProvidersQuery request,
        CancellationToken cancellationToken)
    {
        return await _serviceService.GetAllServiceWithLocationIdOrOrganizationAndProvidersIdAsync(cancellationToken)
            .ConfigureAwait(false);
    }
}