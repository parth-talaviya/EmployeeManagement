namespace UserManagement.Application.Services.Implementation;

[RegisterService(typeof(IContactDetailService))]
public sealed class ContactDetailService : IContactDetailService
{
    private readonly IContactDetailsRepository _contactDetailsRepository;
    private readonly IMapper _mapper;

    public ContactDetailService(IContactDetailsRepository contactDetailRepository, IMapper mapper)
    {
        _contactDetailsRepository = contactDetailRepository;
        _mapper = mapper;
    }

    public async Task<int> CreateContactAsync(CreateContactDetailViewModel contactDetailViewModel,
        CancellationToken cancellationToken)
    {
        var contact = _mapper.Map<CreateContactDetailViewModel, ContactDetails>(contactDetailViewModel);
        return await _contactDetailsRepository.AddContactDetailAsync(contact, cancellationToken).ConfigureAwait(false);
    }

    public async Task<UpdateContactViewModel?> EditContactAsync(UpdateContactViewModel contactDetailsUpdateViewModel,
        CancellationToken cancellationToken)
    {
        var editContact = _mapper.Map<UpdateContactViewModel, ContactDetails>(contactDetailsUpdateViewModel);
        var updateContact = await _contactDetailsRepository.EditContactDetailAsync(editContact, cancellationToken)
            .ConfigureAwait(false);

        return updateContact != null ? _mapper.Map<ContactDetails, UpdateContactViewModel>(updateContact) : null;
    }

    public async Task<CreateContactDetailViewModel?> DeleteContactAsync(int id, CancellationToken cancellationToken)
    {
        var deleteContact = await _contactDetailsRepository.DeleteContactDetailAsync(id, cancellationToken)
            .ConfigureAwait(false);

        return deleteContact != null ? _mapper.Map<CreateContactDetailViewModel>(deleteContact) : null;
    }

    public async Task<IEnumerable<CreateContactDetailViewModel>> GetAllContactAsync(
        GetAllContactViewModel getAllContact, CancellationToken cancellationToken)
    {
        var editContact = _mapper.Map<GetAllContactViewModel, GetAllContactModel>(getAllContact);
        var getAllContactsDetail = await _contactDetailsRepository
            .GetAllContactDetailAsync(editContact, cancellationToken).ConfigureAwait(false);

        return _mapper.Map<IEnumerable<CreateContactDetailViewModel>>(getAllContactsDetail) ??
               Enumerable.Empty<CreateContactDetailViewModel>();
    }

    public async Task<CreateContactDetailViewModel?> GetContactAsync(int id, CancellationToken cancellationToken)
    {
        var getContact = await _contactDetailsRepository.GetContactDetailAsync(id, cancellationToken)
            .ConfigureAwait(false);

        return getContact != null ? _mapper.Map<CreateContactDetailViewModel>(getContact) : null;
    }
}