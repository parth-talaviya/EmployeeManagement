namespace UserManagement.Application.Services.Abstraction;

public interface IContactDetailService
{
    Task<int> CreateContactAsync(CreateContactDetailViewModel contactDetailViewModel,
        CancellationToken cancellationToken);

    Task<UpdateContactViewModel?> EditContactAsync(UpdateContactViewModel contactDetailsUpdateViewModel,
        CancellationToken cancellationToken);

    Task<CreateContactDetailViewModel?> DeleteContactAsync(int id, CancellationToken cancellationToken);

    Task<CreateContactDetailViewModel?> GetContactAsync(int id, CancellationToken cancellationToken);

    Task<IEnumerable<CreateContactDetailViewModel>> GetAllContactAsync(GetAllContactViewModel getAllContact,
        CancellationToken cancellationToken);
}