namespace UserManagement.Infrastructure.Abstraction;

public interface IContactDetailsRepository
{
    Task<int> AddContactDetailAsync(ContactDetails contactDetails, CancellationToken cancellationToken);

    Task<ContactDetails?> EditContactDetailAsync(ContactDetails contactDetails, CancellationToken cancellationToken);

    Task<ContactDetails?> DeleteContactDetailAsync(int id, CancellationToken cancellationToken);

    Task<IEnumerable<ContactDetails>> GetAllContactDetailAsync(GetAllContactModel getAllContact,
        CancellationToken cancellationToken);

    Task<ContactDetails?> GetContactDetailAsync(int id, CancellationToken cancellationToken);
}