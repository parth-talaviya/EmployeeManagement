namespace UserManagement.Application.Queries.ContactOrganization;

public sealed record GetContactOrganizationQuery(int ContactId) : IRequest<IEnumerable<ContactOrganizationViewModel>>;