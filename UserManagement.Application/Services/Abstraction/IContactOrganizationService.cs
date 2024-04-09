namespace UserManagement.Application.Services.Abstraction;

public interface IContactOrganizationService
{
    Task<ContactOrganizationViewModel?> DeleteContactOrganizationAsync(int id, CancellationToken cancellationToken);

    Task<int> AddContactOrganizationAsync(AddContactOrganizationViewModel contactOrganizationViewModel,
        CancellationToken cancellationToken);

    Task<IEnumerable<ContactOrganizationViewModel>> GetContactOrganizationAsync(int contactId,
        CancellationToken cancellationToken);
}