namespace UserManagement.Application.Commands.Organization;

public sealed record CreateOrganizationCommand(AddOrganizationViewModel OrganizationViewModel)
    : IRequest<AddOrganizationViewModel>;