namespace UserManagement.Infrastructure.Abstraction;

public interface IContactOrganizationRepository
{
    Task<ContactOrganization?> DeleteContactOrganizationAsync(int id, CancellationToken cancellationToken);

    Task<IEnumerable<ContactOrganization>> GetContactOrganizationAsync(int contactId,
        CancellationToken cancellationToken);

    Task<int> AddContactOrganizationAsync(ContactOrganization contactOrganization, CancellationToken cancellationToken);
}