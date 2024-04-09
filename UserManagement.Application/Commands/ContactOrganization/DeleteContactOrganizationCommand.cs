namespace UserManagement.Application.Commands.ContactOrganization;

public sealed record DeleteContactOrganizationCommand(int Id) : IRequest<ContactOrganizationViewModel>;