namespace UserManagement.Application.Services.Implementation;

[RegisterService(typeof(IContactOrganizationService))]
public sealed class ContactOrganizationService : IContactOrganizationService
{
    private readonly IContactOrganizationRepository _contactOrganizationRepository;
    private readonly IMapper _mapper;

    public ContactOrganizationService(IContactOrganizationRepository contactOrganizationRepository, IMapper mapper)
    {
        _contactOrganizationRepository = contactOrganizationRepository;
        _mapper = mapper;
    }

    public async Task<int> AddContactOrganizationAsync(AddContactOrganizationViewModel contactOrganizationViewModel,
        CancellationToken cancellationToken)
    {
        var contactOrganization =
            _mapper.Map<AddContactOrganizationViewModel, ContactOrganization>(contactOrganizationViewModel);

        return await _contactOrganizationRepository.AddContactOrganizationAsync(contactOrganization, cancellationToken)
            .ConfigureAwait(false);
    }

    public async Task<ContactOrganizationViewModel?> DeleteContactOrganizationAsync(int id,
        CancellationToken cancellationToken)
    {
        var contactOrganization = await _contactOrganizationRepository
            .DeleteContactOrganizationAsync(id, cancellationToken).ConfigureAwait(false);

        return contactOrganization != null ? _mapper.Map<ContactOrganizationViewModel>(contactOrganization) : null;
    }

    public async Task<IEnumerable<ContactOrganizationViewModel>> GetContactOrganizationAsync(int contactId,
        CancellationToken cancellationToken)
    {
        var contactOrganization = await _contactOrganizationRepository
            .GetContactOrganizationAsync(contactId, cancellationToken).ConfigureAwait(false);

        return _mapper.Map<IEnumerable<ContactOrganizationViewModel>>(contactOrganization) ??
               Enumerable.Empty<ContactOrganizationViewModel>();
    }
}