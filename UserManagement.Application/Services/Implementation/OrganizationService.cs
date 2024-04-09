namespace UserManagement.Application.Services.Implementation;

[RegisterService(typeof(IOrganizationService))]
public sealed class OrganizationService : IOrganizationService
{
    private readonly IOrganizationRepository _organizationRepository;
    private readonly IMapper _mapper;

    public OrganizationService(IOrganizationRepository organizationRepository, IMapper mapper)
    {
        _organizationRepository = organizationRepository;
        _mapper = mapper;
    }

    public async Task<int> AddOrganizationAsync(AddOrganizationViewModel organizationViewModel,
        CancellationToken cancellationToken)
    {
        var organization = _mapper.Map<AddOrganizationViewModel, Organization>(organizationViewModel);
        return await _organizationRepository.AddOrganizationAsync(organization, cancellationToken)
            .ConfigureAwait(false);
    }

    public async Task<OrganizationViewModel?> DeleteOrganizationAsync(int id, CancellationToken cancellationToken)
    {
        var organization = await _organizationRepository.DeleteOrganizationAsync(id, cancellationToken)
            .ConfigureAwait(false);

        return organization != null ? _mapper.Map<OrganizationViewModel>(organization) : null;
    }

    public async Task<UpdateOrganizationViewModel?> EditOrganizationAsync(
        UpdateOrganizationViewModel organizationViewModel,
        CancellationToken cancellationToken)
    {
        var organization = _mapper.Map<UpdateOrganizationViewModel, Organization>(organizationViewModel);
        var updatedOrganization = await _organizationRepository.EditOrganizationAsync(organization, cancellationToken)
            .ConfigureAwait(false);

        return updatedOrganization != null
            ? _mapper.Map<Organization, UpdateOrganizationViewModel>(updatedOrganization)
            : null;
    }

    public async Task<IEnumerable<OrganizationViewModel>> GetAllOrganizationAsync(CancellationToken cancellationToken)
    {
        var organizations =
            await _organizationRepository.GetAllOrganizationAsync(cancellationToken).ConfigureAwait(false);

        return _mapper.Map<List<OrganizationViewModel>>(organizations) ?? Enumerable.Empty<OrganizationViewModel>();
    }

    public async Task<OrganizationViewModel?> GetOrganizationAsync(int id, CancellationToken cancellationToken)
    {
        var organization =
            await _organizationRepository.GetOrganizationAsync(id, cancellationToken).ConfigureAwait(false);

        return organization != null ? _mapper.Map<OrganizationViewModel>(organization) : null;
    }
}