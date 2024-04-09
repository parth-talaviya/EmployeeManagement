namespace UserManagement.Application.Commands.Organization;

public sealed record DeleteOrganizationCommand(int Id) : IRequest<OrganizationViewModel>;